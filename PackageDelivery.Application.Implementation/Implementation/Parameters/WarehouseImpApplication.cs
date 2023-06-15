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
    public class WarehouseImpApplication : IWarehouseApplication
    {
        IWarehouseRepository _repository = new WarehouseImpRepository();
        public WarehouseDTO createRecord(WarehouseDTO record)
        {
            WarehouseApplicationMapper mapper = new WarehouseApplicationMapper();
            WarehouseDBModel dbModel = mapper.DTOToDBModelMapper(record);
            WarehouseDBModel response = this._repository.createRecord(dbModel);
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

        public WarehouseDTO getRecordById(int id)
        {
            WarehouseApplicationMapper mapper = new WarehouseApplicationMapper();
            WarehouseDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<WarehouseDTO> getRecordsList(string filter)
        {
            WarehouseApplicationMapper mapper = new WarehouseApplicationMapper();
            IEnumerable<WarehouseDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public WarehouseDTO updateRecord(WarehouseDTO record)
        {
            WarehouseApplicationMapper mapper = new WarehouseApplicationMapper();
            WarehouseDBModel dbModel = mapper.DTOToDBModelMapper(record);
            WarehouseDBModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(response);
        }
    }
}
