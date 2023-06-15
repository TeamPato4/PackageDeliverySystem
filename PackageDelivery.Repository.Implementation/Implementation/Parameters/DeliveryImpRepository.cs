using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Parameters
{
    public class DeliveryImpRepository : IDeliveryRepository
    {
        public DeliveryDBModel createRecord(DeliveryDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                envio docType = db.envio.Where(x => x.id == record.Id).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                DeliveryRepositoryMapper mapper = new DeliveryRepositoryMapper();
                envio dt = mapper.DBModelToDatabaseMapper(record);
                db.envio.Add(dt);
                db.SaveChanges();
                return mapper.DatabaseToDBModelMapper(dt);
            }
        }

        /// <summary>
        /// Eliminación de un registro en la base de datos por Id
        /// </summary>
        /// <param name="id">Id del registro a eliminar</param>
        /// <returns>Booleano, true cuando se elimina y false cuando no se encuentra o está asociado como FK</returns>
        public bool deleteRecordById(int id)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                try
                {
                    envio record = db.envio.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.envio.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Obtiene el registro por Id
        /// </summary>
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>null cuando no lo encuentra o el objeto cunado si lo encuentra</returns>
        public DeliveryDBModel getRecordById(int id)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                envio record = db.envio.Find(id);
                if (record == null)
                {
                    return null;
                }
                DeliveryRepositoryMapper mapper = new DeliveryRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<DeliveryDBModel> getRecordsList(long filter)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                IEnumerable<envio> list = db.envio.Where(x => x.id == filter);
                DeliveryRepositoryMapper mapper = new DeliveryRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(list);
            }
        }

        public DeliveryDBModel updateRecord(DeliveryDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                envio td = db.envio.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.fechaEnvio = record.SendDate;
                    td.precio = record.Price;
                    td.idRemitente = record.IdSender;
                    td.idDireccionDestino = record.IdAddressDestination;
                    td.idPaquete = record.IdPackage;
                    td.idEstado = record.IdDeliveryState;
                    td.idTipoTransporte = record.IdTransportType;
                    

                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    DeliveryRepositoryMapper mapper = new DeliveryRepositoryMapper();

                    return mapper.DatabaseToDBModelMapper(td);
                }
            }
        }
    }
}
