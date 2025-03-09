using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLoginSocial.Domain.Dtos
{
    public class PaginatedSearchDto<TFilter>(TFilter filter, int pageIndex, int pageSize)
    {
        public TFilter Filter { get; set; } = filter;
        public int PageIndex { get; set; }  = pageIndex;
        public int PageSize { get; set; } = pageSize;
    }
}
