using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using acme.Bookstore.Authors;
using Microsoft.EntityFrameworkCore;

namespace acme.Bookstore.EntityFrameworkCore
{
    public class EfCoreAuthorRepository : EfCoreRepository<BookstoreDbContext, Author, Guid>, IAuthorRepository
    {
        public EfCoreAuthorRepository(IDbContextProvider<BookstoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
       
        public async Task<Author> FindByNameAsync(string name)
        {
            var dbset = await GetDbSetAsync();
            return await dbset.FirstOrDefaultAsync(x => x.Name.Contains(name));
        }

        public async Task<List<Author>> GetListAsync(int skipCount, int totalCount, string sorting, string filter)
        {
            var dbset = await GetDbSetAsync();
            return await dbset.WhereIf(
                !filter.IsNullOrWhiteSpace(),
                author => author.Name.Contains(filter)
                ).OrderBy(x => x.Name.Contains(filter)).Skip(skipCount).Take(totalCount).ToListAsync();
        }
    }
}
