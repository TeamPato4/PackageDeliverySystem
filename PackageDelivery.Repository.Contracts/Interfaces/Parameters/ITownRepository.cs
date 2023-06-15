using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface ITownRepository
    {
        TownDBModel getRecordById(int id);
        IEnumerable<TownDBModel> getRecordsList(string filter);
        TownDBModel createRecord(TownDBModel record);
        TownDBModel updateRecord(TownDBModel record);
        bool deleteRecordById(int id);
    }
}
