using acme.Bookstore.Animals;
using acme.Bookstore.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace acme.Bookstore.Books
{
    public class BookStoreDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IAuthorRepository _AuthorRepository;
        private readonly AuthorManager _authorManager;

        public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository,
            AuthorManager authorManager, IAuthorRepository authorRepository)
        {
            _AuthorRepository = authorRepository;
            _bookRepository = bookRepository;
            _authorManager = authorManager; 
        }
        //public BookStoreDataSeederContributor(IRepository<Animal, Guid> animalRepository)
        //{
        //    _AnimalRepository = animalRepository;
        //}

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _bookRepository.GetCountAsync() <= 0)
            {
               // var thomas = await _authorManager.CreateAsync("thomas", DateTime.Now, "aTho");
                //var taka = await _authorManager.CreateAsync("Taka", DateTime.Now, "ATu");
              // await _AuthorRepository.InsertAsync(thomas, autoSave:true);
               // await _AuthorRepository.InsertAsync(taka, autoSave: true);
                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "2022",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1949, 6, 8),
                        Price = 19.84f,
                        AuthorId = new Guid("58d92f6a-b4b9-2ce9-463c-3a07110c4b80")
                    },
                    autoSave: true
                ) ;

                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "The Hitle",
                        Type = BookType.ScienceFiction,
                        PublishDate = new DateTime(1995, 9, 27),
                        Price = 42.0f,
                        AuthorId = new Guid("ac07d06c-2520-9651-c453-3a0711233223")
                    },
                    autoSave: true
                ) ;
            }
            //if(await _bookRepository.GetCountAsync() <= 0)
            //{
            //    await _AnimalRepository.InsertAsync(new Animal
            //    {
            //        AnimalName = "Tiger",
            //        Price = 2000000
            //    }, autoSave: true);
            //    await _AnimalRepository.InsertAsync(new Animal
            //    {
            //        AnimalName = "Dog",
            //        Price = 100000
            //    }, autoSave: true);
            //}
        }
    }
}
