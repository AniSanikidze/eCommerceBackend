using Mapster;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Common.Paging
{
    public class PagedResult<TResult>
    {
        private static int _pageSize = 10;
        private static int _page = 1;
        public List<TResult> Items { get; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public PagedResult(List<TResult> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public static async Task<PagedResult<TResult>> CreateAsync<TEntity>(IQueryable<TEntity> source, int? Page, int? PageSize)
        {
            var pageNumber = Page ?? _page;
            var pageSize = PageSize ?? _pageSize;

            var count = await source.CountAsync();
            var itemsQuery = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new PagedResult<TResult>(await itemsQuery.ProjectToType<TResult>().ToListAsync(), count, pageNumber, pageSize);
        }
    }
}
