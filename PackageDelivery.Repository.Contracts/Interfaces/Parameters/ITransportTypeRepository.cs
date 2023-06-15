using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface ITransportTypeRepository
    {
        TransportTypeDBModel getRecordById(int id);
        IEnumerable<TransportTypeDBModel> getRecordsList(string filter);
        TransportTypeDBModel createRecord(TransportTypeDBModel record);
        TransportTypeDBModel updateRecord(TransportTypeDBModel record);
        bool deleteRecordById(int id);
    }
}