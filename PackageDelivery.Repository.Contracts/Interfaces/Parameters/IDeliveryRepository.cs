using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IDeliveryRepository
    {
        DeliveryDBModel getRecordById(int id);
        IEnumerable<DeliveryDBModel> getRecordsList(long filter);
        DeliveryDBModel createRecord(DeliveryDBModel record);
        DeliveryDBModel updateRecord(DeliveryDBModel record);
        bool deleteRecordById(int id);
    }
}
