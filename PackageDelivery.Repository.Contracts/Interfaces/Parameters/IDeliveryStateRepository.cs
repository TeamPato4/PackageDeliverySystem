using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IDeliveryStateRepository
    {
        DeliveryStateDBModel getRecordById(int id);
        IEnumerable<DeliveryStateDBModel> getRecordsList(string filter);
        DeliveryStateDBModel createRecord(DeliveryStateDBModel record);
        DeliveryStateDBModel updateRecord(DeliveryStateDBModel record);
        bool deleteRecordById(int id);
    }
}