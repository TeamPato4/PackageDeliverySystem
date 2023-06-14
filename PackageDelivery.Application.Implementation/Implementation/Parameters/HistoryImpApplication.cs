using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.Parameters;
using System;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Parameters
{
    public class HistoryImpApplication : IHistoryApplication
    {
        IHistoryRepository _repository = new HistoryImpRepository();
        public HistoryDTO createRecord(HistoryDTO record)
        {
            HistoryApplicationMapper mapper = new HistoryApplicationMapper();
            HistoryDBModel dbModel = mapper.DTOToDBModelMapper(record);
            HistoryDBModel response = this._repository.createRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(response);
        }

        public bool deleteRecordById(int id)
        {
            return _repository.deleteRecordById(id);
        }

        public HistoryDTO getRecordById(int id)
        {
            HistoryApplicationMapper mapper = new HistoryApplicationMapper();
            HistoryDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<HistoryDTO> getRecordsList(string filter)
        {
            HistoryApplicationMapper mapper = new HistoryApplicationMapper();
            IEnumerable<HistoryDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public HistoryDTO updateRecord(HistoryDTO record)
        {
            HistoryApplicationMapper mapper = new HistoryApplicationMapper();
            HistoryDBModel dbModel = mapper.DTOToDBModelMapper(record);
            HistoryDBModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(response);
        }
    }
}