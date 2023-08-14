using AutoMapper;
using TechTest.Application.DTOs;
using TechTest.Domain.Entities;

namespace TechTest.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
    }
}
