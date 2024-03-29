﻿using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Parameters
{
    public class PackageImpRepository : IPackageRepository
    {
        public PackageDBModel createRecord(PackageDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                paquete docType = db.paquete.Where(x => x.id.Equals(record.Id)).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                paquete dt = mapper.DBModelToDatabaseMapper(record);
                db.paquete.Add(dt);
                db.SaveChanges();
                dt.oficina = new oficina { nombre = record.OfficeName };
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
                    paquete record = db.paquete.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.paquete.Remove(record);
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
        public PackageDBModel getRecordById(int id)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                paquete record = db.paquete.Find(id);
                if (record == null)
                {
                    return null;
                }
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<PackageDBModel> getRecordsList(long filter)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                IEnumerable<paquete> list = db.paquete.Where(x => x.id >= filter);
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                return mapper.DatabaseToDBModelMapper(list);
            }
        }

        public PackageDBModel updateRecord(PackageDBModel record)
        {
            using (MensajeriaDBEntities db = new MensajeriaDBEntities())
            {
                paquete td = db.paquete.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.id = record.Id;

                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    PackageRepositoryMapper mapper = new PackageRepositoryMapper();

                    return mapper.DatabaseToDBModelMapper(td);
                }
            }
        }

        public DocumentTypeDBModel updateRecord(DocumentTypeDBModel record)
        {
            throw new NotImplementedException();
        }

    }
}