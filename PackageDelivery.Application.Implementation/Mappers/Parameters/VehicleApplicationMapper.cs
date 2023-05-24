using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class VehicleApplicationMapper : DTOMapperBase<VehicleDTO, VehicleDBModel>
    {
        public override VehicleDTO DBModelToDTOMapper(VehicleDBModel input)
        {
            return new VehicleDTO
            {
                Id = input.Id,
                Plate = input.Plate,
                IdTransportType = input.IdTransportType,
            };
        }

        public override IEnumerable<VehicleDTO> DBModelToDTOMapper(IEnumerable<VehicleDBModel> input)
        {
            IList<VehicleDTO> list = new List<VehicleDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override VehicleDBModel DTOToDBModelMapper(VehicleDTO input)
        {
            return new VehicleDBModel
            {
                Id = input.Id,
                Plate = input.Plate,
                IdTransportType = input.IdTransportType,
            };
        }

        public override IEnumerable<VehicleDBModel> DTOToDBModelMapper(IEnumerable<VehicleDTO> input)
        {
            IList<VehicleDBModel> list = new List<VehicleDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}
