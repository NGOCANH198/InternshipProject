using Microsoft.AspNetCore.Mvc;
using MISA.Web7.ASPNETCore.Application;

namespace MISA.Web7.ASPNETCore.Controllers
{ 
    public class BaseReadOnlyController<TEntityDto> : ControllerBase
    {
        protected readonly IBaseReadOnlyService<TEntityDto> BaseReadOnlyService;

        public BaseReadOnlyController(IBaseReadOnlyService<TEntityDto> baseReadOnlyService)
        {
            BaseReadOnlyService = baseReadOnlyService;
        }


        /// <summary>
        /// Lấy dữ liệu thông tin các nhân viên
        /// </summary>
        /// <returns>
        /// Danh sách nếu thành công
        /// Lỗi 500 - nêu không thành công
        /// </returns>
        /// CreatedBy: nnanh 8/9/23
        [HttpGet]
        public async Task<List<TEntityDto>> GetAllAsync()
        {
            var result = await BaseReadOnlyService.GetAllAsync();

            return result;
        }
        /// <summary>
        /// Lấy thông tin nhân viên theo EmployeeId
        /// </summary>
        /// <param name="employeeId">Mã định danh nhân viên</param>
        /// <returns>
        /// Thông tin nhân viên nếu tìm thấy
        /// Lỗi 404: Nếu không tồn tại mã nhân viên
        /// Lỗi 500: Lỗi hệ thống
        /// </returns>
        /// CreatedBy: nnanh - 8/9/23
        [HttpGet]
        [Route("{id}")]
        public async Task<TEntityDto?> GeteAsync(Guid id)
        {
            var result = await BaseReadOnlyService.GetAsync(id);

            return result;
        }
    }
}
