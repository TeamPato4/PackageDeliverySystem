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
    public class AddressImpRepository : IAddressRepository
    {
        public AddressDBModel createRecord(AddressDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                direccion docType = db.direccion.Where(x => x.numero.ToUpper().Trim().Equals(record.Number.ToUpper())).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                direccion dt = mapper.DBModelToDatabaseMapper(record);
                db.direccion.Add(dt);
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
                    direccion record = db.direccion.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.direccion.Remove(record);
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
        public AddressDBModel getRecordById(int id)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                direccion record = db.direccion.Find(id);
                if (record == null)
                {
                    return null;
                }
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<AddressDBModel> getRecordsList(string filter)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                IEnumerable<direccion> list = db.direccion.Where(x => x.barrio.Contains(filter));
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(list);
            }
        }

        public AddressDBModel updateRecord(AddressDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                direccion td = db.direccion.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.tipoCalle = record.StreetType;
                    td.numero = record.Number;
                    td.tipoInmueble = record.PropertyType;
                    td.barrio = record.Neighborhood;
                    td.observaciones = record.Observations;
                    td.actual = record.Current;
                    td.idMunicipio = record.IdTown;
                    td.idPersona = record.IdPerson;

                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    AddressRepositoryMapper mapper = new AddressRepositoryMapper();

                    return mapper.DatabaseToDBModelMapper(td);
                }
            }
        }
    }
}
