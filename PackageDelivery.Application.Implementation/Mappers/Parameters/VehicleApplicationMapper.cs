namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    using PackageDelivery.Application.Contracts.DTO;
    using PackageDelivery.Repository.Contracts.DBModels.Parameters;
    using System.Collections.Generic;
    public class VehicleApplicationMapper : DTOApplicationMapper<VehicleDTO, VehicleDBModel>
    {
        public override VehicleDTO ApplicationlToDTOMapper(VehicleDBModel input)
        {
            return new VehicleDTO
            {
                Id = input.Id,
                Placa = input.Placa,
            };
        }

        public override IEnumerable<VehicleDTO> ApplicationlToDTOMapper(IEnumerable<VehicleDBModel> input)
        {
            IList<VehicleDTO> list = new List<VehicleDTO>();
            foreach (var item in input)
            {
                list.Add(this.ApplicationlToDTOMapper(item));
            }
            return list;
        }

        public override VehicleDBModel DTOToApplicationlMapper(VehicleDTO input)
        {
            return new VehicleDBModel
            {
                Id = input.Id,
                Placa = input.Placa,
            };
        }

        public override IEnumerable<VehicleDBModel> DTOToApplicationlMapper(IEnumerable<VehicleDTO> input)
        {
            IList<VehicleDBModel> list = new List<VehicleDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToApplicationlMapper(item));
            }
            return list;
        }
    }
}
