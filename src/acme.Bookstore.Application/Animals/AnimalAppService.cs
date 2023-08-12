using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace acme.Bookstore.Animals
{
    public class AnimalAppService : CrudAppService<
        Animal
        , AnimalDto
        , Guid
        , PagedAndSortedResultRequestDto
        , CreateUpdateAnimalDto
        , IAnimalAppService
        >
    {
        public AnimalAppService(IRepository<Animal, Guid> repository) : base(repository)
        {
        }
    }
}
