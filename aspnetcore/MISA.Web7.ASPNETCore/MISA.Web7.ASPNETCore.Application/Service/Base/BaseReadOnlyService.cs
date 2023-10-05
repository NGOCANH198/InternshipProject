using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore.Application
{
    public abstract class BaseReadOnlyService<TEntity,TEntityDto> : IBaseReadOnlyService<TEntityDto>
    {
        #region Property
        protected readonly IBaseRepository<TEntity> BaseRepository;
        #endregion

        #region Constructor
        protected BaseReadOnlyService(IBaseRepository<TEntity> baseRepository)
        {
            BaseRepository = baseRepository;
        }
        #endregion

        #region Methods
        public async Task<List<TEntityDto>> GetAllAsync()
        {
            var entitties = await BaseRepository.GetAllAsync();

            var result = entitties.Select(entity => MapEntityToDto(entity)).ToList();

            return result;
        }

        public async Task<TEntityDto> GetAsync(Guid id)
        {
            var entity = await BaseRepository.GetAsync(id);

            var result = MapEntityToDto(entity);

            return result;
        }
     
        public abstract TEntityDto MapEntityToDto(TEntity entity); 

        #endregion
    }
}
