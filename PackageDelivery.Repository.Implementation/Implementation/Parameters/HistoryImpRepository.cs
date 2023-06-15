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
    public class HistoryImpRepository : IHistoryRepository
    {
        public HistoryDBModel createRecord(HistoryDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                historial docType = db.historial.Where(x => x.descripcion.ToUpper().Trim().Equals(record.Description.ToUpper())).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                HistoryRepositoryMapper mapper = new HistoryRepositoryMapper();
                historial dt = mapper.DBModelToDatabaseMapper(record);
                db.historial.Add(dt);
                db.SaveChanges();
                dt.bodega = new bodega { nombre = record.WarehouseName };
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
                    historial record = db.historial.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.historial.Remove(record);
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
        public HistoryDBModel getRecordById(int id)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                historial record = db.historial.Find(id);
                if (record == null)
                {
                    return null;
                }
                HistoryRepositoryMapper mapper = new HistoryRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<HistoryDBModel> getRecordsList(string filter)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                IEnumerable<historial> list = db.historial.Where(x => x.descripcion.Contains(filter));
                HistoryRepositoryMapper mapper = new HistoryRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(list);
            }
        }

        public HistoryDBModel updateRecord(HistoryDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                historial td = db.historial.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.fechaIngreso = record.AdmissionDate;
                    td.fechaSalida = record.DepartureDate;
                    td.descripcion = record.Description;
                    td.idPaquete = record.IdPackage;
                    td.idBodega = record.IdWarehouse;

                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    HistoryRepositoryMapper mapper = new HistoryRepositoryMapper();

                    return mapper.DatabaseToDBModelMapper(td);
                }
            }
        }
    }
}
