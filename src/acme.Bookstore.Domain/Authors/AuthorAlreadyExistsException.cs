using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace acme.Bookstore.Authors
{
    public  class AuthorAlreadyExistsException:BusinessException
    {
        public AuthorAlreadyExistsException(string name):base(BookstoreDomainErrorCodes.AuthorAlReadyExists)
        {
            WithData("name", name);
        }
    }
}
