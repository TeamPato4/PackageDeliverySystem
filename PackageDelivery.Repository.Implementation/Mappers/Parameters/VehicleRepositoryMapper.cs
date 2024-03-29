﻿using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class VehicleRepositoryMapper : DBModelMapperBase<VehicleDBModel, vehiculo>
    {
        public override VehicleDBModel DatabaseToDBModelMapper(vehiculo input)
        {
            return new VehicleDBModel
            {
                Id = input.id,
                Placa = input.placa,
                IdTransportType = input.idTipoTransporte,
                TrasportTypeName = input.tipoTransporte.nombre
            };
        }

        public override IEnumerable<VehicleDBModel> DatabaseToDBModelMapper(IEnumerable<vehiculo> input)
        {
            IList<VehicleDBModel> list = new List<VehicleDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override vehiculo DBModelToDatabaseMapper(VehicleDBModel input)
        {
            return new vehiculo
            {
                id = input.Id,
                placa = input.Placa,
                idTipoTransporte = input.IdTransportType,
            };
        }

        public override IEnumerable<vehiculo> DBModelToDatabaseMapper(IEnumerable<VehicleDBModel> input)
        {
            IList<vehiculo> list = new List<vehiculo>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
