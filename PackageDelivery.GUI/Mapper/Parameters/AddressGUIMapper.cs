using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mapper.Parameters
{
    public class AddressGUIMapper : ModelMapperBase<AddressModel, AddressDTO>
    {
        public override AddressModel DTOToModelMapper(AddressDTO input)
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

        public override IEnumerable<AddressModel> DTOToModelMapper(IEnumerable<AddressDTO> input)
        {
            IList<AddressModel> list = new List<AddressModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override AddressDTO ModelToDTOMapper(AddressModel input)
        {
            return new AddressDTO
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

        public override IEnumerable<AddressDTO> ModelToDTOMapper(IEnumerable<AddressModel> input)
        {
            IList<AddressDTO> list = new List<AddressDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
