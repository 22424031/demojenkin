using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.DependencyInjection;

namespace acme.Bookstore.Animals
{
    public class AnimalDataSeederContributor:IDataSeedContributor, ITransientDependency
    {
        
        private readonly IRepository<Animal, Guid> _AnimalRepository;

       
        public AnimalDataSeederContributor(IRepository<Animal, Guid> animalRepository)
        {
            _AnimalRepository = animalRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            
            //if (await _AnimalRepository.GetCountAsync() <= 0)
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
