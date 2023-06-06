using PackageDelivery.Repository.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class PersonRepositoryMapper : DBModelMapperBase<PersonDBModel, persona>
    {
        public override PersonDBModel DatabaseToDBModelMapper(persona input)
        {
            return new PersonDBModel
            {
                Id = input.id,
                FirstName = input.primerNombre,
                OtherNames = input.otrosNombres,
                FirstLastname = input.primerApellido,
                SecondLastname = input.segundoApellido,
                IdentificationType = input.idTipoDocumento,
                IdentificationNumber = input.documento,
                Cellphone = input.telefono,
                Email = input.correo,
            };
        }

        public override IEnumerable<PersonDBModel> DatabaseToDBModelMapper(IEnumerable<persona> input)
        {
            IList<PersonDBModel> list = new List<PersonDBModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDBModelMapper(item));
            }
            return list;
        }

        public override persona DBModelToDatabaseMapper(PersonDBModel input)
        {
            return new persona
            {
                id = input.Id,
                primerNombre = input.FirstName.Trim(),
                otrosNombres = input.OtherNames.Trim(),
                primerApellido = input.FirstLastname.Trim(),
                segundoApellido = input.SecondLastname.Trim(),
                idTipoDocumento = input.IdentificationType,
                documento = input.IdentificationNumber.Trim(),
                telefono = input.Cellphone.Trim(),
                correo = input.Email.Trim(),
            };
        }

        public override IEnumerable<persona> DBModelToDatabaseMapper(IEnumerable<PersonDBModel> input)
        {
            IList<persona> list = new List<persona>();
            foreach (var item in input)
            {
                list.Add(this.DBModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
