using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class VehicleModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Placa")]
        public string Placa { get; set; }

        [Required]
        [DisplayName("Tipo de transporte")]
        public long? IdTransportType { get; set; }
    }
}
