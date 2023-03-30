using System;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.DBModels.Parameters
{
    public class TownDBModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? IdDepartment { get; set; }

        //public IEnumerable<WarehouseDBModel> Warehouses { get; set; }
        //public IEnumerable<departamento> Departments { get; set; }
        //public IEnumerable<string> MyProperty { get; set; }

    }

}
