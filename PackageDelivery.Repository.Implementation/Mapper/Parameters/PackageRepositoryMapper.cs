using PackageDelivery.Repository.Contracts.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mapper.Parameters
{
    public class PackageRepositoryMapper : DBModelMapperBase<PackageDBModel, paquete>
    {
        public override PackageDBModel DatabaseToDBModelMapper(paquete input)
        {
            return new PackageDBModel() {
                Id = input.id,
                Weight = input.peso,
                Height = input.altura,
                Depth = input.profundidad,
                Width = input.ancho,
                IdOffice = input.idOficina
            };    
        }

        public override IEnumerable<PackageDBModel> DatabaseToDBModelMapper(IEnumerable<paquete> input)
        {
            IList<PackageDBModel> list = new List<PackageDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override paquete DBModelToDatabaseMapper(PackageDBModel input)
        {
            return new paquete()
            {
                id = input.Id,
                peso = input.Weight,
                altura = input.Height,
                profundidad = input.Depth,
                ancho = input.Width,
                idOficina = input.IdOffice
            };
        }

        public override IEnumerable<paquete> DBModelToDatabaseMapper(IEnumerable<PackageDBModel> input)
        {
            IList<paquete> list = new List<paquete>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
