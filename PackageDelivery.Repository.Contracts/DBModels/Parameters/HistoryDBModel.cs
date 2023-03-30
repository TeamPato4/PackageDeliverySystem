using System;
namespace PackageDelivery.Repository.Contracts.DBModels.Parameters
{
    public class HistoryDBModel
    {
        public long Id { get; set; }
        public System.DateTime AdmissionDate { get; set; }
        public System.DateTime DepartureDate{ get; set; }
        public string Description { get; set; }
        public Nullable<long> IdPackage { get; set; }
        public Nullable<long> IdWarehouse { get; set; }
    }
}
