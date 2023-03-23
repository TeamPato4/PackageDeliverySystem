using PackageDelivery.Repository.Contracts.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mapper.Parameters
{
    public class HistoryRepositoryMapper : DBModelMapperBase<HistoryDBModel, historial>
    {
        public override HistoryDBModel DatabaseToDBModelMapper(historial input)
        {
            return new HistoryDBModel()
            {
                Id = input.id,
                AdmissionDate = input.fechaIngreso,
                DepartureDate = input.fechaSalida,
                Description = input.descripcion,
                IdPackage = input.idPaquete,
                IdWarehouse = input.idBodega
            };
        }

        public override IEnumerable<HistoryDBModel> DatabaseToDBModelMapper(IEnumerable<historial> input)
        {
            IList<HistoryDBModel> list = new List<HistoryDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override historial DBModelToDatabaseMapper(HistoryDBModel input)
        {
            return new historial
            {
                id = input.Id,
                fechaIngreso = input.AdmissionDate,
                fechaSalida = input.DepartureDate,
                descripcion = input.Description,
                idPaquete = input.IdPackage,
                idBodega = input.IdWarehouse
            };
        }

        public override IEnumerable<historial> DBModelToDatabaseMapper(IEnumerable<HistoryDBModel> input)
        {
            IList<historial> list = new List<historial>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
