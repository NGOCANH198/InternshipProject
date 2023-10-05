using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using ClosedXML.Excel;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web7.ASPNETCore.Application;
using MISA.Web7.ASPNETCore.Controllers;
using MySqlConnector;

namespace MISA.Web7.ASPNETCore
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<EmployeeDto,EmployeeInsertDto,EmployeeUpdateDto>
    {

        #region Property
        private readonly IEmployeeService _employeService;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeService = employeeService;
        }
        #endregion

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        [HttpGet]
        [Route("NewEmployeeCode")]
        public async Task<string> GetNewEmployeeCodeAsync()
        {
            var result = await _employeService.GetNewEmployeeCodeAsync();

            return result;
        }
        /// <summary>
        /// Phân trang nhân viên
        /// </summary>
        /// <param name="currentPageNumber">trang hiện tại</param>
        /// <param name="pageSize">kích thước trang</param>
        /// <returns>danh sách nhân viên</returns>
        /// CreatedBy: nnanh - 17/9/23
        [HttpGet]
        [Route("Pagination")]
        public async Task<IActionResult> PaginateEmployeeAsync(int currentPageNumber, int pageSize)
        {
            var result = await _employeService.PaginateEmployeeAsync(currentPageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet]
        [Route("Searching")]
        public async Task<List<EmployeeDto>> FilterEmployeeAsync([FromQuery] string? searchKeyword, int currentPageNumber = 1, int pageSize = 10)
        {
            if(string.IsNullOrEmpty(searchKeyword))
            {
                searchKeyword = " ";
            }

            var result = await _employeService.FilterEmployeeAsync(searchKeyword, currentPageNumber, pageSize);

            return result;
        }

        [HttpGet("ExportExcel")]
        public async Task<IActionResult> ExportExcel()
        {
            var employeeData = await _employeService.ExportExcelAsync();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.AddWorksheet(employeeData, "Danh sách nhân viên");
                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employees.xlsx");
                }
            }
            
        }
    }
}
