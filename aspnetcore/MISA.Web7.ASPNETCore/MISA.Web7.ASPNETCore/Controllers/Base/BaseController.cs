using Microsoft.AspNetCore.Mvc;
using MISA.Web7.ASPNETCore.Application;

namespace MISA.Web7.ASPNETCore.Controllers
{
    public class BaseController<TEntityDto, TInsertDto, TUpdateDto> : BaseReadOnlyController<TEntityDto>
    {
        protected readonly IBaseService<TEntityDto, TInsertDto, TUpdateDto> BaseService;

        public BaseController(IBaseService<TEntityDto, TInsertDto, TUpdateDto> baseService) : base(baseService)
        {
            BaseService = baseService;
        }
        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>
        /// 201:  thêm mới thành công - số lượng dòng bị thay đổi
        /// 400: Dữ liệu không hợp lệ
        /// 500: Lỗi hệ thống
        /// </returns>
        /// CreatedBy: nnanh - 10/9/23
        [HttpPost]
        public async Task<IActionResult> InsertAsync(TInsertDto insertDto)
        {
            var result = await BaseService.InsertAsync(insertDto);

            return StatusCode(201, result);

        }

        /// <summary>
        /// Sửa thông tin một nhân viên theo EmployeeId
        /// </summary>
        /// <param name="employeeUpdateDto">Thông tin nhân viên</param>
        /// <returns>
        /// 200 - Sửa thành công
        /// 400 - Dữ liệu thay đôi không hợp lệ
        /// 500 - Lỗi hệ thống
        /// </returns>
        /// CreatedBy: nnanh - 10/9/23
        [HttpPut]
        [Route("{id}")]
        public async Task<TEntityDto> UpdateAsync(Guid id, TUpdateDto updateDto)
        {
            var result = await BaseService.UpdateAsync(id, updateDto);

            return result;
        }

        /// <summary>
        /// Xóa một nhân viên
        /// </summary>
        /// <param name="employeeId">Mã định danh nhân viên</param>
        /// <returns>
        /// Số lượng dòng bị thay đôi
        /// 404: nếu không tìm thấy mã nhân viên cần xóa
        /// 500: Lỗi hệ thống
        /// </returns>
        /// CreatedBy: nnanh - 10/9/23
        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteAsync(Guid id)
        {
            var result = await BaseService.DeleteAsync(id);

            return result;
        }

        /// <summary>
        /// Xóa nhiều nhân viên
        /// </summary>
        /// <param name="employeeIds">Danh sách mã nhân viên</param>
        /// <returns>
        /// 200: Xóa thành công
        /// 500: Lỗi hệ thống
        /// </returns>
        /// CreatedBy: nnanh - 17/9/23
        [HttpDelete]
        public async Task<int> DeleteMultipleAsync(List<Guid> ids)
        {
            var result = await BaseService.DeleteMultipleAsync(ids);
            return result;

        }
    }
}
