using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class TownApplicationMapper : DTOMapperBase<TownDTO, TownDBModel>
    {
        public override TownDTO DBModelToDTOMapper(TownDBModel input)
        {
            return new TownDTO()
            {
                Id = input.Id,
                Name = input.Name,
                IdDepartment = input.IdDepartment,
                DepartmentName = input.DepartmentName,
            };
        }

        public override IEnumerable<TownDTO> DBModelToDTOMapper(IEnumerable<TownDBModel> input)
        {
            IList<TownDTO> list = new List<TownDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override TownDBModel DTOToDBModelMapper(TownDTO input)
        {
            return new TownDBModel()
            {
                Id = input.Id,
                Name = input.Name,
                IdDepartment = input.IdDepartment,
            };
        }

        public override IEnumerable<TownDBModel> DTOToDBModelMapper(IEnumerable<TownDTO> input)
        {
            IList<TownDBModel> list = new List<TownDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}
