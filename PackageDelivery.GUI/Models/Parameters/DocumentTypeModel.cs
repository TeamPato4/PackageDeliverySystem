using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class DocumentTypeModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Tipo de documento")]
        public string Name { get; set; }
    }
}