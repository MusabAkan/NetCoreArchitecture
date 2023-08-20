using Application.Features.Brands.Commands.Delete;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeletedBrandCommand : IRequest<DeletedBrandResponse>
    {
        public Guid Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeletedBrandCommand, DeletedBrandResponse>
        {
            readonly IBrandRepository _brandRepository;
            readonly IMapper _mapper;

            public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }
            public async Task<DeletedBrandResponse> Handle(DeletedBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(b=> b.Id == request.Id, cancellationToken:cancellationToken);
                await _brandRepository.DeleteAsync(brand);
                DeletedBrandResponse response = _mapper.Map<DeletedBrandResponse>(brand);
                return response;

            }
        }
    }
}
