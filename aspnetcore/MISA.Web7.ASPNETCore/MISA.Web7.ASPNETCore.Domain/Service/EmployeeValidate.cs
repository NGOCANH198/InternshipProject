using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore.Domain
{
    /// <summary>
    /// Validate nghiệp vụ
    /// </summary>
    public class EmployeeValidate : IEmployeeValidate
    {
        #region Property
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public EmployeeValidate(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Methods
        public async Task CheckEmployeeDuplicatedAsync(string employeeCode)
        {
            var isDuplicatedEmployee = await _employeeRepository.IsDuplicatedEmployeeAsync(employeeCode);

            if (isDuplicatedEmployee)
            {
                throw new ConflictException(string.Format(Resources.ResourceVN.EmployeeCodeDuplicated, employeeCode), (int)Conflict.DuplicatedEmployeeCode);
            }
        }

        public async Task CheckValidDepartmentIdAsync(Guid departmentId)
        {
           var isDepartmentIdValid = await _employeeRepository.IsDepartmentIdValidAsync(departmentId);
           if (!isDepartmentIdValid)
            {
                throw new ValidateException(Resources.ResourceVN.DepartmentNameNotValid, (int)Validate.DepartmentIdNotValid);
            }
        }

        #endregion
    }
}
