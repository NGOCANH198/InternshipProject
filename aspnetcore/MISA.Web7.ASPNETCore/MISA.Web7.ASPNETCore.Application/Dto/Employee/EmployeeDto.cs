using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore.Application
{
    public class EmployeeDto
    {
        #region Fields
        /// <summary>
        /// Mã định danh nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã số nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Họ và tên 
        /// </summary>

        public string FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender? Gender { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Căn cước công dân
        /// </summary>
        public string? IdentificationCode { get; set; }
        /// <summary>
        /// Ngày cấp căn cước
        /// </summary>
        public DateTime? SupplyDate { get; set; }
        /// <summary>
        /// Nơi cấp căn cước
        /// </summary>
        public string? SupplyPlace { get; set; }
        /// <summary>
        /// Vị trí làm việc
        /// </summary>
        public string? WorkPosition { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        public string? ContactPhone { get; set; }
        /// <summary>
        /// Số điện thoại bàn
        /// </summary>
        public string? ContactLandLine { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string ContactEmail { get; set; }
        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        public string? BankAccount { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }
        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        public string? BankPlace { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; } 
        #endregion
    }
}
