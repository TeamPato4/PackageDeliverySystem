using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IOfficeRepository
    {
        OfficeDBModel getRecordById(int id);
        IEnumerable<OfficeDBModel> getRecordsList(string filter);
        OfficeDBModel createRecord(OfficeDBModel record);
        OfficeDBModel updateRecord(OfficeDBModel record);
        bool deleteRecordById(int id);
    }
}
