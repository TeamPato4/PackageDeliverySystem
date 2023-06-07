using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class WarehouseApplicationMapper : DTOMapperBase<WarehouseDTO, WarehouseDBModel>
    {
        public override WarehouseDTO DBModelToDTOMapper(WarehouseDBModel input)
        {
            return new WarehouseDTO()
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

        public override IEnumerable<WarehouseDTO> DBModelToDTOMapper(IEnumerable<WarehouseDBModel> input)
        {
            IList<WarehouseDTO> list = new List<WarehouseDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override WarehouseDBModel DTOToDBModelMapper(WarehouseDTO input)
        {
            return new WarehouseDBModel
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

        public override IEnumerable<WarehouseDBModel> DTOToDBModelMapper(IEnumerable<WarehouseDTO> input)
        {
            IList<WarehouseDBModel> list = new List<WarehouseDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}
