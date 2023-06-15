using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.Implementation.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class VehicleApplication : IVehicleApplication
    {
        IVehicleRepository  _repository = new VehicleImpRepository();

        public VehicleDTO createRecord(VehicleDTO record)
        {
            VehicleApplicationMapper mapper = new VehicleApplicationMapper();
            VehicleDBModel recordDBModel = mapper.DTOToDBModelMapper(record);
            return mapper.DBModelToDTOMapper(_repository.createRecord(recordDBModel));
        }

        public bool deleteRecordById(int id)
        {
            return _repository.deleteRecordById(id);
        }

        public VehicleDTO getRecordById(int id)
        {
            VehicleApplicationMapper mapper = new VehicleApplicationMapper();
            VehicleDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<VehicleDTO> getRecordsList(string filter)
        {
            VehicleApplicationMapper mapper = new VehicleApplicationMapper();
            IEnumerable<VehicleDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public VehicleDTO updateRecord(VehicleDTO record)
        {
            VehicleApplicationMapper mapper = new VehicleApplicationMapper();
            VehicleDBModel recordDBModel = mapper.DTOToDBModelMapper(record);
            return mapper.DBModelToDTOMapper(_repository.updateRecord(recordDBModel));
        }
    }
}