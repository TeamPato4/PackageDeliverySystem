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
    public class TownImpApplication : ITownApplication
    {
        ITownRepository _repository = new TownImpRepository();
        public TownDTO createRecord(TownDTO record)
        {
            TownApplicationMapper mapper = new TownApplicationMapper();
            TownDBModel dbModel = mapper.DTOToDBModelMapper(record);
            TownDBModel response = this._repository.createRecord(dbModel);
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

        public TownDTO getRecordById(int id)
        {
            TownApplicationMapper mapper = new TownApplicationMapper();
            TownDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<TownDTO> getRecordsList(string filter)
        {
            TownApplicationMapper mapper = new TownApplicationMapper();
            IEnumerable<TownDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public TownDTO updateRecord(TownDTO record)
        {
            TownApplicationMapper mapper = new TownApplicationMapper();
            TownDBModel dbModel = mapper.DTOToDBModelMapper(record);
            TownDBModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(response);
        }
    }
}
