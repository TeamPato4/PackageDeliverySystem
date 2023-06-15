using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class PackageApplicationMapper : DTOMapperBase<PackageDTO, PackageDBModel>
    {
        public override PackageDTO DBModelToDTOMapper(PackageDBModel input)
        {
            return new PackageDTO()
            {
                Id = input.Id,
                Weight = input.Weight,
                Height = input.Height,
                Depth = input.Depth,
                Width = input.Width,
                IdOffice = input.IdOffice,
                OfficeName = input.OfficeName,
            };
        }

        public override IEnumerable<PackageDTO> DBModelToDTOMapper(IEnumerable<PackageDBModel> input)
        {
            IList<PackageDTO> list = new List<PackageDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override PackageDBModel DTOToDBModelMapper(PackageDTO input)
        {
            return new PackageDBModel()
            {
                Id = input.Id,
                Weight = input.Weight,
                Height = input.Height,
                Depth = input.Depth,
                Width = input.Width,
                IdOffice = input.IdOffice
            };
        }

        public override IEnumerable<PackageDBModel> DTOToDBModelMapper(IEnumerable<PackageDTO> input)
        {
            IList<PackageDBModel> list = new List<PackageDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}
