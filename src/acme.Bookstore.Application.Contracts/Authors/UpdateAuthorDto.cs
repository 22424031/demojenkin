using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace acme.Bookstore.Authors
{
    public class UpdateAuthorDto
    {
        [Required]
        [MaxLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }

        public string ShortBio { get; set; }
    }
}
