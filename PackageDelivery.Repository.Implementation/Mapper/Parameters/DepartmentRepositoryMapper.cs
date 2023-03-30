using PackageDelivery.Repository.Contracts.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mapper.Parameters
{
    public class DepartmentRepositoryMapper : DBModelMapperBase<DepartmentDBModel, departamento>
    {
        public override DepartmentDBModel DatabaseToDBModelMapper(departamento input)
        {
            return new DepartmentDBModel()
            {
                Id = input.id,
                Name = input.nombre,
            };
        }

        public override IEnumerable<DepartmentDBModel> DatabaseToDBModelMapper(IEnumerable<departamento> input)
        {
            IList<DepartmentDBModel> list = new List<DepartmentDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override departamento DBModelToDatabaseMapper(DepartmentDBModel input)
        {
            return new departamento
            {
                id = input.Id,
                nombre = input.Name,
            };
        }

        public override IEnumerable<departamento> DBModelToDatabaseMapper(IEnumerable<DepartmentDBModel> input)
        {
            IList<departamento> list = new List<departamento>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
