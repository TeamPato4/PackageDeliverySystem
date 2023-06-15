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
    public class WarehouseImpRepository : IWarehouseRepository
    {
        public WarehouseDBModel createRecord(WarehouseDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                bodega docType = db.bodega.Where(x => x.codigo.ToUpper().Trim().Equals(record.Code.ToUpper())).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();
                bodega dt = mapper.DBModelToDatabaseMapper(record);
                db.bodega.Add(dt);
                db.SaveChanges();
                dt.municipio = new municipio { nombre = record.TownName };
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
                    bodega record = db.bodega.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.bodega.Remove(record);
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
        public WarehouseDBModel getRecordById(int id)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                bodega record = db.bodega.Find(id);
                if (record == null)
                {
                    return null;
                }
                WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<WarehouseDBModel> getRecordsList(string filter)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                IEnumerable<bodega> list = db.bodega.Where(x => x.nombre.Contains(filter));
                WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(list);
            }
        }

        public WarehouseDBModel updateRecord(WarehouseDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                bodega td = db.bodega.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.nombre = record.Name;
                    td.codigo = record.Code;
                    td.direccion = record.Address;
                    td.latitud = record.Latitude;
                    td.longitud = record.Longitude;
                    td.idMunicipio = record.IdTown;

                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();

                    return mapper.DatabaseToDBModelMapper(td);
                }
            }
        }
    }
}
