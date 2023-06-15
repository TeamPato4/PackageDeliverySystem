namespace PackageDelivery.Repository.DBModels.Parameters
{
    public class HistoryDBModel
    {
        public long Id { get; set; }
        public System.DateTime AdmissionDate { get; set; }
        public System.DateTime DepartureDate { get; set; }
        public string Description { get; set; }
        public long? IdPackage { get; set; }
        public long? IdWarehouse { get; set; }
        public string WarehouseName { get; set; }
    }
}
