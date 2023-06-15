using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IVehicleRepository
    {
        VehicleDBModel getRecordById(int id);
        IEnumerable<VehicleDBModel> getRecordsList(string filter);
        VehicleDBModel createRecord(VehicleDBModel record);
        VehicleDBModel updateRecord(VehicleDBModel record);
        bool deleteRecordById(int id);
    }
}