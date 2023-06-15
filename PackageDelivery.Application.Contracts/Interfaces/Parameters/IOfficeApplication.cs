using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IOfficeApplication
    {
        OfficeDTO getRecordById(int id);
        IEnumerable<OfficeDTO> getRecordsList(string filter);
        OfficeDTO createRecord(OfficeDTO record);
        OfficeDTO updateRecord(OfficeDTO record);
        bool deleteRecordById(int id);
    }
}
