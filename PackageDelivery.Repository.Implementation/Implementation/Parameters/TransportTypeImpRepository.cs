using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Parameters
{
    public class TransportTypeImpRepository : ITransportTypeRepository
    {
        public TransportTypeDBModel createRecord(TransportTypeDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                try
                {
                    TransportTypeRepositoryMapper mapper = new TransportTypeRepositoryMapper();
                    tipoTransporte newRecord = mapper.DBModelToDatabaseMapper(record);
                    db.tipoTransporte.Add(newRecord);
                    db.SaveChanges();
                    return record;
                }
                catch
                {
                    return null;
                }
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
                    tipoTransporte record = db.tipoTransporte.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.tipoTransporte.Remove(record);
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
        public TransportTypeDBModel getRecordById(int id)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                tipoTransporte record = db.tipoTransporte.Find(id);
                if (record == null)
                {
                    return null;
                }
                TransportTypeRepositoryMapper mapper = new TransportTypeRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<TransportTypeDBModel> getRecordsList(string filter)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                IEnumerable<tipoTransporte> list = db.tipoTransporte.Where(x => x.nombre.Contains(filter));
                TransportTypeRepositoryMapper mapper = new TransportTypeRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(list);
            }
        }

        public TransportTypeDBModel updateRecord(TransportTypeDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                try
                {
                    tipoTransporte existingRecord = db.tipoTransporte.Find(record.Id);
                    if (existingRecord == null)
                    {
                        return null;
                    }
                    TransportTypeRepositoryMapper mapper = new TransportTypeRepositoryMapper();
                    existingRecord = mapper.DBModelToDatabaseMapper(record); ;

                    db.SaveChanges();
                    return mapper.DatabaseToDBModelMapper(existingRecord);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}