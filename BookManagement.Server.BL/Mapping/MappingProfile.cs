
using AutoMapper;
using BookManagement.Server.DL.Models;
using BookManagement.Shared.Models.Dtos;

namespace BookManagement.Server.BL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(b => b.Author, s => s.MapFrom(d => d.Author.FirstName +' ' + d.Author.LastName));
        }
    }
}
