using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class OfficeGUIMapper : ModelMapperBase<OfficeModel, OfficeDTO>
    {
        public override OfficeModel DTOToModelMapper(OfficeDTO input)
        {
            return new OfficeModel()
            {
                Id = input.Id,
                Name = input.Name,
                Code = input.Code,
                Phone = input.Phone,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                IdTown = input.IdTown,
                Address = input.Address,
                TownName = input.TownName,
            };
        }

        public override IEnumerable<OfficeModel> DTOToModelMapper(IEnumerable<OfficeDTO> input)
        {
            IList<OfficeModel> list = new List<OfficeModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override OfficeDTO ModelToDTOMapper(OfficeModel input)
        {
            return new OfficeDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Code = input.Code,
                Phone = input.Phone,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                IdTown = input.IdTown,
                Address = input.Address
            };
        }

        public override IEnumerable<OfficeDTO> ModelToDTOMapper(IEnumerable<OfficeModel> input)
        {
            IList<OfficeDTO> list = new List<OfficeDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
