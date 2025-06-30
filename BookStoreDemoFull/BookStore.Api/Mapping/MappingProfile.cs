using AutoMapper;
using BookStore.Api.DTOs;
using BookStore.Api.Models.Entities;

namespace BookStore.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null));
        CreateMap<CreateBookDto, Book>();
        CreateMap<UpdateBookDto, Book>();
    }
}