using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class TownRepositoryMapper : DBModelMapperBase<TownDBModel, municipio>
    {
        public override TownDBModel DatabaseToDBModelMapper(municipio input)
        {
            return new TownDBModel()
            {
                Id = input.id,
                Name = input.nombre,
                IdDepartment = input.idDepartamento,
                DepartmentName = input.departamento.nombre
            };
        }

        public override IEnumerable<TownDBModel> DatabaseToDBModelMapper(IEnumerable<municipio> input)
        {
            IList<TownDBModel> list = new List<TownDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override municipio DBModelToDatabaseMapper(TownDBModel input)
        {
            return new municipio()
            {
                id = input.Id,
                nombre = input.Name,
                idDepartamento = input.IdDepartment,
            };
        }

        public override IEnumerable<municipio> DBModelToDatabaseMapper(IEnumerable<TownDBModel> input)
        {
            IList<municipio> list = new List<municipio>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
