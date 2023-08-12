using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace acme.Bookstore.Authors
{
    public class AuthorDto: EntityDto<Guid>
    {
        string _ShortBio = "";
        string _Name = "";
        public string Name { get { return _Name; } set { _Name = value; }  }
        public DateTime BirthDay { get; set; }
        public string ShortBio { get { return _ShortBio; } set { _ShortBio = value; } }

        public Guid AuthorId { get; set; }
        public string AuthorName() { return Name + ShortBio; }
      
    }
}
