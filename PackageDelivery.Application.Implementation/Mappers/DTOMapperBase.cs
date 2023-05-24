using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers
{
    public abstract class DTOMapperBase<DTOType, DBModelType>
    {
        public abstract DTOType DBModelToDTOMapper(DBModelType input);
        public abstract DBModelType DTOToDBModelMapper(DTOType input);
        public abstract IEnumerable<DTOType> DBModelToDTOMapper(IEnumerable<DBModelType> input);
        public abstract IEnumerable<DBModelType> DTOToDBModelMapper(IEnumerable<DTOType> input);
    }
}
