using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class OfficeApplicationMapper : DTOMapperBase<OfficeDTO, OfficeDBModel>
    {
        public override OfficeDTO DBModelToDTOMapper(OfficeDBModel input)
        {
            return new OfficeDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Code = input.Code,
                Phone = input.Phone,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                IdTown = input.IdTown,
                Address = input.Address
            };
        }

        public override IEnumerable<OfficeDTO> DBModelToDTOMapper(IEnumerable<OfficeDBModel> input)
        {
            IList<OfficeDTO> list = new List<OfficeDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override OfficeDBModel DTOToDBModelMapper(OfficeDTO input)
        {
            return new OfficeDBModel()
            {
                Id = input.Id,
                Name = input.Name,
                Code = input.Code,
                Phone = input.Phone,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                IdTown = input.IdTown,
                Address = input.Address
            };
        }

        public override IEnumerable<OfficeDBModel> DTOToDBModelMapper(IEnumerable<OfficeDTO> input)
        {
            IList<OfficeDBModel> list = new List<OfficeDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}
