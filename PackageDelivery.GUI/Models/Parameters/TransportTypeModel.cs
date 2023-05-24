using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class TransportTypeModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Tipo de transporte")]
        public string Name { get; set; }
    }
}
