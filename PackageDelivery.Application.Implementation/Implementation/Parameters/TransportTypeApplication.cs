using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.Implementation.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class TransportTypeApplication : ITransportTypeApplication
    {
        ITransportTypeRepository _repository = new TransportTypeImpRepository();

        public TransportTypeDTO createRecord(TransportTypeDTO record)
        {
            TransportTypeApplicationMapper mapper = new TransportTypeApplicationMapper();
            TransportTypeDBModel recordDBModel = mapper.DTOToDBModelMapper(record);
            return mapper.DBModelToDTOMapper(_repository.createRecord(recordDBModel));
        }

        public bool deleteRecordById(int id)
        {
            return _repository.deleteRecordById(id);
        }

        public TransportTypeDTO getRecordById(int id)
        {
            TransportTypeApplicationMapper mapper = new TransportTypeApplicationMapper();
            TransportTypeDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<TransportTypeDTO> getRecordsList(string filter)
        {
            TransportTypeApplicationMapper mapper = new TransportTypeApplicationMapper();
            IEnumerable<TransportTypeDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public TransportTypeDTO updateRecord(TransportTypeDTO record)
        {
            TransportTypeApplicationMapper mapper = new TransportTypeApplicationMapper();
            TransportTypeDBModel recordDBModel = mapper.DTOToDBModelMapper(record);
            return mapper.DBModelToDTOMapper(_repository.updateRecord(recordDBModel));
        }
    }
}