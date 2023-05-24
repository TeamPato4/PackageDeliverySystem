using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class TransportTypeApplicationMapper : DTOMapperBase<TransportTypeDTO, TransportTypeDBModel>
    {
        public override TransportTypeDTO DBModelToDTOMapper(TransportTypeDBModel input)
        {
            return new TransportTypeDTO
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<TransportTypeDTO> DBModelToDTOMapper(IEnumerable<TransportTypeDBModel> input)
        {
            IList<TransportTypeDTO> list = new List<TransportTypeDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override TransportTypeDBModel DTOToDBModelMapper(TransportTypeDTO input)
        {
            return new TransportTypeDBModel
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<TransportTypeDBModel> DTOToDBModelMapper(IEnumerable<TransportTypeDTO> input)
        {
            IList<TransportTypeDBModel> list = new List<TransportTypeDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}
