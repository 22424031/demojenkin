using AutoMapper;
using acme.Bookstore.Books;
using acme.Bookstore.Animals;
using acme.Bookstore.Authors;

namespace acme.Bookstore;

public class BookstoreApplicationAutoMapperProfile : Profile
{
    public BookstoreApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        //Animal
        CreateMap<Animal, AnimalDto>();
        CreateMap<CreateUpdateAnimalDto, Animal>();

        //Author
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateAuthorDto, Author>();
        CreateMap<UpdateAuthorDto, Author>();
        CreateMap<Author, AuthorLookupDto>();
    }
}
