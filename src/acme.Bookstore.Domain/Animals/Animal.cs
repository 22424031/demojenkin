using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace acme.Bookstore.Animals
{
    public class Animal :AuditedAggregateRoot<Guid>
    {
        public string AnimalName { get; set; }
        public float Price { get; set; }

    }
}
