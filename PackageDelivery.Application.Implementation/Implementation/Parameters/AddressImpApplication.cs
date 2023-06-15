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
    public class AddressImpApplication : IAddressApplication
    {
        IAddressRepository _repository = new AddressImpRepository();
        public AddressDTO createRecord(AddressDTO record)
        {
            AddressApplicationMapper mapper = new AddressApplicationMapper();
            AddressDBModel dbModel = mapper.DTOToDBModelMapper(record);
            AddressDBModel response = this._repository.createRecord(dbModel);
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

        public AddressDTO getRecordById(int id)
        {
            AddressApplicationMapper mapper = new AddressApplicationMapper();
            AddressDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<AddressDTO> getRecordsList(string filter)
        {
            AddressApplicationMapper mapper = new AddressApplicationMapper();
            IEnumerable<AddressDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public AddressDTO updateRecord(AddressDTO record)
        {
            AddressApplicationMapper mapper = new AddressApplicationMapper();
            AddressDBModel dbModel = mapper.DTOToDBModelMapper(record);
            AddressDBModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(response);
        }
    }
}
