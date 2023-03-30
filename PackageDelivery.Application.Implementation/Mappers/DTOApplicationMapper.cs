using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers
{
    public abstract class DTOApplicationMapper<DTOBaseType, ApplicationBaseType>
    {
        public abstract ApplicationBaseType DTOToApplicationlMapper(DTOBaseType input);
        public abstract DTOBaseType ApplicationlToDTOMapper(ApplicationBaseType input);
        public abstract IEnumerable<ApplicationBaseType> DTOToApplicationlMapper(IEnumerable<DTOBaseType> input);
        public abstract IEnumerable<DTOBaseType> ApplicationlToDTOMapper(IEnumerable<ApplicationBaseType> input);
    }
}
