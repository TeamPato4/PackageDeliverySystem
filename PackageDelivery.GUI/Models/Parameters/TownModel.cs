using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

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

        [DisplayName("Departamento")]
        public string DepartmentName { get; set; }

        [DisplayName("Departamento")]
        public IEnumerable<DepartmentModel> DepartmentList { get; set; }
    }
}
