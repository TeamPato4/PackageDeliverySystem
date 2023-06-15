using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IWarehouseRepository
    {
        WarehouseDBModel getRecordById(int id);
        IEnumerable<WarehouseDBModel> getRecordsList(string filter);
        WarehouseDBModel createRecord(WarehouseDBModel record);
        WarehouseDBModel updateRecord(WarehouseDBModel record);
        bool deleteRecordById(int id);
    }
}
