using acme.Bookstore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace acme.Bookstore.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BookstoreController : AbpControllerBase
{
    protected BookstoreController()
    {
        LocalizationResource = typeof(BookstoreResource);
    }
}
