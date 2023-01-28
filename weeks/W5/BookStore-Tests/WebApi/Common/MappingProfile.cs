namespace WebApi.Common;

using AutoMapper;
using WebApi.Entities;
using static Webapi.Application.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQuery;
using static Webapi.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;
using static WebApi.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static WebApi.AuthorOperations.Queries.GetAuthorDetail.GetAuthorDetailQuery;
using static WebApi.AuthorOperations.Queries.GetAuthors.GetAuthorsQuery;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBooks.GetBooksQuery;
using static WebApi.BookOperations.GetByQuery.GetByIdQuery;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookModel, Book>();
        CreateMap<UpdateBookModel, Book>();
        CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.Name} {src.Author.Surname}"));
        CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.Name} {src.Author.Surname}"));
        CreateMap<Genre, GenresViewModel>();
        CreateMap<Genre, GenreDetailViewModel>();
        CreateMap<Author, AuthorViewModel>();
        CreateMap<Author, AuthorsViewModel>();
        CreateMap<CreateAuthorModel, Author>();
    }
}