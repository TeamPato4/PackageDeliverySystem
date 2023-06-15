using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class AddressModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Tipo de calle")]
        public string StreetType { get; set; }

        [Required]
        [DisplayName("Número")]
        public string Number { get; set; }

        [Required]
        [DisplayName("Tipo de inmueble")]
        public string PropertyType { get; set; }

        [Required]
        [DisplayName("Barrio")]
        public string Neighborhood { get; set; }

        [Required]
        [DisplayName("Observaciones")]
        public string Observations { get; set; }

        [Required]
        [DisplayName("Actual")]
        public bool Current { get; set; }

        [DisplayName("Municipio")]
        public long? IdTown { get; set; }

        [Required]
        [DisplayName("Persona")]
        public long IdPerson { get; set; }

        [DisplayName("Municipio")]
        public string TownName { get; set; }

        [DisplayName("Municipio")]
        public IEnumerable<TownModel> TownList { get; set; }

        [Required]
        [DisplayName("Persona")]
        public string PersonName { get; set; }

        [Required]
        [DisplayName("Persona")]
        public IEnumerable<PersonModel> PersonList { get; set; }
    }
}