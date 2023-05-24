namespace PackageDelivery.Application.DTOs.Parameters
{
    public class HistoryDTO
    {
        public long Id { get; set; }
        public System.DateTime AdmissionDate { get; set; }
        public System.DateTime DepartureDate { get; set; }
        public string Description { get; set; }
        public long? IdPackage { get; set; }
        public long? IdWarehouse { get; set; }
    }
}
