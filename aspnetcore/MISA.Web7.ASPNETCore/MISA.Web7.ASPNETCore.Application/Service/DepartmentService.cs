using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore.Application
{
    public class DepartmentService : BaseReadOnlyService<Department, DepartmentDto>, IDepartmentService
    {
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper) : base(departmentRepository)
        {
            _mapper = mapper;
        }

        public override DepartmentDto MapEntityToDto(Department entity)
        {
            var departmentDto = _mapper.Map<DepartmentDto>(entity);
            return departmentDto;
        }
    }
}
