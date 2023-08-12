using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace acme.Bookstore.Authors
{
    public class CreateAuthorDto:EntityDto
    {
        [Required]
        [MaxLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }

        public string ShortBio { get; set; }
    }
}
