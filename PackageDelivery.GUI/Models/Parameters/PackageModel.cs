﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class PackageModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Peso")]
        public double Weight { get; set; }

        [Required]
        [DisplayName("Altura")]
        public double Height { get; set; }

        [Required]
        [DisplayName("Profundidad")]
        public double Depth { get; set; }

        [Required]
        [DisplayName("Ancho")]
        public double Width { get; set; }

        [DisplayName("Oficina")]
        public long? IdOffice { get; set; }

        [DisplayName("Oficina")]
        public string OfficeName { get; set; }

        [DisplayName("Oficina")]
        public IEnumerable<OfficeModel> OfficeList { get; set; }
    }
}
