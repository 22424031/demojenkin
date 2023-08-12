using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace acme.Bookstore.Animals
{
    public class AnimalDto:AuditedEntityDto<Guid>
    {
        public string AnimalName { get; set; }
        public float Price { get; set; }
    }
}
