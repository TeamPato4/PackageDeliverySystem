using PackageDelivery.Repository.Contracts.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mapper.Parameters
{
    internal class DeliveryRepositoryMapper : DBModelMapperBase<DeliveryDBModel, envio>
    {
        public override DeliveryDBModel DatabaseToDBModelMapper(envio input)
        {
            return new DeliveryDBModel()
            {
                Id = input.id,
                SendDate = input.fechaEnvio,
                Price = input.precio,
                IdSender = input.idRemitente,
                IdAddressDestination = input.idDireccionDestino,
                IdPackage = input.idPaquete,
                IdDeliveryState = input.idEstado,
                IdTransportType = input.idTipoTransporte
            };
        }

        public override IEnumerable<DeliveryDBModel> DatabaseToDBModelMapper(IEnumerable<envio> input)
        {
            IList<DeliveryDBModel> list = new List<DeliveryDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override envio DBModelToDatabaseMapper(DeliveryDBModel input)
        {
            return new envio
            {
                id = input.Id,
                fechaEnvio = input.SendDate,
                precio = input.Price,
                idRemitente = input.IdSender,
                idDireccionDestino = input.IdAddressDestination,
                idPaquete = input.IdPackage,
                idEstado = input.IdDeliveryState,
                idTipoTransporte = input.IdTransportType
            };
        }

        public override IEnumerable<envio> DBModelToDatabaseMapper(IEnumerable<DeliveryDBModel> input)
        {
            IList<envio> list = new List<envio>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
