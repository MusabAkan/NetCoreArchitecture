using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Command
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdatedBrandCommand>().ReverseMap();
            CreateMap<Brand, DeletedBrandCommand>().ReverseMap();

            #endregion

            #region Response
            CreateMap<Brand, CreateBrandResponse>().ReverseMap();
            CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
            CreateMap<Brand, UpdatedBrandResponse>().ReverseMap();
            CreateMap<Brand, DeletedBrandResponse>().ReverseMap();
            #endregion

            #region Dto
            CreateMap<Paginate<Brand>, GetListResponse<GetListBrandListItemDto>>().ReverseMap();
            CreateMap<Brand, GetListBrandListItemDto>().ReverseMap();
            #endregion


        }
    }
}
