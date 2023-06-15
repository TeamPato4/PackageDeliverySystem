using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IDepartmentApplication
    {
        DepartmentDTO getRecordById(int id);
        IEnumerable<DepartmentDTO> getRecordsList(string filter);
        DepartmentDTO createRecord(DepartmentDTO record);
        DepartmentDTO updateRecord(DepartmentDTO record);
        bool deleteRecordById(int id);
    }
}
