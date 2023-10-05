using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MISA.Web7.ASPNETCore.Application;
using MISA.Web7.ASPNETCore.Domain;
using MySqlConnector;

namespace MISA.Web7.ASPNETCore.Infrastructure
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {

        #region Property

        #endregion

        #region Constructor
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        #endregion

        #region Methods

        public async Task<string> GetNewEmployeeCodeAsync()
        {

            var procedure = "Proc_Employee_GetNewCode";

            var result = await UnitOfWork.Connection.QueryFirstAsync<string>(procedure, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            return result;
        }
        public async Task<List<Employee>> FilterEmployeeAsync(string searchKeyword, int currentPageNumber, int pageSize)
        {


            var procedure = "Proc_Employee_Filter";

            var param = new DynamicParameters();
            param.Add("searchKeyword", searchKeyword);
            param.Add("offsetParam", currentPageNumber);
            param.Add("limitParam", pageSize);
            var result = await UnitOfWork.Connection.QueryAsync<Employee>(procedure, param, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            return result.ToList();
        }



        public async Task<bool> IsDuplicatedEmployeeAsync(string employeeCode)
        {


            var query = "SELECT EmployeeCode FROM employee WHERE EmployeeCode = @EmployeeCodeParam";

            var param = new DynamicParameters();

            param.Add("@EmployeeCodeParam", employeeCode);

            var result = await UnitOfWork.Connection.QueryFirstOrDefaultAsync<string>(query, param, transaction: UnitOfWork.Transaction);
            if (result != null)
            {
                return true;
            }
            return false;
        }


        public async Task<bool> IsDepartmentIdValidAsync(Guid departmentId)
        {


            var query = "SELECT DepartmentId FROM Department WHERE DepartmentId = @DepartmentIdParam";

            var param = new { DepartmentIdParam = departmentId };

            var result = await UnitOfWork.Connection.QueryFirstOrDefaultAsync(query, param, transaction: UnitOfWork.Transaction);

            if (result != null)
            {
                return true;
            }
            return false;
        }



        public async Task<Pagination<List<Employee>>> PaginateEmployeeAsync(int currentPageNumber, int pageSize)
        {
            int maxPageSize = 50;

            pageSize = pageSize < maxPageSize ? pageSize : maxPageSize;

            int offSet = (currentPageNumber - 1) * pageSize;

            int limit = pageSize;

            var countQuery = "SELECT COUNT(*) FROM employee";

            var procdedure = "Proc_Employee_Paging";



            var param = new DynamicParameters();
            param.Add("@offsetParam", offSet);
            param.Add("@limitParam", limit);

            var totalCount = await UnitOfWork.Connection.ExecuteScalarAsync<int>(countQuery, transaction: UnitOfWork.Transaction);

            var employees = await UnitOfWork.Connection.QueryAsync<Employee>(procdedure, param, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            var result = new Pagination<List<Employee>>(totalCount, pageSize, currentPageNumber, employees.ToList());

            return result;
        }


        #endregion
    }
}
