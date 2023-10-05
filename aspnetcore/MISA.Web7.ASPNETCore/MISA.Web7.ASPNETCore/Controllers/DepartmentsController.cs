using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web7.ASPNETCore.Application;
using MISA.Web7.ASPNETCore.Domain;
using MySqlConnector;

namespace MISA.Web7.ASPNETCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseReadOnlyController<DepartmentDto>
    {
        
        private readonly IDepartmentService _departmentsService;

        public DepartmentsController(IDepartmentService departmentsService) : base(departmentsService) 
        {
            _departmentsService = departmentsService;
        }






    }

}
