using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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

        [DisplayName("Observaciones")]
        public string Observations { get; set; }

        [Required]
        [DisplayName("Actual")]
        public bool Current { get; set; }

        [Required]
        [DisplayName("Municipio")]
        public long? IdTown { get; set; }

        [Required]
        [DisplayName("Persona")]
        public long IdPerson { get; set; }
    }
}