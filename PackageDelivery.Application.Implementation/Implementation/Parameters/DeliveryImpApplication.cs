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
    public class DeliveryImpApplication : IDeliveryApplication
    {
        IDeliveryRepository _repository = new DeliveryImpRepository();
        public DeliveryDTO createRecord(DeliveryDTO record)
        {
            DeliveryApplicationMapper mapper = new DeliveryApplicationMapper();
            DeliveryDBModel dbModel = mapper.DTOToDBModelMapper(record);
            DeliveryDBModel response = this._repository.createRecord(dbModel);
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

        public DeliveryDTO getRecordById(int id)
        {
            DeliveryApplicationMapper mapper = new DeliveryApplicationMapper();
            DeliveryDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<DeliveryDTO> getRecordsList(string filter)
        {
            DeliveryApplicationMapper mapper = new DeliveryApplicationMapper();
            IEnumerable<DeliveryDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public DeliveryDTO updateRecord(DeliveryDTO record)
        {
            DeliveryApplicationMapper mapper = new DeliveryApplicationMapper();
            DeliveryDBModel dbModel = mapper.DTOToDBModelMapper(record);
            DeliveryDBModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(response);
        }
    }
}