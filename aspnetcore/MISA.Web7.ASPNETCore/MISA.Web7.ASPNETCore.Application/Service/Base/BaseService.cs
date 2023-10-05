using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore.Application
{
    public abstract class BaseService<TEntity, TEntityDto, TInsertDto, TUpdateDto> : BaseReadOnlyService<TEntity, TEntityDto>, IBaseService<TEntityDto, TInsertDto, TUpdateDto> where TEntity : IEntity
    {
        #region Constructor
        protected BaseService(IBaseRepository<TEntity> baseRepository) : base(baseRepository)
        {
        }
        #endregion

        #region Methods
        public async Task<TEntityDto> InsertAsync(TInsertDto insertDto)
        {
            await ValidateCreateBusiness(insertDto);

            var entity = MapInsertDtoToEntity(insertDto);

            if(entity.GetId() == Guid.Empty)
            {
                entity.SetId(Guid.NewGuid());
            }

            if(entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedBy = "lvanh";
                baseEntity.CreatedDate = DateTime.Now;
                baseEntity.ModifiedBy = "lvanh";
                baseEntity.ModifiedDate = DateTime.Now;
            }

            await BaseRepository.InsertAsync(entity);

            var entityDto = MapEntityToDto(entity);

            return entityDto;
        }

        public async Task<TEntityDto> UpdateAsync(Guid id, TUpdateDto updateDto)
        {
            var entity = await BaseRepository.GetAsync(id);

            await ValidateUpdateBusiness(updateDto);

            var newEntity = MapUpdateDtoToEntity(updateDto, entity);

            if(newEntity is BaseEntity baseEntity)
            {
                baseEntity.ModifiedBy = "lvanh";
                baseEntity.ModifiedDate = DateTime.Now;
                newEntity.SetId(id);
            }

            await BaseRepository.UpdateAsync(id, newEntity);

            var entityDto = MapEntityToDto(newEntity);

            return entityDto;

        }
        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await BaseRepository.GetAsync(id);

            var result = await BaseRepository.DeleteAsync(entity);

            return result;
        }

        public async Task<int> DeleteMultipleAsync(List<Guid> ids)
        {
            var entities = await BaseRepository.CheckListIdAsync(ids);

            var result = await BaseRepository.DeleteMultipleAsync(entities);

            return result;
        }

        public abstract TEntity MapInsertDtoToEntity(TInsertDto insertDto);
        public virtual async Task ValidateCreateBusiness(TInsertDto insertDto)
        {
            await Task.CompletedTask;
        }
        public abstract TEntity MapUpdateDtoToEntity(TUpdateDto updateDto, TEntity entity);
        public virtual async Task ValidateUpdateBusiness(TUpdateDto updateDto)
        {
            await Task.CompletedTask;
        } 
        
        #endregion
    }
}
