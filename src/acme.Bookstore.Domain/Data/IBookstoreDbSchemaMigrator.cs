using System.Threading.Tasks;

namespace acme.Bookstore.Data;

public interface IBookstoreDbSchemaMigrator
{
    Task MigrateAsync();
}
