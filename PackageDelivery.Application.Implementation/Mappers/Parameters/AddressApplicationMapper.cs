using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class AddressApplicationMapper : DTOMapperBase<AddresDTO, AddressDBModel>
    {
        public override AddresDTO DBModelToDTOMapper(AddressDBModel input)
        {
            return new AddresDTO()
            {
                Id = input.Id,
                StreetType = input.StreetType,
                Number = input.Number,
                PropertyType = input.PropertyType,
                Neighborhood = input.Neighborhood,
                Observations = input.Observations,
                Current = input.Current,
                IdTown = input.IdTown,
                IdPerson = input.IdPerson
            };
        }

        public override IEnumerable<AddresDTO> DBModelToDTOMapper(IEnumerable<AddressDBModel> input)
        {
            IList<AddresDTO> list = new List<AddresDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override AddressDBModel DTOToDBModelMapper(AddresDTO input)
        {
            return new AddressDBModel
            {
                Id = input.Id,
                StreetType = input.StreetType,
                Number = input.Number,
                PropertyType = input.PropertyType,
                Neighborhood = input.Neighborhood,
                Observations = input.Observations,
                Current = input.Current,
                IdTown = input.IdTown,
                IdPerson = input.IdPerson
            };
        }

        public override IEnumerable<AddressDBModel> DTOToDBModelMapper(IEnumerable<AddresDTO> input)
        {
            IList<AddressDBModel> list = new List<AddressDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}
