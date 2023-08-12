using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace acme.Bookstore.Authors
{
    public class AuthorDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly AuthorManager _authorManager;
        public AuthorDataSeederContributor(IAuthorRepository repository, AuthorManager authorManager)
        {
            _AuthorRepository = repository;
            _authorManager = authorManager;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if( await _AuthorRepository.GetCountAsync() <= 0)
            {
                await _AuthorRepository.InsertAsync(
                  await _authorManager.CreateAsync(
                         "Tony 1",
                          DateTime.Now,
                            "a"
                    ), autoSave: true);
                await _AuthorRepository.InsertAsync(
                  await _authorManager.CreateAsync(
                         "phat tai 1",
                          DateTime.Now,
                            "a"
                    ), autoSave: true);
                await _AuthorRepository.InsertAsync(
                  await _authorManager.CreateAsync(
                         "phát Lộc 1",
                          DateTime.Now,
                            "a"
                    ),autoSave:true);
            }
        
        }
    }
}
