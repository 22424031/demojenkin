using acme.Bookstore.Authors;
using acme.Bookstore.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace acme.Bookstore.Books
{
    public class BookAppService : CrudAppService<
        Book,
        BookDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBookDto,
        IBookAppService>
    {
        private readonly IAuthorRepository _authorRepository;
        public BookAppService(IRepository<Book, Guid> repository, IAuthorRepository authorRepository) : base(repository)
        {
            _authorRepository = authorRepository;
            //GetPolicyName = BookstorePermissions.Books.Default;
            //GetListPolicyName = BookstorePermissions.Books.Default;
            //CreatePolicyName = BookstorePermissions.Books.Create;
            //UpdatePolicyName = BookstorePermissions.Books.Edit;
            //DeletePolicyName = BookstorePermissions.Books.Delete;
        }
        public override async Task<BookDto> GetAsync(Guid id)
        {
            var authorre = await _authorRepository.GetQueryableAsync();
            var queryable = await Repository.GetQueryableAsync();
            var query = from book in queryable 
                        join author in await _authorRepository.GetQueryableAsync()
                        on book.AuthorId equals author.Id
                        where book.Id == id
                        select new { book, author };
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if(queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Book), id);
            }
            var result = ObjectMapper.Map<Book, BookDto>(queryResult.book);
            result.AuthorName = queryResult.author.Name;
            return result;
        }
        public override async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();
            var query = from book in queryable 
                        join author in await _authorRepository.GetQueryableAsync() on book.AuthorId equals author.Id
                        select new { book, author };
            //paging
            query = query.OrderBy(x => x.book.Name.Contains(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
            //exute query
            var queryResult = await AsyncExecuter.ToListAsync(query);
            //convert queryResult to List Book Object
            var bookDto = queryResult.Select(x => {
                var bookDto = ObjectMapper.Map<Book, BookDto>(x.book);
                bookDto.AuthorName = x.author.Name;
                return bookDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();
            return new PagedResultDto<BookDto>( totalCount, bookDto);
        }
        public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLoopkupAsync()
        {
            var authors = await _authorRepository.GetListAsync();
            return new ListResultDto<AuthorLookupDto>(ObjectMapper.Map<List<Author>, List<AuthorLookupDto>>(authors));
        }
        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrWhiteSpace())
            {
                return $"Book.{nameof(Book.Name)}";
            }
            if(sorting.Contains("authorName", StringComparison.OrdinalIgnoreCase)){
                return sorting.Replace("authorName", "author.Name", StringComparison.OrdinalIgnoreCase);
            }
            return $"Book.{sorting}";
        }
    }
}
