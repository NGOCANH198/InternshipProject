namespace MISA.Web7.ASPNETCore.Domain
{
    public class Department : BaseEntity, IEntity
    {
        #region Fields
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }


        #endregion

        #region Methods
        public Guid GetId()
        {
            return DepartmentId;
        }

        public void SetId(Guid id)
        {
            DepartmentId = id;
        } 
        #endregion

    }
}
