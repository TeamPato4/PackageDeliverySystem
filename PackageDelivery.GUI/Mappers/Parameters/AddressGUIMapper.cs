using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class AddressGUIMapper : ModelMapperBase<AddressModel, AddresDTO>
    {
        public override AddressModel DTOToModelMapper(AddresDTO input)
        {
            return new AddressModel()
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

        public override IEnumerable<AddressModel> DTOToModelMapper(IEnumerable<AddresDTO> input)
        {
            IList<AddressModel> list = new List<AddressModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override AddresDTO ModelToDTOMapper(AddressModel input)
        {
            return new AddresDTO
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

        public override IEnumerable<AddresDTO> ModelToDTOMapper(IEnumerable<AddressModel> input)
        {
            IList<AddresDTO> list = new List<AddresDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
