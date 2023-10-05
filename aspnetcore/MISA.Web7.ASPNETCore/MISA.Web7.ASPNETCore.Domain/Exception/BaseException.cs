using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace MISA.Web7.ASPNETCore.Domain
{
    public class BaseException
    {
        #region Fields
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// Thông báo lỗi cho dev
        /// </summary>
        public string? DevMsg { get; set; }
        /// <summary>
        /// Thông báo lỗi cho người dùng
        /// </summary>
        public string? UserMsg { get; set; }
        /// <summary>
        /// Thông tin thêm về lỗi
        /// </summary>
        public string? MoreInfo { get; set; }
        /// <summary>
        /// Mã định danh theo dõi
        /// </summary>
        public string? TraceId { get; set; }
        /// <summary>
        /// Thông tin chi tiết về lỗi cho người dùng
        /// </summary>
        public object? Data { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Convert to json
        /// </summary>
        /// <returns>Chuỗi Json</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
        #endregion
    }
}
