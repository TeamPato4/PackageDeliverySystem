using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Contracts.DBModels.Parameters
{
    public class PackageDBModel
    {
        public long Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Width { get; set; }
        public long? IdOffice { get; set; }
    }
}
