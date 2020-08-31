using System.Collections.Generic;

namespace AppName.Core.Entities.Base
{
    public class PagedList<T> where T : class
    {
        public PagedList()
        {
            Data = new List<T>();
        }

        #region Properties
        /// <summary>
        /// The data result.
        /// </summary>
        public List<T> Data { get; set; }
        /// <summary>
        /// Total items count
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// Number of items contained in each page.
        /// </summary>
        public int PageSize { get; set; }

        #endregion
    }
}
