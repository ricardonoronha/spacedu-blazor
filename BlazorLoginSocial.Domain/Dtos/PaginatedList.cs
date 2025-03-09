using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLoginSocial.Domain.Dtos
{
    public class PaginatedList<T>(int pageIndex, int pageSize, IEnumerable<T> data, int totalItems, int totalPages)
    {
        public int PageIndex { get; private set; } = pageIndex;
        public int PageSize { get; private set; } = pageSize;
        public IEnumerable<T> Data { get; set; } = data;
        public int TotalItems { get; private set; } = totalItems;
        public int TotalPages { get; private set; } = totalPages;
        public int[] GetVisiblePages()
        {
            var nearPages = new List<int>();

            for (int i = PageIndex - 2; i <= TotalPages; i++)
            {
                if (i < 0) continue;

                nearPages.Add(i);

                if (nearPages.Count == 5) break;
            }

            return [.. nearPages];
        }
    }
}
