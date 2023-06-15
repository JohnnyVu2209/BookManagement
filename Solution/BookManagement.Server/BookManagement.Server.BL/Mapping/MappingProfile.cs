
using AutoMapper;
using BookManagement.Server.DL.Models;
using BookManagement.Server.DL.ValueObjects;
using BookManagement.Shared.Models.Dtos;

namespace BookManagement.Server.BL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(b => b.Author, s => s.MapFrom(d => d.Author.FirstName +' ' + d.Author.LastName)).ReverseMap();
            CreateMap<AddBookDto, Book>()
                .ForMember(b => b.Author, s => s.MapFrom(d=> new Author(d.Author_FirstName,d.Author_LastName)));
            CreateMap<EditBookDto, Book>()
                .ForMember(b => b.Author, s => s.MapFrom(d => new Author(d.Author_FirstName, d.Author_LastName)));
            CreateMap<Book, Book>()
                .ForMember(b => b.Id, s => s.Ignore())
                .ForMember(b => b.CreatedAt, s => s.Ignore());
        }
    }
}
