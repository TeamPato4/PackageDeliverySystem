using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class TownModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Municipio")]
        public string Name { get; set; }

        [DisplayName("Departamento")]
        public long? IdDepartment { get; set; }
    }
}
