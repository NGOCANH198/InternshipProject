using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MISA.Web7.ASPNETCore.Application;
using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IEntity
    {
        #region Properties

        protected readonly IUnitOfWork UnitOfWork;

        public virtual string TableName { get; set; } = typeof(TEntity).Name;
        #endregion

        #region Constructor
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public async Task<List<TEntity>> GetAllAsync()
        {


            var procedure = $"Proc_{TableName}_GetAll";

            var result = await UnitOfWork.Connection.QueryAsync<TEntity>(procedure, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            return result.ToList();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {


            var procedure = $"Proc_{TableName}_GetOne";

            var param = new DynamicParameters();
            param.Add($"{TableName}IdParam", id);

            var result = await UnitOfWork.Connection.QueryFirstOrDefaultAsync<TEntity>(procedure, param, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            if (result == null)
            {
                throw new NotFoundException(string.Format(Domain.Resources.ResourceVN.ResourcesNotFound, id));
            }

            return result;
        }

        public async Task<int> InsertAsync(TEntity entity)
        {


            var properties = typeof(TEntity).GetProperties();

            var columns = string.Join(",", properties.Select(column => column.Name));

            var values = string.Join(",", properties.Select(value => $"@{value.Name}"));

            var query = $"INSERT INTO {TableName} ({columns}) VALUES ({values})";

            var param = new DynamicParameters();

            foreach (var property in properties)
            {
                var name = property.Name;
                var value = property.GetValue(entity);

                param.Add(name, value);
            }

            var result = await UnitOfWork.Connection.ExecuteAsync(query, param, transaction: UnitOfWork.Transaction);

            return result;
        }

        public async Task<int> UpdateAsync(Guid entityId, TEntity entity)
        {

            var properties = typeof(TEntity).GetProperties();

            var updateColumns = string.Join(",", properties.Select(property => $"{property.Name} = @{property.Name}"));

            var query = $"UPDATE {TableName} SET {updateColumns} where {TableName}Id = @entityId";

            var param = new DynamicParameters();

            foreach (var property in properties)
            {
                var name = property.Name;
                var value = property.GetValue(entity);

                param.Add(name, value);
            }
            param.Add("entityId", entityId);
            var result = await UnitOfWork.Connection.ExecuteAsync(query, param, transaction: UnitOfWork.Transaction);

            return result;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {


            var procedure = $"Proc_{TableName}_Delete";

            var param = new DynamicParameters();
            param.Add($"{TableName}IdParam", entity.GetId());

            var result = await UnitOfWork.Connection.ExecuteAsync(procedure, param, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            return result;
        }

        public async Task<int> DeleteMultipleAsync(List<TEntity> entities)
        {


            var query = $"DELETE FROM {TableName} WHERE {TableName}Id IN @ids";
            var param = new DynamicParameters();
            param.Add("ids", entities.Select(entity => entity.GetId()));

            var result = await UnitOfWork.Connection.ExecuteAsync(query, param, transaction: UnitOfWork.Transaction);

            return result;
        }
        public async Task<List<TEntity>> CheckListIdAsync(List<Guid> ids)
        {

            var query = $"SELECT * FROM {TableName} WHERE {TableName}Id IN @Ids";


            var existingEntities = await UnitOfWork.Connection.QueryAsync<TEntity>(query, new { Ids = ids });

            var existingIds = existingEntities.Select(entity => entity.GetId()).ToList();

            var nonExistingIds = ids.Except(existingIds);

            if (nonExistingIds.Any())
            {

                throw new NotFoundException(string.Format(Domain.Resources.ResourceVN.EmployeeIdNotExists, string.Join(",", nonExistingIds)), (int)NotFound.NotFoundEmployeeId);
            }

            return existingEntities.ToList();
        }
        #endregion
    }
}
