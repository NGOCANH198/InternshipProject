using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace MISA.Web7.ASPNETCore.Domain.UnitTest
{
    [TestFixture]
    public class EmployeeValidateTests
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IEmployeeValidate EmployeeValidate { get; set; }
        public Employee Employee { get; set; }
        [SetUp]
        public void SetUp()
        {
            EmployeeRepository = Substitute.For<IEmployeeRepository>();
            EmployeeValidate = new EmployeeValidate(EmployeeRepository);
            Employee = new Employee();
        }

        /// <summary>
        /// Test hàm kiểm tra trùng mã nhân viên
        /// </summary>
        /// <returns>Thành công nếu không bị trùng</returns>
        [Test]
        public async Task CheckEmployeeDuplicatedAsync_NotDuplicatedEmployee_Success()
        {
            //Arrange

            EmployeeRepository.IsDuplicatedEmployeeAsync(Employee.EmployeeCode).Returns(false);

            //Act
            await EmployeeValidate.CheckEmployeeDuplicatedAsync(Employee.EmployeeCode);

            //Asert
            await EmployeeRepository.Received(1).IsDuplicatedEmployeeAsync(Employee.EmployeeCode);
        }

        /// <summary>
        /// Test hàm kiểm tra trùng mã nhân viên
        /// </summary>
        /// <returns>Lỗi nếu  bị trùng</returns>
        [Test]
        public async Task CheckEmployeeDuplicatedAsync_DuplicatedEmployee_ThrowException()
        {

            //Arrange

            EmployeeRepository.IsDuplicatedEmployeeAsync(Employee.EmployeeCode).Returns(true);

            //Act & Assert
            var exception = Assert.ThrowsAsync<ConflictException>(async () => await EmployeeValidate.CheckEmployeeDuplicatedAsync(Employee.EmployeeCode));

            await EmployeeRepository.Received(1).IsDuplicatedEmployeeAsync(Employee.EmployeeCode);

            Assert.That(exception.ErrorCode, Is.EqualTo((int)Conflict.DuplicatedEmployeeCode));
        }

        /// <summary>
        /// Kiểm tra tên phòng ban có hợp lệ không
        /// </summary>
        /// <returns>Lỗi nếu không hợp lệ</returns>
        [Test]
        public async Task CheckValidDepartmentIdAsync_NotValidId_ThrowException()
        {
            //Arrange
            EmployeeRepository.IsDepartmentIdValidAsync(Employee.DepartmentId).Returns(false);

            //
            //Act & Assert
            var exception = Assert.ThrowsAsync<ValidateException>(async () => await EmployeeValidate.CheckValidDepartmentIdAsync(Employee.DepartmentId));

            await EmployeeRepository.Received(1).IsDepartmentIdValidAsync(Employee.DepartmentId);

            Assert.That(exception.ErrorCode, Is.EqualTo((int)Validate.DepartmentIdNotValid));
        }

        /// <summary>
        /// Kiểm tra tên phòng ban có hợp lệ không
        /// </summary>
        /// <returns>Thành công nếu hợp lệ</returns>
        [Test]
        public async Task CheckValidDerpartmentIdAsync_ValidId_Success()
        {
            //Arrange
            EmployeeRepository.IsDepartmentIdValidAsync(Employee.DepartmentId).Returns(true);

            //Act 
            await EmployeeValidate.CheckValidDepartmentIdAsync(Employee.DepartmentId);

            //Assert
            await EmployeeRepository.Received(1).IsDepartmentIdValidAsync(Employee.DepartmentId);

        }
    }
}
