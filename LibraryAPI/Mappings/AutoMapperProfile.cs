using AutoMapper;
using LibraryAPI.Entities.DTOs.Book;

namespace LibraryAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateBookDTO, Entities.Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())  
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatuId));

            CreateMap<UpdateBookDTO, Entities.Book>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId));

            CreateMap<BookDTO, Entities.Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId));

            CreateMap<Entities.Book, CreateBookDTO>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.StatuId, opt => opt.MapFrom(src => src.StatusId));

            CreateMap<Entities.Book, UpdateBookDTO>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId));

            CreateMap<Entities.Book, BookDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId));
        }
    }
}
