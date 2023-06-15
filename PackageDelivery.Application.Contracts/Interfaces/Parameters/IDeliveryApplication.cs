using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IDeliveryApplication
    {
        DeliveryDTO getRecordById(int id);
        IEnumerable<DeliveryDTO> getRecordsList(long filter);
        DeliveryDTO createRecord(DeliveryDTO record);
        DeliveryDTO updateRecord(DeliveryDTO record);
        bool deleteRecordById(int id);
    }
}