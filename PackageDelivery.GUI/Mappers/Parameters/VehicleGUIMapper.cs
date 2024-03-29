﻿using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class VehicleGUIMapper : ModelMapperBase<VehicleModel, VehicleDTO>
    {
        public override VehicleModel DTOToModelMapper(VehicleDTO input)
        {
            return new VehicleModel
            {
                Id = input.Id,
                Placa = input.Placa,
                IdTransportType = input.IdTransportType,
                TransportTypeName = input.TrasportTypeName
            };
        }

        public override IEnumerable<VehicleModel> DTOToModelMapper(IEnumerable<VehicleDTO> input)
        {
            IList<VehicleModel> list = new List<VehicleModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override VehicleDTO ModelToDTOMapper(VehicleModel input)
        {
            return new VehicleDTO
            {
                Id = input.Id,
                Placa = input.Placa,
                IdTransportType = input.IdTransportType,
            };
        }

        public override IEnumerable<VehicleDTO> ModelToDTOMapper(IEnumerable<VehicleModel> input)
        {
            IList<VehicleDTO> list = new List<VehicleDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
