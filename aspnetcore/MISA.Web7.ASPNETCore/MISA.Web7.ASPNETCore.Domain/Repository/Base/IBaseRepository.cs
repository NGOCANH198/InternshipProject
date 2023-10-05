using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web7.ASPNETCore.Domain
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// CreatedBy: nnanh - 16/9/23
        Task<List<TEntity>> GetAllAsync();
        /// <summary>
        /// hàm lấy một bản ghi
        /// </summary>
        /// <param name="id">Mã định danh</param>
        /// <exception cref="NotFoundException">Khi không tìm thấy</exception>
        /// <returns>Một bản ghi</returns>
        /// CreatedBy: nnanh - 16/9/23
        Task<TEntity> GetAsync(Guid id);
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns>Số lượng bản ghi thay đổi</returns>
        /// CreatedBy: nnanh - 16/9/23
        Task<int> InsertAsync(TEntity entity);
        /// <summary>
        /// cập nhật bản ghi
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns>Số lượng bản ghi thay đổi</returns>
        /// CreatedBy: nnanh - 16/9/23
        Task<int> UpdateAsync(Guid entityId, TEntity entity);
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns>Số lượng bản ghi thay đổi</returns>
        /// CreatedBy: nnanh - 16/9/23
        Task<int> DeleteAsync(TEntity entity);
        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách mã bản ghi</param>
        /// <returns>Số lượng bản ghi thay đổi</returns>
        /// CreatedBy: nnanh - 17/9/23
        Task<int> DeleteMultipleAsync(List<TEntity> entities);
        /// <summary>
        /// Kiểm tra các mã nhân viên có hợp lệ không
        /// </summary>
        /// <param name="employeeIds">danh sách mã nhân viên</param>
        /// <returns>danh sách mã hợp lệ</returns>
        Task<List<TEntity>> CheckListIdAsync(List<Guid> ids);

    }
}
