using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers
{
    public abstract class DBModelMapperBase<DbModelType, DatabaseType>
    {
        public abstract DbModelType DatabaseToDBModelMapper(DatabaseType input);
        public abstract DatabaseType DBModelToDatabaseMapper(DbModelType input);
        public abstract IEnumerable<DbModelType> DatabaseToDBModelMapper(IEnumerable<DatabaseType> input);
        public abstract IEnumerable<DatabaseType> DBModelToDatabaseMapper(IEnumerable<DbModelType> input);
    }
}
