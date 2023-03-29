using PackageDelivery.Repository.Contracts.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mapper.Parameters
{
    public class WarehouseRepositoryMapper : DBModelMapperBase<WarehouseDBModel, bodega>
    {
        public override WarehouseDBModel DatabaseToDBModelMapper(bodega input)
        {
            return new WarehouseDBModel()
            {
                Id = input.id,
                Name = input.nombre,
                Code = input.codigo,
                Address = input.direccion,
                Latitude = input.latitud,
                Longitude = input.longitud,
                IdTown = input.idMunicipio
            };
        }

        public override IEnumerable<WarehouseDBModel> DatabaseToDBModelMapper(IEnumerable<bodega> input)
        {
            IList<WarehouseDBModel> list = new List<WarehouseDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override bodega DBModelToDatabaseMapper(WarehouseDBModel input)
        {
            return new bodega
            {
                id = input.Id,
                nombre = input.Name,
                codigo = input.Code,
                direccion = input.Address,
                latitud = input.Latitude,
                longitud = input.Longitude,
                idMunicipio = input.IdTown
            };
        }

        public override IEnumerable<bodega> DBModelToDatabaseMapper(IEnumerable<WarehouseDBModel> input)
        {
            IList<bodega> list = new List<bodega>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
