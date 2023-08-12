using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace acme.Bookstore.Abcs
{
    public interface IAbcAppService: IApplicationService
    {
        Task GetAsync();
    }
}
