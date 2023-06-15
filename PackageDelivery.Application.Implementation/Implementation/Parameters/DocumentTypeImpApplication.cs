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
    public class DocumentTypeImpApplication : IDocumentTypeApplication
    {
        IDocumentTypeRepository _repository = new DocumentTypeImpRepository();
        public DocumentTypeDTO createRecord(DocumentTypeDTO record)
        {
            DocumentTypeApplicationMapper mapper = new DocumentTypeApplicationMapper();
            DocumentTypeDBModel dbModel = mapper.DTOToDBModelMapper(record);
            DocumentTypeDBModel response = this._repository.createRecord(dbModel);
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

        public DocumentTypeDTO getRecordById(int id)
        {
            DocumentTypeApplicationMapper mapper = new DocumentTypeApplicationMapper();
            DocumentTypeDBModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(dbModel);
        }

        public IEnumerable<DocumentTypeDTO> getRecordsList(string filter)
        {
            DocumentTypeApplicationMapper mapper = new DocumentTypeApplicationMapper();
            IEnumerable<DocumentTypeDBModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DBModelToDTOMapper(dbModelList);
        }

        public DocumentTypeDTO updateRecord(DocumentTypeDTO record)
        {
            DocumentTypeApplicationMapper mapper = new DocumentTypeApplicationMapper();
            DocumentTypeDBModel dbModel = mapper.DTOToDBModelMapper(record);
            DocumentTypeDBModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DBModelToDTOMapper(response);
        }
    }
}
