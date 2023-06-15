using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class DeliveryGUIMapper : ModelMapperBase<DeliveryModel, DeliveryDTO>
    {
        public override DeliveryModel DTOToModelMapper(DeliveryDTO input)
        {
            return new DeliveryModel()
            {
                Id = input.Id,
                SendDate = input.SendDate,
                Price = input.Price,
                IdSender = input.IdSender,
                IdAddressDestination = input.IdAddressDestination,
                IdPackage = input.IdPackage,
                IdDeliveryState = input.IdDeliveryState,
                IdTransportType = input.IdTransportType,
                DeliveryStateName = input.DeliveryStateName,
                TransportTypeName = input.TrasportTypeName
            };
        }

        public override IEnumerable<DeliveryModel> DTOToModelMapper(IEnumerable<DeliveryDTO> input)
        {
            IList<DeliveryModel> list = new List<DeliveryModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override DeliveryDTO ModelToDTOMapper(DeliveryModel input)
        {
            return new DeliveryDTO
            {
                Id = input.Id,
                SendDate = input.SendDate,
                Price = input.Price,
                IdSender = input.IdSender,
                IdAddressDestination = input.IdAddressDestination,
                IdPackage = input.IdPackage,
                IdDeliveryState = input.IdDeliveryState,
                IdTransportType = input.IdTransportType
            };
        }

        public override IEnumerable<DeliveryDTO> ModelToDTOMapper(IEnumerable<DeliveryModel> input)
        {
            IList<DeliveryDTO> list = new List<DeliveryDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
