using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace acme.Bookstore.Animals
{
    public class CreateUpdateAnimalDto

    {
        [Required]
        public string AnimalName { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
