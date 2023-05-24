using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class OfficeRepositoryMapper : DBModelMapperBase<OfficeDBModel, oficina>
    {
        public override OfficeDBModel DatabaseToDBModelMapper(oficina input)
        {
            return new OfficeDBModel()
            {
                Id = input.id,
                Name = input.nombre,
                Code = input.codigo,
                Phone = input.telefono,
                Latitude = input.latitud,
                Longitude = input.longitud,
                IdTown = input.idMunicipio,
                Address = input.direccion
            };
        }

        public override IEnumerable<OfficeDBModel> DatabaseToDBModelMapper(IEnumerable<oficina> input)
        {
            IList<OfficeDBModel> list = new List<OfficeDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override oficina DBModelToDatabaseMapper(OfficeDBModel input)
        {
            return new oficina()
            {
                id = input.Id,
                nombre = input.Name,
                codigo = input.Code,
                telefono = input.Phone,
                latitud = input.Latitude,
                longitud = input.Longitude,
                idMunicipio = input.IdTown,
                direccion = input.Address
            };
        }

        public override IEnumerable<oficina> DBModelToDatabaseMapper(IEnumerable<OfficeDBModel> input)
        {
            IList<oficina> list = new List<oficina>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
