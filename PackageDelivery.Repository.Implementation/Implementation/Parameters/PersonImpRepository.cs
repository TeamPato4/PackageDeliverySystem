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
    public class PersonImpRepository : IPersonRepository
    {
        public PersonDBModel createRecord(PersonDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                persona docType = db.persona.Where(x => x.documento.ToUpper().Trim().Equals(record.IdentificationNumber.ToUpper())).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                PersonRepositoryMapper mapper = new PersonRepositoryMapper();
                persona dt = mapper.DBModelToDatabaseMapper(record);
                dt.tipoDocumento = " ";
                db.persona.Add(dt);
                db.SaveChanges();
                dt.tipoDocumento1 = new tipoDocumento() {nombre = record.DocumentTypeName };
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
                    persona record = db.persona.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.persona.Remove(record);
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
        public PersonDBModel getRecordById(int id)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                persona record = db.persona.Find(id);
                if (record == null)
                {
                    return null;
                }
                PersonRepositoryMapper mapper = new PersonRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<PersonDBModel> getRecordsList(string filter)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                IEnumerable<persona> list = db.persona.Where(x => x.primerNombre.Contains(filter));
                PersonRepositoryMapper mapper = new PersonRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(list);
            }
        }

        public PersonDBModel updateRecord(PersonDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                persona td = db.persona.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.primerNombre = record.FirstName;
                    td.otrosNombres = record.OtherNames;
                    td.primerApellido = record.FirstLastname;
                    td.segundoApellido = record.SecondLastname;
                    td.documento = record.IdentificationNumber;
                    td.telefono = record.Cellphone;
                    td.correo = record.Email;
                    td.idTipoDocumento = record.IdentificationType;
                    td.tipoDocumento = " ";

                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    PersonRepositoryMapper mapper = new PersonRepositoryMapper();

                    return mapper.DatabaseToDBModelMapper(td);
                }
            }
        }
    }
}
