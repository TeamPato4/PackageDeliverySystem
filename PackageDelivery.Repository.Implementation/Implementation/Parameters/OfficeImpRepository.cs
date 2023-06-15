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
    public class OfficeImpRepository : IOfficeRepository
    {
        public OfficeDBModel createRecord(OfficeDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                oficina docType = db.oficina.Where(x => x.nombre.ToUpper().Trim().Equals(record.Name.ToUpper())).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();
                oficina dt = mapper.DBModelToDatabaseMapper(record);
                db.oficina.Add(dt);
                db.SaveChanges();
                return mapper.DatabaseToDBModelMapper(dt);
            }
        }

        public DocumentTypeDBModel createRecord(DocumentTypeDBModel record)
        {
            throw new NotImplementedException();
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
                    oficina record = db.oficina.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.oficina.Remove(record);
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
        public OfficeDBModel getRecordById(int id)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                oficina record = db.oficina.Find(id);
                if (record == null)
                {
                    return null;
                }
                OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<OfficeDBModel> getRecordsList(string filter)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                IEnumerable<oficina> list = db.oficina.Where(x => x.nombre.Contains(filter));
                OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(list);
            }
        }

        public OfficeDBModel updateRecord(OfficeDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                oficina td = db.oficina.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.nombre = record.Name;

                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();

                    return mapper.DatabaseToDBModelMapper(td);
                }
            }
        }

        public DocumentTypeDBModel updateRecord(DocumentTypeDBModel record)
        {
            throw new NotImplementedException();
        }

        DocumentTypeDBModel IOfficeRepository.getRecordById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DocumentTypeDBModel> IOfficeRepository.getRecordsList(string filter)
        {
            throw new NotImplementedException();
        }
    }
}