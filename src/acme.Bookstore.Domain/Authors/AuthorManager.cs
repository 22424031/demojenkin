using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace acme.Bookstore.Authors
{
    public class AuthorManager:DomainService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        AuthorManager() { }
        public async Task<Author> CreateAsync([NotNull]string name,
            DateTime birthDay, [CanBeNull]string shortBio)
        {
            var author = await _authorRepository.FindByNameAsync(name);
            if (author != null)
            {
                throw new AuthorAlreadyExistsException(name);
            }
            return new Author(
                GuidGenerator.Create(),
                name,
                birthDay, shortBio
                );
        }

        public async Task ChangeNameAsync(Author author, string newName)
        {
            Check.NotNull(author, nameof(author));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));
            var authorExisting = await _authorRepository.FindByNameAsync(newName);
            if (authorExisting != null)
            {
                throw new AuthorAlreadyExistsException(newName);
            }
            author.ChangeName(newName);
        }
    }
}
