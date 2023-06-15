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
    public class OfficeImpApplication : IOfficeApplication
    {
        IOfficeRepository _repository = new OfficeImpRepository();
        public OfficeDTO createRecord(OfficeDTO record)
        {
            OfficeApplicationMapper mapper = new OfficeApplicationMapper();
            OfficeDBModel dbModel = mapper.DTOToDBModelMapper(record);
            OfficeDBModel response = this._repository.createRecord(dbModel);
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

        public OfficeDTO getRecordById(int id)
        {
            OfficeApplicationMapper mapper = new OfficeApplicationMapper();
            OfficeDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<OfficeDTO> getRecordsList(string filter)
        {
            OfficeApplicationMapper mapper = new OfficeApplicationMapper();
            IEnumerable<OfficeDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public OfficeDTO updateRecord(OfficeDTO record)
        {
            OfficeApplicationMapper mapper = new OfficeApplicationMapper();
            OfficeDBModel dbModel = mapper.DTOToDBModelMapper(record);
            OfficeDBModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(response);
        }
    }
}
