using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web7.ASPNETCore.Domain
{
    public interface IEmployeeValidate
    {
        /// <summary>
        /// Kiểm tra employeeCode có bị trùng không
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <exception cref="ConflictException">Nếu bị trùng</exception>
        /// <returns></returns>
        Task CheckEmployeeDuplicatedAsync(string employeeCode);
        /// <summary>
        /// Kiểm tra mã phòng ban hợp lệ không
        /// </summary>
        /// <param name="departmentId">Mã phòng ban</param>
        /// <exception cref="ValidateException">Nếu không hợp lệ</exception>
        /// <returns></returns>
        Task CheckValidDepartmentIdAsync(Guid departmentId);
    }
}
