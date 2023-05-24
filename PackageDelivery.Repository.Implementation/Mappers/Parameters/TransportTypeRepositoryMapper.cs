using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class TransportTypeRepositoryMapper : DBModelMapperBase<TransportTypeDBModel, tipoTransporte>
    {
        public override TransportTypeDBModel DatabaseToDBModelMapper(tipoTransporte input)
        {
            return new TransportTypeDBModel
            {
                Id = input.id,
                Name = input.nombre
            };
        }

        public override IEnumerable<TransportTypeDBModel> DatabaseToDBModelMapper(IEnumerable<tipoTransporte> input)
        {
            IList<TransportTypeDBModel> list = new List<TransportTypeDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override tipoTransporte DBModelToDatabaseMapper(TransportTypeDBModel input)
        {
            return new tipoTransporte
            {
                id = input.Id,
                nombre = input.Name,
            };
        }

        public override IEnumerable<tipoTransporte> DBModelToDatabaseMapper(IEnumerable<TransportTypeDBModel> input)
        {
            IList<tipoTransporte> list = new List<tipoTransporte>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
