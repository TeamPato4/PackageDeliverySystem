using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IDeliveryStateApplication
    {
        DeliveryStateDTO getRecordById(int id);
        IEnumerable<DeliveryStateDTO> getRecordsList(string filter);
        DeliveryStateDTO createRecord(DeliveryStateDTO record);
        DeliveryStateDTO updateRecord(DeliveryStateDTO record);
        bool deleteRecordById(int id);
    }
}