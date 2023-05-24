using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class DepartmentModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Departamento")]
        public string Name { get; set; }
    }
}