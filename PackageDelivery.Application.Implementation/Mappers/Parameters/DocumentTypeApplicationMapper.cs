namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    using PackageDelivery.Application.Contracts.DTO;
    using PackageDelivery.Repository.Contracts.DBModels.Parameters;
    using System.Collections.Generic;
    public class DocumentTypeApplicationMapper : DTOApplicationMapper<DocumentTypeDTO, DocumentTypeDBModel>
    {
        public override DocumentTypeDTO ApplicationlToDTOMapper(DocumentTypeDBModel input)
        {
            return new DocumentTypeDTO
            {
                Id = input.Id,
                Name = input.Name,                
            };
        }

        public override IEnumerable<DocumentTypeDTO> ApplicationlToDTOMapper(IEnumerable<DocumentTypeDBModel> input)
        {
            IList<DocumentTypeDTO> list = new List<DocumentTypeDTO>();
            foreach (var item in input)
            {
                list.Add(this.ApplicationlToDTOMapper(item));
            }
            return list;
        }

        public override DocumentTypeDBModel DTOToApplicationlMapper(DocumentTypeDTO input)
        {
            return new DocumentTypeDBModel
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<DocumentTypeDBModel> DTOToApplicationlMapper(IEnumerable<DocumentTypeDTO> input)
        {
            IList<DocumentTypeDBModel> list = new List<DocumentTypeDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToApplicationlMapper(item));
            }
            return list;
        }
    }
}
