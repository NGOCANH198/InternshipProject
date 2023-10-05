using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore.Application
{
    public interface IBaseService<TEntityDto, TInsertDto, TUpdateDto> : IBaseReadOnlyService<TEntityDto>
    {

        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <param name="insertDto">thông tin bản ghi</param>
        /// <returns>bản ghi được thêm</returns>
        /// CreatedBy: nnanh - 17/9/23
        Task<TEntityDto> InsertAsync(TInsertDto insertDto);
        /// <summary>
        /// cập nhật bản ghi
        /// </summary>
        /// <param name="updateDto">thông tin bản ghi</param>
        /// <returns>bản ghi được thêm</returns>
        /// CreatedBy: nnanh - 17/9/23
        Task<TEntityDto> UpdateAsync(Guid id, TUpdateDto updateDto);
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id">id bản ghi</param>
        /// <returns>số lượng bản ghi thay đổi</returns>
        /// CreatedBy: nnanh - 17/9/23
        Task<int> DeleteAsync(Guid id);
        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách các mã bản ghi</param>
        /// <returns>số lượng bản ghi thay đổi</returns>
        /// CreatedBy: nnanh - 17/9/23
        Task<int> DeleteMultipleAsync(List<Guid> ids);
       
    }
}
