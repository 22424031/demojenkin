using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace acme.Bookstore.Authors
{
    public interface IAuthorAppService:IApplicationService
    {
        Task<AuthorDto> GetAsync(Guid id);
        Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input);
        Task DeleteAsync(Guid id);
        Task<AuthorDto> CreateAsync(CreateAuthorDto input); 
        Task UpDateAsync(Guid id, CreateAuthorDto input);
        
    }
}
