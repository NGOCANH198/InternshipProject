using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web7.ASPNETCore.Domain
{
    public class Pagination<T> where T: class
    {
        #region Fields
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int ToTalCount { get; set; }
        /// <summary>
        /// Kích thước trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Số trang hiện tại
        /// </summary>
        public int CurrentPageNumber { get; set; }
        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// trang sau  
        /// </summary>
        public bool HasPreviousPage { get; set; }
        /// <summary>
        /// trang trước
        /// </summary>
        public bool HasNextPage { get; set; } 
        /// <summary>
        /// Dữ liệu
        /// </summary>
        public T Data { get; set; }
        #endregion

        public Pagination(int totalCount, int pageSize, int currentPageNumber, T data) 
        { 
            ToTalCount = totalCount;

            Data = data;

            CurrentPageNumber = currentPageNumber;

            PageSize = pageSize;

            TotalPages = (int)Math.Ceiling((double)ToTalCount/PageSize);

            HasPreviousPage = CurrentPageNumber > 1;

            HasNextPage = CurrentPageNumber < TotalPages;
        }
    }
}
