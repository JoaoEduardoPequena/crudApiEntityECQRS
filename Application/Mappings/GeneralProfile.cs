using AutoMapper;
using Domain.Entities;
using Domain.Models.DTOS.Categoria;
using Domain.Models.DTOS.Produto;
//using Domain.Models.DTOS.Categoria;
//using Domain.Models.DTOS.Produto;


namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            CreateMap<CategoriaDTO, Categoria>().ReverseMap();
            CreateMap<ProdutoDTO, Produto>().ReverseMap();
        } 
    }
}
