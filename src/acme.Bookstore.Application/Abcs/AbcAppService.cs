using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace acme.Bookstore.Abcs
{
    public class AbcAppService : ApplicationService, IAbcAppService
    {
        [RemoteService(IsEnabled = false)]
        public Task GetAsync()
        {
            Console.WriteLine(1);
            throw new NotImplementedException();
        }
    }
}
