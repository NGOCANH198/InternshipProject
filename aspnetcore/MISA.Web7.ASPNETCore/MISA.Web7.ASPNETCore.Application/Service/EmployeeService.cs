using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.Charts;
using MISA.Web7.ASPNETCore.Domain;
using System.Data;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace MISA.Web7.ASPNETCore.Application
{
    public class EmployeeService : BaseService<Employee,EmployeeDto,EmployeeInsertDto,EmployeeUpdateDto>,    IEmployeeService
    {
        #region Property
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeValidate _employeeValidate;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeValidate employeeValidate, IMapper mapper) : base(employeeRepository) 
        {
            _employeeRepository = employeeRepository;
            _employeeValidate = employeeValidate;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        
        public async Task<string> GetNewEmployeeCodeAsync()
        {
            var newEmployeeCode = await _employeeRepository.GetNewEmployeeCodeAsync();

            return newEmployeeCode;
        }
        public async Task<Pagination<List<Employee>>> PaginateEmployeeAsync(int currentPageNumber, int pageSize)
        {
            var employees = await _employeeRepository.PaginateEmployeeAsync(currentPageNumber, pageSize);
            return employees;

        }
        public async Task<List<EmployeeDto>> FilterEmployeeAsync(string searchKeyword, int currentPageNumber, int pageSize)
        {
            var employees = await _employeeRepository.FilterEmployeeAsync(searchKeyword, currentPageNumber, pageSize);

            var employeeDtos = employees.Select(employee => MapEntityToDto(employee)).ToList();

            return employeeDtos;
        }

        public override async Task ValidateCreateBusiness(EmployeeInsertDto insertDto)
        {
            await _employeeValidate.CheckEmployeeDuplicatedAsync(insertDto.EmployeeCode);

            await _employeeValidate.CheckValidDepartmentIdAsync(insertDto.DepartmentId);

            
        }

        public override async Task ValidateUpdateBusiness(EmployeeUpdateDto updateDto)
        {
            await _employeeValidate.CheckValidDepartmentIdAsync(updateDto.DepartmentId);

        }

        public async Task<System.Data.DataTable> ExportExcelAsync()
        {
            var employeeData = await GetEmpData();

            return employeeData;
        }
        public async Task<System.Data.DataTable> GetEmpData()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.TableName = "Danh sách nhân viên";
            dt.Columns.Add("Mã nhân viên", typeof(string));
            dt.Columns.Add("Họ và tên", typeof(string));
            dt.Columns.Add("Giới tính", typeof(string));
            dt.Columns.Add("Ngày sinh", typeof(string));
            dt.Columns.Add("Phòng ban", typeof(string));
            dt.Columns.Add("Căn cước", typeof(string));
            dt.Columns.Add("Ngày cấp", typeof(string));
            dt.Columns.Add("Nơi cấp", typeof(string));
            dt.Columns.Add("Chức danh", typeof(string));
            dt.Columns.Add("Địa chỉ", typeof(string));
            dt.Columns.Add("Điện thoại di động", typeof(string));
            dt.Columns.Add("Điện thoại bàn", typeof(string));
            dt.Columns.Add("Địa chỉ email", typeof(string));
            dt.Columns.Add("Tài khoản ngân hàng", typeof(string));
            dt.Columns.Add("Tên ngân hàng", typeof(string));
            dt.Columns.Add("Chi nhánh", typeof(string));

            var employees = await _employeeRepository.GetAllAsync();
            if (employees.Count > 0)
            {
                employees.ForEach(employee => dt.Rows.Add(employee.EmployeeCode, employee.FullName, employee.Gender, employee.DateOfBirth, employee.DepartmentName, employee.IdentificationCode, employee.SupplyDate, employee.SupplyPlace, employee.WorkPosition, employee.Address, employee.ContactPhone, employee.ContactLandLine, employee.ContactEmail, employee.BankAccount, employee.BankName, employee.BankPlace));
            }

            return dt;
        }

        public override Employee MapInsertDtoToEntity(EmployeeInsertDto insertDto)
        {
            var employee = _mapper.Map<Employee>(insertDto);

            return employee;
        }

        public override Employee MapUpdateDtoToEntity(EmployeeUpdateDto updateDto, Employee oldEmployee)
        {
            var newEmployee = _mapper.Map(updateDto, oldEmployee); 

            return newEmployee;
        }

        public override EmployeeDto MapEntityToDto(Employee entity)
        {
            var employeeDto = _mapper.Map<EmployeeDto>(entity);

            return employeeDto;
        }
        #endregion
    }
}
