using acme.Bookstore.Authors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace acme.Bookstore.Books
{
    public interface IBookAppService: ICrudAppService<
        BookDto, Guid,
        PagedAndSortedResultRequestDto, CreateUpdateBookDto>
    {
        Task<AuthorLookupDto> GetAuthorLoopkupAsync();
    }
}
