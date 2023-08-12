using acme.Bookstore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace acme.Bookstore;

[DependsOn(
    typeof(BookstoreEntityFrameworkCoreTestModule)
    )]
public class BookstoreDomainTestModule : AbpModule
{

}
