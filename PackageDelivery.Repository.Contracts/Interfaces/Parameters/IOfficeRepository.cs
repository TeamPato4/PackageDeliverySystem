using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IOfficeRepository
    {
        DocumentTypeDBModel getRecordById(int id);
        IEnumerable<DocumentTypeDBModel> getRecordsList(string filter);
        DocumentTypeDBModel createRecord(DocumentTypeDBModel record);
        DocumentTypeDBModel updateRecord(DocumentTypeDBModel record);
        bool deleteRecordById(int id);
    }
}
