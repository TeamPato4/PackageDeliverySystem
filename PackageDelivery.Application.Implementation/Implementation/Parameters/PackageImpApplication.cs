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
    public class PackageImpApplication : IPackageApplication
    {
        IPackageRepository _repository = new PackageImpRepository();
        public PackageDTO createRecord(PackageDTO record)
        {
            PackageApplicationMapper mapper = new PackageApplicationMapper();
            PackageDBModel dbModel = mapper.DTOToDBModelMapper(record);
            PackageDBModel response = this._repository.createRecord(dbModel);
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

        public PackageDTO getRecordById(int id)
        {
            PackageApplicationMapper mapper = new PackageApplicationMapper();
            PackageDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<PackageDTO> getRecordsList(string filter)
        {
            PackageApplicationMapper mapper = new PackageApplicationMapper();
            IEnumerable<PackageDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public PackageDTO updateRecord(PackageDTO record)
        {
            PackageApplicationMapper mapper = new PackageApplicationMapper();
            PackageDBModel dbModel = mapper.DTOToDBModelMapper(record);
            PackageDBModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(response);
        }
    }
}
