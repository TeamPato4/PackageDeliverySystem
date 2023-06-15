using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IDepartmentRepository
    {
        DepartmentDBModel getRecordById(int id);
        IEnumerable<DepartmentDBModel> getRecordsList(string filter);
        DepartmentDBModel createRecord(DepartmentDBModel record);
        DepartmentDBModel updateRecord(DepartmentDBModel record);
        bool deleteRecordById(int id);
    }
}
