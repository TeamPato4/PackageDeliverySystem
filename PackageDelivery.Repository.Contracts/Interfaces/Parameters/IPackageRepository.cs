using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IPackageRepository
    {
        PackageDBModel getRecordById(int id);
        IEnumerable<PackageDBModel> getRecordsList(long filter);
        PackageDBModel createRecord(PackageDBModel record);
        PackageDBModel updateRecord(PackageDBModel record);
        bool deleteRecordById(int id);
    }
}
