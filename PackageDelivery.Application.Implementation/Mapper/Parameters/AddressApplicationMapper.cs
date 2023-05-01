using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Repository.Contracts.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mapper.Parameters
{
    public class AddressApplicationMapper : DTOMapperBase<AddressDTO, AddressDBModel>
    {
        public override AddressDTO DBModelToDTOMapper(AddressDBModel input)
        {
            return new AddressDTO()
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

        public override IEnumerable<AddressDTO> DBModelToDTOMapper(IEnumerable<AddressDBModel> input)
        {
            IList<AddressDTO> list = new List<AddressDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override AddressDBModel DTOToDBModelMapper(AddressDTO input)
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

        public override IEnumerable<AddressDBModel> DTOToDBModelMapper(IEnumerable<AddressDTO> input)
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
