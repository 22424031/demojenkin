using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using acme.Bookstore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace acme.Bookstore.Controllers
{
    public abstract class AbcController:AbpControllerBase
    {
        protected AbcController()
        {
            LocalizationResource = typeof(BookstoreResource);
        }
    }
}
