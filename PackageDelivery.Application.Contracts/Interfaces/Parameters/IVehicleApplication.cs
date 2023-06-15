using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IVehicleApplication
    {
        VehicleDTO getRecordById(int id);
        IEnumerable<VehicleDTO> getRecordsList(string filter);
        VehicleDTO createRecord(VehicleDTO record);
        VehicleDTO updateRecord(VehicleDTO record);
        bool deleteRecordById(int id);
    }
}