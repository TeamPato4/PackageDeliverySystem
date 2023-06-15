using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

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

        [DisplayName("Tipo de transporte")]
        public string TransportTypeName { get; set; }

        [DisplayName("Tipo de transporte")]
        public IEnumerable<TransportTypeModel> TransportTypeList { get; set; }
    }
}
