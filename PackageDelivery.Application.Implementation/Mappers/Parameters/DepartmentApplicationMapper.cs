using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class DepartmentApplicationMapper : DTOMapperBase<DepartmentDTO, DepartmentDBModel>
    {
        public override DepartmentDTO DBModelToDTOMapper(DepartmentDBModel input)
        {
            return new DepartmentDTO()
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<DepartmentDTO> DBModelToDTOMapper(IEnumerable<DepartmentDBModel> input)
        {
            IList<DepartmentDTO> list = new List<DepartmentDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override DepartmentDBModel DTOToDBModelMapper(DepartmentDTO input)
        {
            return new DepartmentDBModel
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<DepartmentDBModel> DTOToDBModelMapper(IEnumerable<DepartmentDTO> input)
        {
            IList<DepartmentDBModel> list = new List<DepartmentDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}
