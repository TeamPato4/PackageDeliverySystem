using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class DeliveryStateApplicationMapper : DTOMapperBase<DeliveryStateDTO, DeliveryStateDBModel>
    {
        public override DeliveryStateDTO DBModelToDTOMapper(DeliveryStateDBModel input)
        {
            return new DeliveryStateDTO()
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<DeliveryStateDTO> DBModelToDTOMapper(IEnumerable<DeliveryStateDBModel> input)
        {
            IList<DeliveryStateDTO> list = new List<DeliveryStateDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override DeliveryStateDBModel DTOToDBModelMapper(DeliveryStateDTO input)
        {
            return new DeliveryStateDBModel
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<DeliveryStateDBModel> DTOToDBModelMapper(IEnumerable<DeliveryStateDTO> input)
        {
            IList<DeliveryStateDBModel> list = new List<DeliveryStateDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}

