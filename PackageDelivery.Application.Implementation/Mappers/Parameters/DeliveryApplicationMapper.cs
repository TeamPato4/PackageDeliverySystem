using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class DeliveryApplicationMapper : DTOMapperBase<DeliveryDTO, DeliveryDBModel>
    {
        public override DeliveryDTO DBModelToDTOMapper(DeliveryDBModel input)
        {
            return new DeliveryDTO()
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

        public override IEnumerable<DeliveryDTO> DBModelToDTOMapper(IEnumerable<DeliveryDBModel> input)
        {
            IList<DeliveryDTO> list = new List<DeliveryDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override DeliveryDBModel DTOToDBModelMapper(DeliveryDTO input)
        {
            return new DeliveryDBModel
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

        public override IEnumerable<DeliveryDBModel> DTOToDBModelMapper(IEnumerable<DeliveryDTO> input)
        {
            IList<DeliveryDBModel> list = new List<DeliveryDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}
