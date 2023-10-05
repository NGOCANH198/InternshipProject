using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web7.ASPNETCore.Application
{
    public interface IBaseReadOnlyService<TEntityDto>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>danh sách bản ghi</returns>
        /// CreatedBy: nnanh - 17/9/23
        Task<List<TEntityDto>> GetAllAsync();
        /// <summary>
        /// Lấy một bản ghi theo id
        /// </summary>
        /// <param name="id">id bản ghi</param>
        /// <returns>thông tin bản ghi</returns>
        /// CreatedBy: nnanh - 17/9/23
        Task<TEntityDto> GetAsync(Guid id);
    }
}
