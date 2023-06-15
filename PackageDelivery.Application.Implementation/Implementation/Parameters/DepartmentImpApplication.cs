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
    public class DepartmentImpApplication : IDepartmentApplication
    {
        IDepartmentRepository _repository = new DepartmentImpRepository();
        public DepartmentDTO createRecord(DepartmentDTO record)
        {
            DepartmentApplicationMapper mapper = new DepartmentApplicationMapper();
            DepartmentDBModel dbModel = mapper.DTOToDBModelMapper(record);
            DepartmentDBModel response = this._repository.createRecord(dbModel);
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

        public DepartmentDTO getRecordById(int id)
        {
            DepartmentApplicationMapper mapper = new DepartmentApplicationMapper();
            DepartmentDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<DepartmentDTO> getRecordsList(string filter)
        {
            DepartmentApplicationMapper mapper = new DepartmentApplicationMapper();
            IEnumerable<DepartmentDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public DepartmentDTO updateRecord(DepartmentDTO record)
        {
            DepartmentApplicationMapper mapper = new DepartmentApplicationMapper();
            DepartmentDBModel dbModel = mapper.DTOToDBModelMapper(record);
            DepartmentDBModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(response);
        }
    }
}
