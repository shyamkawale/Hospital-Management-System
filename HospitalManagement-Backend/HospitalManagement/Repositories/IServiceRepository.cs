using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface IServiceRepository<TEntity, TPk> where TEntity : class
    {
        ResponseStatus<TEntity> GetRecords();
        ResponseStatus<TEntity> GetRecord(TPk id);
        ResponseStatus<TEntity> CreateRecord(TEntity entity);
        ResponseStatus<TEntity> UpdateRecord(TPk id, TEntity entity);
        ResponseStatus<TEntity> DeleteRecord(TPk id);
    }
}
