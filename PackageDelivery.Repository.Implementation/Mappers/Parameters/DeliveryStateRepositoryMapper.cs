using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class DeliveryStateRepositoryMapper : DBModelMapperBase<DeliveryStateDBModel, estadoEnvio>
    {
        public override DeliveryStateDBModel DatabaseToDBModelMapper(estadoEnvio input)
        {
            return new DeliveryStateDBModel()
            {
                Id = input.id,
                Name = input.nombre,
            };
        }

        public override IEnumerable<DeliveryStateDBModel> DatabaseToDBModelMapper(IEnumerable<estadoEnvio> input)
        {
            IList<DeliveryStateDBModel> list = new List<DeliveryStateDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override estadoEnvio DBModelToDatabaseMapper(DeliveryStateDBModel input)
        {
            return new estadoEnvio
            {
                id = input.Id,
                nombre = input.Name,
            };
        }

        public override IEnumerable<estadoEnvio> DBModelToDatabaseMapper(IEnumerable<DeliveryStateDBModel> input)
        {
            IList<estadoEnvio> list = new List<estadoEnvio>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}

