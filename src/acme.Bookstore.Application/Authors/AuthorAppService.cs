using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using acme.Bookstore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Application.Services;

namespace acme.Bookstore.Authors
{
    public class AuthorAppService : BookstoreAppService ,IAuthorAppService
    {
        private readonly  IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;
       public AuthorAppService(IAuthorRepository authorRepository, AuthorManager authorManager)
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }

        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
           var author = await _authorManager.CreateAsync(input.Name, input.BirthDay, input.ShortBio);
           await _authorRepository.InsertAsync(author);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task DeleteAsync(Guid id)
        {
            var author = await _authorRepository.FindAsync(id);
            if(author != null)
            {
                await _authorRepository.DeleteAsync(author);
            }
        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorDto> (author);
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
        {
            if(input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Author.Name);
            }
            var authors = await _authorRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.filter);
            var total = input.filter == null ? await _authorRepository.CountAsync(): 
                 await _authorRepository.CountAsync(author => author.Name.Contains(input.filter));


            return new PagedResultDto<AuthorDto>(total, ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors));

        }

        public async Task UpDateAsync(Guid id, CreateAuthorDto input)
        {
            var author = await _authorRepository.GetAsync(id);
            if(author.Name != input.Name)
            {
                await _authorManager.ChangeNameAsync(author, input.Name);
            }
            author.BirthDay = input.BirthDay;
            author.ShortBio = input.ShortBio;

            await _authorRepository.UpdateAsync(author);

        }
    }
}
