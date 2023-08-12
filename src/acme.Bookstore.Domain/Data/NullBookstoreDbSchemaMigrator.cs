using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace acme.Bookstore.Data;

/* This is used if database provider does't define
 * IBookstoreDbSchemaMigrator implementation.
 */
public class NullBookstoreDbSchemaMigrator : IBookstoreDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
