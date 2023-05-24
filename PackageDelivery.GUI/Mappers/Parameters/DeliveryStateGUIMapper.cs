using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class DeliveryStateGUIMapper : ModelMapperBase<DeliveryStateModel, DeliveryStateDTO>
    {
        public override DeliveryStateModel DTOToModelMapper(DeliveryStateDTO input)
        {
            return new DeliveryStateModel()
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<DeliveryStateModel> DTOToModelMapper(IEnumerable<DeliveryStateDTO> input)
        {
            IList<DeliveryStateModel> list = new List<DeliveryStateModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override DeliveryStateDTO ModelToDTOMapper(DeliveryStateModel input)
        {
            return new DeliveryStateDTO
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<DeliveryStateDTO> ModelToDTOMapper(IEnumerable<DeliveryStateModel> input)
        {
            IList<DeliveryStateDTO> list = new List<DeliveryStateDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}

