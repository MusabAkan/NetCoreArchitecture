using MediatR;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommand : IRequest<CreateBrandResponse>
    { 
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreateBrandResponse>
        {
            public Task<CreateBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                CreateBrandResponse createBrandResponse = new()
                {
                    Name = request.Name,
                    Id = Guid.NewGuid()
                };
                return null; 


            }
        }
    }
}
