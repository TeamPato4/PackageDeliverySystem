using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Repository.Contracts.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class PersonApplicationMapper : DTOApplicationMapper<PersonDTO, PersonDBModel>
    {
        public override PersonDTO ApplicationlToDTOMapper(PersonDBModel input)
        {
            return new PersonDTO
            {
                Id = input.Id,
                FirstName = input.FirstName,
                OtherNames = input.OtherNames,
                FirstLastname = input.FirstLastname,
                SecondLastname = input.SecondLastname,
                IdentificationType = input.IdentificationType,
                IdentificationNumber = input.IdentificationNumber,
                cellphone = input.cellphone,
                email = input.email,
            };
        }

        public override IEnumerable<PersonDTO> ApplicationlToDTOMapper(IEnumerable<PersonDBModel> input)
        {
            IList<PersonDTO> list = new List<PersonDTO>();
            foreach (var item in input)
            {
                list.Add(this.ApplicationlToDTOMapper(item));
            }
            return list;
        }

        public override PersonDBModel DTOToApplicationlMapper(PersonDTO input)
        {
            return new PersonDBModel
            {
                Id = input.Id,
                FirstName = input.FirstName,
                OtherNames = input.OtherNames,
                FirstLastname = input.FirstLastname,
                SecondLastname = input.SecondLastname,
                IdentificationType = input.IdentificationType,
                IdentificationNumber = input.IdentificationNumber,
                cellphone = input.cellphone,
                email = input.email,
            };
        }

        public override IEnumerable<PersonDBModel> DTOToApplicationlMapper(IEnumerable<PersonDTO> input)
        {
            IList<PersonDBModel> list = new List<PersonDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToApplicationlMapper(item));
            }
            return list;
        }
    }
}
