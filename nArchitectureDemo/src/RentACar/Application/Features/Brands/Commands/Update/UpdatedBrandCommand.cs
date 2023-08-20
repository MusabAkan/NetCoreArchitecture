using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdatedBrandCommand : IRequest<UpdatedBrandResponse>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public class UpdatedBrandCommandHandler : IRequestHandler<UpdatedBrandCommand, UpdatedBrandResponse>
        {
            readonly IBrandRepository _brandRepository;
            readonly IMapper _mapper;

            public UpdatedBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }
            public async Task<UpdatedBrandResponse> Handle(UpdatedBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(b => b.Id == request.ID, cancellationToken: cancellationToken);

                brand = _mapper.Map(request, brand);

                await _brandRepository.UpdateAsync(brand);

                UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(brand);

                return response;
            }
        }
    }
}
