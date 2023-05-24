using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class TownGUIMapper : ModelMapperBase<TownModel, TownDTO>
    {
        public override TownModel DTOToModelMapper(TownDTO input)
        {
            return new TownModel()
            {
                Id = input.Id,
                Name = input.Name,
                IdDepartment = input.IdDepartment,
            };
        }

        public override IEnumerable<TownModel> DTOToModelMapper(IEnumerable<TownDTO> input)
        {
            IList<TownModel> list = new List<TownModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override TownDTO ModelToDTOMapper(TownModel input)
        {
            return new TownDTO()
            {
                Id = input.Id,
                Name = input.Name,
                IdDepartment = input.IdDepartment,
            };
        }

        public override IEnumerable<TownDTO> ModelToDTOMapper(IEnumerable<TownModel> input)
        {
            IList<TownDTO> list = new List<TownDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
