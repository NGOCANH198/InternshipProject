using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore.Application
{
    public class EmployeeInsertDto 
    {
        #region Fields
        /// <summary>
        /// Mã số nhân viên
        /// </summary>
        [MaxLength(20, ErrorMessage ="Mã không được quá 20 ký tự")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Mã không được để trống")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Họ và tên 
        /// </summary>
        [MaxLength(100, ErrorMessage ="Tên không được quá 100 ký tự")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được để trống")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender? Gender { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        [ValidDateTime(ErrorMessage = "Ngày phải nhỏ hơn ngày hiện tại")]
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Căn cước công dân
        /// </summary>
        [MaxLength(25, ErrorMessage ="Số căn cước không được quá 25 ký tự")]
        public string? IdentificationCode { get; set; }
        /// <summary>
        /// Ngày cấp căn cước
        /// </summary>
        [ValidDateTime(ErrorMessage = "Ngày phải nhỏ hơn ngày hiện tại")]
        public DateTime? SupplyDate { get; set; }
        /// <summary>
        /// Nơi cấp căn cước
        /// </summary>
        [MaxLength(255)]
        public string? SupplyPlace { get; set; }
        /// <summary>
        /// Vị trí làm việc
        /// </summary>
        [MaxLength(255)]
        public string? WorkPosition { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [MaxLength(255)]
        public string? Address { get; set; }
        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        [MaxLength(50, ErrorMessage ="Số điện thoại không được quá 50 ký tự")]
        public string? ContactPhone { get; set; }
        /// <summary>
        /// Số điện thoại bàn
        /// </summary>
        [MaxLength(50, ErrorMessage = "Số điện thoại không được quá 50 ký tự")]
        public string? ContactLandLine { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [MaxLength(100, ErrorMessage ="Email không được quá 100 ký tự")]
        [EmailAddress(ErrorMessage ="Email không đúng định dạng")]
        public string ContactEmail { get; set; }
        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        [MaxLength(25)]
        public string? BankAccount { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        [MaxLength(255)]
        public string? BankName { get; set; }
        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        [MaxLength(255)]
        public string? BankPlace { get; set; }
        #endregion
    }
}
