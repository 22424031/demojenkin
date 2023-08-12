using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace acme.Bookstore.Animals
{
    public interface IAnimalAppService: ICrudAppService<AnimalDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAnimalDto>
    {
    }
}
