using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IPersonRepository
    {
        PersonDBModel getRecordById(int id);
        IEnumerable<PersonDBModel> getRecordsList(string filter);
        PersonDBModel createRecord(PersonDBModel record);
        PersonDBModel updateRecord(PersonDBModel record);
        bool deleteRecordById(int id);
    }
}
