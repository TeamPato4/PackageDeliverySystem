using PackageDelivery.Repository.Contracts.DBModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mapper.Parameters
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
                cellphone = input.telefono,
                email = input.correo,
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
                primerNombre = input.FirstName,
                otrosNombres = input.OtherNames,
                primerApellido = input.FirstLastname,
                segundoApellido = input.SecondLastname,
                idTipoDocumento = input.IdentificationType,
                documento = input.IdentificationNumber,
                telefono = input.cellphone,
                correo = input.email,
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
