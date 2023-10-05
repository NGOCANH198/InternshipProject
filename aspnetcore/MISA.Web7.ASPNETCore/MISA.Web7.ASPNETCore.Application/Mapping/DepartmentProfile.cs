using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore.Application
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
        }
    }
}
