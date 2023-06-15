using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IHistoryRepository
    {
        HistoryDBModel getRecordById(int id);
        IEnumerable<HistoryDBModel> getRecordsList(string filter);
        HistoryDBModel createRecord(HistoryDBModel record);
        HistoryDBModel updateRecord(HistoryDBModel record);
        bool deleteRecordById(int id);
    }
}
