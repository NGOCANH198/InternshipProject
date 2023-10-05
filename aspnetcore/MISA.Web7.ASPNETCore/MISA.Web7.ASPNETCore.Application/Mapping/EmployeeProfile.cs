using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore.Application
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeInsertDto, Employee>();

            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}
