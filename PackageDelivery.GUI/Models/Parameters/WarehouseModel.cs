using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class WarehouseModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Código")]
        public string Code { get; set; }

        [Required]
        [DisplayName("Dirección")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Latitud")]
        public string Latitude { get; set; }

        [Required]
        [DisplayName("Longitud")]
        public string Longitude { get; set; }

        [Required]
        [DisplayName("Municipio")]
        public long IdTown { get; set; }

        [Required]
        [DisplayName("Municipio")]
        public string TownName { get; set; }

        [Required]
        [DisplayName("Municipio")]
        public IEnumerable<TownModel> TownList { get; set; }
    }
}