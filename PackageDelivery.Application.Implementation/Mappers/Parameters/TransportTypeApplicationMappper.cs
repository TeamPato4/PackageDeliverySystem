namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    using PackageDelivery.Application.Contracts.DTO;
    using PackageDelivery.Repository.Contracts.DBModels.Parameters;
    using System.Collections.Generic;
    public class TransportTypeApplicationMappper : DTOApplicationMapper<TransportTypeDTO, TransportTypeDBModel>
    {
        public override TransportTypeDTO ApplicationlToDTOMapper(TransportTypeDBModel input)
        {
            return new TransportTypeDTO
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<TransportTypeDTO> ApplicationlToDTOMapper(IEnumerable<TransportTypeDBModel> input)
        {
            IList<TransportTypeDTO> list = new List<TransportTypeDTO>();
            foreach (var item in input)
            {
                list.Add(this.ApplicationlToDTOMapper(item));
            }
            return list;
        }

        public override TransportTypeDBModel DTOToApplicationlMapper(TransportTypeDTO input)
        {
            return new TransportTypeDBModel
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<TransportTypeDBModel> DTOToApplicationlMapper(IEnumerable<TransportTypeDTO> input)
        {
            IList<TransportTypeDBModel> list = new List<TransportTypeDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToApplicationlMapper(item));
            }
            return list;
        }
    }
}
