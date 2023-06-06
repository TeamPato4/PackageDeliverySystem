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
    public class PersonImpApplication : IPersonApplication
    {
        IPersonRepository _repository = new PersonImpRepository();
        public PersonDTO createRecord(PersonDTO record)
        {
            PersonApplicationMapper mapper = new PersonApplicationMapper();
            PersonDBModel dbModel = mapper.DTOToDBModelMapper(record);
            PersonDBModel response = this._repository.createRecord(dbModel);
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

        public PersonDTO getRecordById(int id)
        {
            PersonApplicationMapper mapper = new PersonApplicationMapper();
            PersonDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<PersonDTO> getRecordsList(string filter)
        {
            PersonApplicationMapper mapper = new PersonApplicationMapper();
            IEnumerable<PersonDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public PersonDTO updateRecord(PersonDTO record)
        {
            PersonApplicationMapper mapper = new PersonApplicationMapper();
            PersonDBModel dbModel = mapper.DTOToDBModelMapper(record);
            PersonDBModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(response);
        }
    }
}
