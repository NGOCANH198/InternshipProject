using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MISA.Web7.ASPNETCore.Application;
using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore.Infrastructure.Repository
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        #region Property

        #endregion

        #region Constructor
        public DepartmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Methods

        #endregion

    }
}
