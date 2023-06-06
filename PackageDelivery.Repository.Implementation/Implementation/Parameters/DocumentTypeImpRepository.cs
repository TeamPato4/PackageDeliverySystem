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
    public class DocumentTypeImpRepository : IDocumentTypeRepository
    {
        public DocumentTypeDBModel createRecord(DocumentTypeDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                tipoDocumento docType = db.tipoDocumento.Where(x => x.nombre.ToUpper().Trim().Equals(record.Name.ToUpper())).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                DocumentTypeRepositoryMapper mapper = new DocumentTypeRepositoryMapper();
                tipoDocumento dt = mapper.DBModelToDatabaseMapper(record);
                db.tipoDocumento.Add(dt);
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
                    tipoDocumento record = db.tipoDocumento.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.tipoDocumento.Remove(record);
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
        public DocumentTypeDBModel getRecordById(int id)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                tipoDocumento record = db.tipoDocumento.Find(id);
                if (record == null)
                {
                    return null;
                }
                DocumentTypeRepositoryMapper mapper = new DocumentTypeRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<DocumentTypeDBModel> getRecordsList(string filter)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                IEnumerable<tipoDocumento> list = db.tipoDocumento.Where(x => x.nombre.Contains(filter));
                DocumentTypeRepositoryMapper mapper = new DocumentTypeRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(list);
            }
        }

        public DocumentTypeDBModel updateRecord(DocumentTypeDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                tipoDocumento td = db.tipoDocumento.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.nombre = record.Name;

                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    DocumentTypeRepositoryMapper mapper = new DocumentTypeRepositoryMapper();

                    return mapper.DatabaseToDBModelMapper(td);
                }
            }
        }
    }
}
