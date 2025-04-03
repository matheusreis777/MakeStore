using AutoMapper;
using MakeStore.Application.Dto;
using MakeStore.Application.DTOs;
using MakeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MakeStore.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.product_colors, opt => opt.MapFrom(src => src.product_colors))
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario));

            CreateMap<ProdutoDto, Produto>()
                .ForMember(dest => dest.product_colors, opt => opt.MapFrom(src => src.product_colors))
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario));

            CreateMap<CoresProdutos, CoresProdutosDto>().ReverseMap();
            CreateMap<Produto, CarrinhoDto>().ReverseMap();
            CreateMap<ProdutoDto, CarrinhoDto>().ReverseMap();
        }
    }

}
