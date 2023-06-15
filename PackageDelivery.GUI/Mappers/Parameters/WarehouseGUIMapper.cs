using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class WarehouseGUIMapper : ModelMapperBase<WarehouseModel, WarehouseDTO>
    {
        public override WarehouseModel DTOToModelMapper(WarehouseDTO input)
        {
            return new WarehouseModel()
            {
                Id = input.Id,
                Name = input.Name,
                Code = input.Code,
                Address = input.Address,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                IdTown = input.IdTown,
                TownName = input.TownName,
            };
        }

        public override IEnumerable<WarehouseModel> DTOToModelMapper(IEnumerable<WarehouseDTO> input)
        {
            IList<WarehouseModel> list = new List<WarehouseModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override WarehouseDTO ModelToDTOMapper(WarehouseModel input)
        {
            return new WarehouseDTO
            {
                Id = input.Id,
                Name = input.Name,
                Code = input.Code,
                Address = input.Address,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                IdTown = input.IdTown
            };
        }

        public override IEnumerable<WarehouseDTO> ModelToDTOMapper(IEnumerable<WarehouseModel> input)
        {
            IList<WarehouseDTO> list = new List<WarehouseDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
