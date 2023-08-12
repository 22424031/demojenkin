using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace acme.Bookstore.Authors
{
    public class GetAuthorListDto:PagedAndSortedResultRequestDto
    {
        public string filter { get; set; }
    }
}
