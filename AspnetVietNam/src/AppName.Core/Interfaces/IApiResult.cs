using System.Collections.Generic;

namespace AppName.Core.Interfaces
{
    public interface IApiResult<T>
    {
        #region Properties
        /// <summary>
        /// The data result.
        /// </summary>
        public List<T> Data { get; }

        /// <summary>
        /// Zero-based index of current page.
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// Number of items contained in each page.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Total items count
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Total pages count
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// TRUE if the current page has a previous page, FALSE otherwise.
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        /// <summary>
        /// TRUE if the current page has a next page, FALSE otherwise.
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return ((PageIndex + 1) < TotalPages);
            }
        }

        /// <summary>
        /// Sorting Column name (or null if none set)
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// Sorting Order ("ASC", "DESC" or null if none set)
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// Filter Column name (or null if none set)
        /// </summary>
        public string FilterColumn { get; set; }

        /// <summary>
        /// Filter Query string 
        /// (to be used within the given FilterColumn)
        /// </summary>
        public string FilterQuery { get; set; }
        #endregion
    }
}
