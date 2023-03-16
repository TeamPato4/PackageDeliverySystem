using PackageDelivery.Repository.Contracts.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mapper.Parameters
{
    public class DocumentTypeRepositoryMapper : DBModelMapperBase<DocumentTypeDBModel, tipoDocumento>
    {
        public override DocumentTypeDBModel DatabaseToDBModelMapper(tipoDocumento input)
        {
            return new DocumentTypeDBModel()
            {
                Id = input.id,
                Name = input.nombre,
            };
        }

        public override IEnumerable<DocumentTypeDBModel> DatabaseToDBModelMapper(IEnumerable<tipoDocumento> input)
        {
            IList<DocumentTypeDBModel> list = new List<DocumentTypeDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override tipoDocumento DBModelToDatabaseMapper(DocumentTypeDBModel input)
        {
            return new tipoDocumento
            {
                id = input.Id,
                nombre = input.Name,
            };
        }

        public override IEnumerable<tipoDocumento> DBModelToDatabaseMapper(IEnumerable<DocumentTypeDBModel> input)
        {
            IList<tipoDocumento> list = new List<tipoDocumento>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
