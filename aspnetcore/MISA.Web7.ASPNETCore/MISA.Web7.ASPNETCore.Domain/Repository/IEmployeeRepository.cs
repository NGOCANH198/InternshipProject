using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web7.ASPNETCore.Domain
{
    /// <summary>
    /// Interface tương tác với Repository của Employee
    /// </summary>
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
   
        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: nnanh - 16/9/23
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
        Task<List<Employee>> FilterEmployeeAsync(string searchKeyword, int currentPageNumber, int pageSize);
     
        /// <summary>
        /// Kiêm tra mã nhân viên bị trùng
        /// </summary>
        /// <param name="employeeCode">mã định danh nhân viên</param>
        /// <returns>true: mã trùng, false, mã không trùng</returns>
        /// CreatedBy: nnanh - 16/9/23
        Task<bool> IsDuplicatedEmployeeAsync(string employeeCode);
        /// <summary>
        /// Kiểm tra mã phòng ban hợp lệ không
        /// </summary>
        /// <param name="departmentId">Mã phòng ban</param>
        /// <returns>true: hợp lệ, false: không hợp lệ</returns>
        /// CreatedBy: nnanh - 16/9/23
        Task<bool> IsDepartmentIdValidAsync(Guid departmentId);
       
    }
}
