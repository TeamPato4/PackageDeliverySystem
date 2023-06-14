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
    public class DeliveryStateImpApplication : IDeliveryStateApplication
    {
        IDeliveryStateRepository _repository = new DeliveryStateImpRepository();
        public DeliveryStateDTO createRecord(DeliveryStateDTO record)
        {
            DeliveryStateApplicationMapper mapper = new DeliveryStateApplicationMapper();
            DeliveryStateDBModel dbModel = mapper.DTOToDBModelMapper(record);
            DeliveryStateDBModel response = this._repository.createRecord(dbModel);
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

        public DeliveryStateDTO getRecordById(int id)
        {
            DeliveryStateApplicationMapper mapper = new DeliveryStateApplicationMapper();
            DeliveryStateDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<DeliveryStateDTO> getRecordsList(string filter)
        {
            DeliveryStateApplicationMapper mapper = new DeliveryStateApplicationMapper();
            IEnumerable<DeliveryStateDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public DeliveryStateDTO updateRecord(DeliveryStateDTO record)
        {
            DeliveryStateApplicationMapper mapper = new DeliveryStateApplicationMapper();
            DeliveryStateDBModel dbModel = mapper.DTOToDBModelMapper(record);
            DeliveryStateDBModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(response);
        }
    }
}