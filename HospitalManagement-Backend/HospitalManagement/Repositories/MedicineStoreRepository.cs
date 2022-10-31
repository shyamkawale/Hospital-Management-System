namespace HospitalManagement.Repositories
{
    public class MedicineStoreRepository : IServiceRepository<MedicineStore, int>
    {
        IDataAccess<MedicineStore, int> medicineStoreDataAccess;
        public MedicineStoreRepository(IDataAccess<MedicineStore, int> dataAccess)
        {
            medicineStoreDataAccess = dataAccess;
        }


        ResponseStatus<MedicineStore> IServiceRepository<MedicineStore, int>.CreateRecord(MedicineStore entity)
        {
            ResponseStatus<MedicineStore> response = new ResponseStatus<MedicineStore>();
            try
            {
                response.Record = medicineStoreDataAccess.Create(entity);
                response.Message = "MedicineStore created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }

        ResponseStatus<MedicineStore> IServiceRepository<MedicineStore, int>.DeleteRecord(int id)
        {
            ResponseStatus<MedicineStore> response = new ResponseStatus<MedicineStore>();
            try
            {
                response.Record = medicineStoreDataAccess.Delete(id);
                response.Message = $"MedicineStore with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<MedicineStore> IServiceRepository<MedicineStore, int>.GetRecord(int id)
        {
            ResponseStatus<MedicineStore> response = new ResponseStatus<MedicineStore>();
            try
            {
                response.Record = medicineStoreDataAccess.Get(id);
                response.Message = $"MedicineStore with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<MedicineStore> IServiceRepository<MedicineStore, int>.GetRecords()
        {
            ResponseStatus<MedicineStore> response = new ResponseStatus<MedicineStore>();
            try
            {
                response.Records = medicineStoreDataAccess.Get();
                response.Message = $"All MedicineStores read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<MedicineStore> IServiceRepository<MedicineStore, int>.UpdateRecord(int id, MedicineStore entity)
        {
            ResponseStatus<MedicineStore> response = new ResponseStatus<MedicineStore>();
            try
            {
                response.Record = medicineStoreDataAccess.Update(id, entity);
                response.Message = $"MedicineStore with id: {id} updated succesfully";
                response.StatusCode = 204;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
