using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IAddressRepository
    {
        AddressDBModel getRecordById(int id);
        IEnumerable<AddressDBModel> getRecordsList(string filter);
        AddressDBModel createRecord(AddressDBModel record);
        AddressDBModel updateRecord(AddressDBModel record);
        bool deleteRecordById(int id);
    }
}
