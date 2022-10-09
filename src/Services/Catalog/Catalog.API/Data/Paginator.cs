using System.Collections.Generic;
namespace Catalog.API.Data
{
    public class Paginator<T>
    {

        public Paginator(int page, int pageSize, int totalCount)
        {
            this.Page = page;
            this.PageSize = pageSize;
            this.ItemTotalCount = totalCount;
        }

        public int Page { get; set; }

        public int PageSize { get; set; }
        
        public IEnumerable<T> Items { get; set; }

        public int ItemTotalCount { get; set; }

        public bool HasNext { get; set; }

        public bool HasPrevious { get; set; }

        public int PageTotalCount 
        { 
            get
            {
                // Sanity Check
                if (this.PageSize == 0)
                {
                    return 1;
                }

                int pageCount = ItemTotalCount / this.PageSize;

                pageCount += this.ItemTotalCount % this.PageSize > 0 ? 1 : 0;

                return pageCount == 0 ? 1 : pageCount;
            }
        }

        public override string ToString()
        {
            return $"Page: {this.Page}, PageSize: {this.PageSize}, PageTotalCount: {this.PageTotalCount}";
        }
    }
}
