using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class HistoryApplicationMapper : DTOMapperBase<HistoryDTO, HistoryDBModel>
    {
        public override HistoryDTO DBModelToDTOMapper(HistoryDBModel input)
        {
            return new HistoryDTO()
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

        public override IEnumerable<HistoryDTO> DBModelToDTOMapper(IEnumerable<HistoryDBModel> input)
        {
            IList<HistoryDTO> list = new List<HistoryDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override HistoryDBModel DTOToDBModelMapper(HistoryDTO input)
        {
            return new HistoryDBModel
            {
                Id = input.Id,
                AdmissionDate = input.AdmissionDate,
                DepartureDate = input.DepartureDate,
                Description = input.Description,
                IdPackage = input.IdPackage,
                IdWarehouse = input.IdWarehouse
            };
        }

        public override IEnumerable<HistoryDBModel> DTOToDBModelMapper(IEnumerable<HistoryDTO> input)
        {
            IList<HistoryDBModel> list = new List<HistoryDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}

