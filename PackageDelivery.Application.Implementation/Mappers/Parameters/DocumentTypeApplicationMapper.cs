using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class DocumentTypeApplicationMapper : DTOMapperBase<DocumentTypeDTO, DocumentTypeDBModel>
    {
        public override DocumentTypeDTO DBModelToDTOMapper(DocumentTypeDBModel input)
        {
            return new DocumentTypeDTO()
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<DocumentTypeDTO> DBModelToDTOMapper(IEnumerable<DocumentTypeDBModel> input)
        {
            IList<DocumentTypeDTO> list = new List<DocumentTypeDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override DocumentTypeDBModel DTOToDBModelMapper(DocumentTypeDTO input)
        {
            return new DocumentTypeDBModel
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<DocumentTypeDBModel> DTOToDBModelMapper(IEnumerable<DocumentTypeDTO> input)
        {
            IList<DocumentTypeDBModel> list = new List<DocumentTypeDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}
