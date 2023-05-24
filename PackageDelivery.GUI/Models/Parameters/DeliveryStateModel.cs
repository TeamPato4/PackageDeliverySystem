using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class DeliveryStateModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Estado de envio")]
        public string Name { get; set; }
    }
}
