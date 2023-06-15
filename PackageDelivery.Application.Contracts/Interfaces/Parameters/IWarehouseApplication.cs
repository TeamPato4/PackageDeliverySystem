using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IWarehouseApplication
    {
        WarehouseDTO getRecordById(int id);
        IEnumerable<WarehouseDTO> getRecordsList(string filter);
        WarehouseDTO createRecord(WarehouseDTO record);
        WarehouseDTO updateRecord(WarehouseDTO record);
        bool deleteRecordById(int id);
    }
}
