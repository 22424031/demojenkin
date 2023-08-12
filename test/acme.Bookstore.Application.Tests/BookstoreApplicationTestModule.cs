using Volo.Abp.Modularity;

namespace acme.Bookstore;

[DependsOn(
    typeof(BookstoreApplicationModule),
    typeof(BookstoreDomainTestModule)
    )]
public class BookstoreApplicationTestModule : AbpModule
{

}
