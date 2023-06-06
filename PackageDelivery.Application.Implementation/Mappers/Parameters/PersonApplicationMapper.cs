using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Repository.DBModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class PersonApplicationMapper : DTOMapperBase<PersonDTO, PersonDBModel>
    {
        public override PersonDTO DBModelToDTOMapper(PersonDBModel input)
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
                Cellphone = input.Cellphone,
                Email = input.Email
            };
        }

        public override IEnumerable<PersonDTO> DBModelToDTOMapper(IEnumerable<PersonDBModel> input)
        {
            IList<PersonDTO> list = new List<PersonDTO>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDTOMapper(item));
            }
            return list;
        }

        public override PersonDBModel DTOToDBModelMapper(PersonDTO input)
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
                Cellphone = input.Cellphone,
                Email = input.Email
            };
        }

        public override IEnumerable<PersonDBModel> DTOToDBModelMapper(IEnumerable<PersonDTO> input)
        {
            IList<PersonDBModel> list = new List<PersonDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDBModelMapper(item));
            }
            return list;
        }
    }
}
