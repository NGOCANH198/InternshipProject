using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore.Application
{
    public interface IEmployeeService : IBaseService<EmployeeDto, EmployeeInsertDto, EmployeeUpdateDto>
    {
        
       /// <summary>
        /// Lấy mã code mới
        /// </summary>
        /// <returns>mã code</returns>
        /// CreatedBy: nnanh - 17/9/23
        Task<string> GetNewEmployeeCodeAsync();
        /// <summary>
        /// Phân trang danh sách nhân viên
        /// </summary>
        /// <param name="currentPageNumber">Số trang hiện tại</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: nnanh - 17/9/23
        Task<Pagination<List<Employee>>> PaginateEmployeeAsync(int currentPageNumber, int pageSize);
        /// <summary>
        /// Tìm kiến nhân viên
        /// </summary>
        /// <param name="searchKeyword">Từ khóa tìm kiếm</param>
        /// <returns>Các nhân viên khớp với từ khóa</returns>
        /// CreatedBy: nnanh - 18/9/23
        Task<List<EmployeeDto>> FilterEmployeeAsync(string searchKeyword, int currentPageNumber, int pageSize);
      
        /// <summary>
        /// Export to excel
        /// </summary>
        /// <returns>File excel</returns>
        /// CreatedBy: nnanh - 18/9/23
        Task<DataTable> ExportExcelAsync();
    }
}
