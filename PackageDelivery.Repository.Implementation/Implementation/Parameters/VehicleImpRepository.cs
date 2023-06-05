using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Parameters
{
    public class VehicleImpRepository : IVehicleRepository
    {
        public VehicleDBModel createRecord(VehicleDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                try
                {
                    VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();
                    vehiculo newRecord = mapper.DBModelToDatabaseMapper(record);
                    db.vehiculo.Add(newRecord);
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
                    vehiculo record = db.vehiculo.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.vehiculo.Remove(record);
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
        public VehicleDBModel getRecordById(int id)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                vehiculo record = db.vehiculo.Find(id);
                if (record == null)
                {
                    return null;
                }
                VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<VehicleDBModel> getRecordsList(string filter)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                IEnumerable<vehiculo> list = db.vehiculo.Where(x => x.placa.Contains(filter));
                VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(list);
            }
        }

        public VehicleDBModel updateRecord(VehicleDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                try
                {
                    vehiculo existingRecord = db.vehiculo.Find(record.Id);
                    if (existingRecord == null)
                    {
                        return null;
                    }
                    VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();
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