using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class HistoryGUIMapper : ModelMapperBase<HistoryModel, HistoryDTO>
    {
        public override HistoryModel DTOToModelMapper(HistoryDTO input)
        {
            return new HistoryModel()
            {
                Id = input.Id,
                AdmissionDate = input.AdmissionDate,
                DepartureDate = input.DepartureDate,
                Description = input.Description,
                IdPackage = input.IdPackage,
                IdWarehouse = input.IdWarehouse,
                WarehouseName = input.WarehouseName,
            };
        }

        public override IEnumerable<HistoryModel> DTOToModelMapper(IEnumerable<HistoryDTO> input)
        {
            IList<HistoryModel> list = new List<HistoryModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override HistoryDTO ModelToDTOMapper(HistoryModel input)
        {
            return new HistoryDTO
            {
                Id = input.Id,
                AdmissionDate = input.AdmissionDate,
                DepartureDate = input.DepartureDate,
                Description = input.Description,
                IdPackage = input.IdPackage,
                IdWarehouse = input.IdWarehouse
            };
        }

        public override IEnumerable<HistoryDTO> ModelToDTOMapper(IEnumerable<HistoryModel> input)
        {
            IList<HistoryDTO> list = new List<HistoryDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}

