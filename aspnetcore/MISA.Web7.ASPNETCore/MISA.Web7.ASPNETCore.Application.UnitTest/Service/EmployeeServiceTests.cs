using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MISA.Web7.ASPNETCore.Domain;
using NSubstitute;

namespace MISA.Web7.ASPNETCore.Application.UnitTest
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IEmployeeValidate EmployeeValidate { get; set; }
        public EmployeeService EmployeeService { get; set; }
        public IMapper Mapper { get; set; }


        [SetUp]
        public void SetUp()
        {
            EmployeeRepository = Substitute.For<IEmployeeRepository>();
            EmployeeValidate = Substitute.For<IEmployeeValidate>();
            Mapper = Substitute.For<IMapper>();
            EmployeeService = Substitute.For<EmployeeService>(EmployeeRepository, EmployeeValidate, Mapper);
        }
        /// <summary>
        /// Test hàm lấy tất cả nhân viên
        /// </summary>
        /// <returns>Thành công nếu luồng chạy đúng</returns>
        [Test]
        public async Task GetAllAsync_ValidStream_Success()
        {
            //Arrange
            var employeeDto = new EmployeeDto();
            var employee = new Employee();
            var employees = new List<Employee>();
            EmployeeRepository.GetAllAsync().Returns(employees);
            EmployeeService.MapEntityToDto(employee).Returns(employeeDto);

            //Act
            var employeeDtos = await EmployeeService.GetAllAsync();

            //Assert
            await EmployeeRepository.Received(1).GetAllAsync();
        }

        /// <summary>
        /// Test lấy một nhân viên
        /// </summary>
        /// <returns>Thành công nếu luồng chạy đúng</returns>
        [Test]
        public async Task GetAsync_ValidStream_Success()
        {
            //Arrange
            var employee = new Employee();
            var employeeDto = new EmployeeDto();

            EmployeeRepository.GetAsync(employee.EmployeeId).Returns(employee);
            EmployeeService.MapEntityToDto(employee).Returns(employeeDto);

            // Act
            _ = await EmployeeService.GetAsync(employee.EmployeeId);

            //Assert
            await EmployeeRepository.Received(1).GetAsync(employee.EmployeeId);
        }

        /// <summary>
        /// Test hàm thên nhân viên - trường hợp employeeId trống
        /// </summary>
        /// <returns>EmployeeId không còn trống</returns>
        [Test]
        public async Task InsertAsync_EmptyEmployeeId_ReturnIdNotEmpty()
        {
            //Arrange
            var employeeInsertDto = new EmployeeInsertDto();
            var employee = new Employee()
            {
                EmployeeId = Guid.Empty,
            };
            EmployeeService.MapInsertDtoToEntity(employeeInsertDto).Returns(employee);

            //Act

            await EmployeeService.InsertAsync(employeeInsertDto);

            //Arrange

            Assert.That(employee.EmployeeId, Is.Not.EqualTo(Guid.Empty));
        }

        /// <summary>
        /// Test hàm thên nhân viên - trường hợp tên người trống
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task InsertAsync_EmployeeAuditNull_EmployeeAuditNotNull()
        {
            //Arrange
            var employeeInsertDto = new EmployeeInsertDto();
            var employee = new Employee()
            {
                EmployeeId = Guid.Empty,
            };
            EmployeeService.MapInsertDtoToEntity(employeeInsertDto).Returns(employee);

            //Act
            await EmployeeService.InsertAsync(employeeInsertDto);

            //Assert
            Assert.That(employee.CreatedBy, Is.EqualTo("lvanh"));
            Assert.That(employee.ModifiedBy, Is.EqualTo("lvanh"));
        }

        /// <summary>
        /// Test hàm thêm nhân viên -  trường hợp các đầu vào hợp lệ
        /// </summary>
        /// <returns>Thành công nếu hợp lệ</returns>
        [Test]
        public async Task InsertAsync_ValidInput_Success()
        {
            //Arrange
            var employeeInsertDto = new EmployeeInsertDto();
            var employee = new Employee()
            {
                EmployeeId = Guid.Empty,
            };
            EmployeeService.MapInsertDtoToEntity(employeeInsertDto).Returns(employee);

            //Act 
            await EmployeeService.InsertAsync(employeeInsertDto);

            //Assert
            await EmployeeService.Received(1).ValidateCreateBusiness(employeeInsertDto);

            await EmployeeRepository.Received(1).InsertAsync(employee);
        }

        /// <summary>
        /// Test hàm thên nhân viên - trường hợp tên người trống
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task UpdateAsync_EmployeeAuditNull_EmployeeAuditNotNull()
        {
            //Arrange
            var employeeId = new Guid();
            var employeeUpdateDto = new EmployeeUpdateDto();
            var employee = new Employee();
            var newEmployee = new Employee();

            EmployeeRepository.GetAsync(employeeId).Returns(employee);

            EmployeeService.MapUpdateDtoToEntity(employeeUpdateDto, employee).Returns(newEmployee);

            //Act
            await EmployeeService.UpdateAsync(employeeId, employeeUpdateDto);

            //Assert
            Assert.That(newEmployee.EmployeeId, Is.EqualTo(employeeId));
            Assert.That(newEmployee.ModifiedBy, Is.EqualTo("lvanh"));
        }

        /// <summary>
        /// Test hàm thêm nhân viên -  trường hợp các đầu vào hợp lệ
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task UpdateAsync_ValidInput_Success()
        {
            //Arrange
            var employeeId = new Guid();
            var employeeUpdateDto = new EmployeeUpdateDto();
            var employee = new Employee();
            var newEmployee = new Employee();

            EmployeeRepository.GetAsync(employeeId).Returns(employee);

            EmployeeService.MapUpdateDtoToEntity(employeeUpdateDto, employee).Returns(newEmployee);

            //Act
            await EmployeeService.UpdateAsync(employeeId, employeeUpdateDto);

            //Assert
            await EmployeeService.Received(1).ValidateUpdateBusiness(employeeUpdateDto);

            await EmployeeRepository.Received(1).UpdateAsync(employeeId, newEmployee);
        }

        /// <summary>
        /// Test hàm xóa nhân viên 
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task DeleteAsync_ValidInput_Success()
        {
            //Arrange
            var id = new Guid();
            var employee = new Employee();
            EmployeeRepository.GetAsync(id).Returns(employee);

            //Act
            await EmployeeService.DeleteAsync(id);

            //Assert

            await EmployeeRepository.Received(1).GetAsync(id);
            await EmployeeRepository.Received(1).DeleteAsync(employee);
        }

        /// <summary>
        /// Test hàm xóa nhiều nhân viên 
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task DeleteMuptipleAsync_ValidInput_Success()
        {
            //Arrange
            var ids = new List<Guid>();
            var employees = new List<Employee>();
            EmployeeRepository.CheckListIdAsync(ids).Returns(employees);

            //Act
            await EmployeeService.DeleteMultipleAsync(ids);

            //Assert

            await EmployeeRepository.Received(1).CheckListIdAsync(ids);
            await EmployeeRepository.Received(1).DeleteMultipleAsync(employees);
        }

        /// <summary>
        /// Test hàm lấy mã nhân viên mới
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetNewEmployeeCodeAsync_ValidStream_Success()
        {
            //Arrange


            //Act
            await EmployeeService.GetNewEmployeeCodeAsync();

            //Assert
            await EmployeeRepository.Received(1).GetNewEmployeeCodeAsync();
        }

        /// <summary>
        /// Test hàm lọc nhân viên
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task FilterEmployeeAsync_ValidStream_Success()
        {
            //Arrange
            var searchKeyword = "";
            var currentNumber = 1;
            var pageSize = 10;
            var employees = new List<Employee>();
            var employeeDto = new EmployeeDto();
            EmployeeRepository.FilterEmployeeAsync(searchKeyword, currentNumber, pageSize).Returns(employees);
            _ = employees.Select(employee => EmployeeService.MapEntityToDto(employee));

            //Act
            await EmployeeService.FilterEmployeeAsync(searchKeyword, currentNumber, pageSize);

            //Assert

            await EmployeeRepository.Received(1).FilterEmployeeAsync(searchKeyword, currentNumber, pageSize);
        }
    }
}
