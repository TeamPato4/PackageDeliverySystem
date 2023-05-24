using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class DeliveryModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Fecha de envio")]
        public System.DateTime SendDate { get; set; }

        [Required]
        [DisplayName("Precio")]
        public decimal Price { get; set; }

        [DisplayName("Remitente")]
        public long? IdSender { get; set; }

        [DisplayName("Dirección de destino")]
        public long? IdAddressDestination { get; set; }

        [DisplayName("Paquete")]
        public long? IdPackage { get; set; }

        [DisplayName("Estado del envio")]
        public long? IdDeliveryState { get; set; }

        [DisplayName("Tipo de transporte")]
        public long? IdTransportType { get; set; }
    }
}
