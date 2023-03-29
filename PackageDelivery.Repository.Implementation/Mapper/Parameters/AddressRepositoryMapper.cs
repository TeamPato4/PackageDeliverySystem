using PackageDelivery.Repository.Contracts.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mapper.Parameters
{
    public class AddressRepositoryMapper : DBModelMapperBase<AddressDBModel, direccion>
    {
        public override AddressDBModel DatabaseToDBModelMapper(direccion input)
        {
            return new AddressDBModel()
            {
                Id = input.id,
                StreetType = input.tipoCalle,
                Number = input.numero,
                PropertyType = input.tipoInmueble,
                Neighborhood = input.barrio,
                Observations = input.observaciones,
                Current = input.actual,
                IdTown = input.idMunicipio,
                IdPerson = input.idPersona
            };
        }

        public override IEnumerable<AddressDBModel> DatabaseToDBModelMapper(IEnumerable<direccion> input)
        {
            IList<AddressDBModel> list = new List<AddressDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override direccion DBModelToDatabaseMapper(AddressDBModel input)
        {
            return new direccion
            {
                id = input.Id,
                tipoCalle = input.StreetType,
                numero = input.Number,
                tipoInmueble = input.PropertyType,
                barrio = input.Neighborhood,
                observaciones = input.Observations,
                actual = input.Current,
                idMunicipio = input.IdTown,
                idPersona = input.IdPerson
            };
        }

        public override IEnumerable<direccion> DBModelToDatabaseMapper(IEnumerable<AddressDBModel> input)
        {
            IList<direccion> list = new List<direccion>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
