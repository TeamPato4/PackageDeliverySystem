using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class HistoryModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Fecha de ingreso")]
        public System.DateTime AdmissionDate { get; set; }

        [Required]
        [DisplayName("Fecha de salida")]
        public System.DateTime DepartureDate { get; set; }

        [Required]
        [DisplayName("Descripción")]
        public string Description { get; set; }

        [DisplayName("Paquete")]
        public long? IdPackage { get; set; }

        [DisplayName("Bodega")]
        public long? IdWarehouse { get; set; }

        [DisplayName("Bodega")]
        public string WarehouseName { get; set; }

        [DisplayName("Bodega")]
        public IEnumerable<WarehouseModel> WarehouseList { get; set; }
    }
}
