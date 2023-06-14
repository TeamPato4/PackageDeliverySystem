using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IHistoryApplication
    {
        HistoryDTO getRecordById(int id);
        IEnumerable<HistoryDTO> getRecordsList(string filter);
        HistoryDTO createRecord(HistoryDTO record);
        HistoryDTO updateRecord(HistoryDTO record);
        bool deleteRecordById(int id);
    }
}