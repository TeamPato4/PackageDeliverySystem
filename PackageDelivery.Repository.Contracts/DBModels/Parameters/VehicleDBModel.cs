namespace PackageDelivery.Repository.DBModels.Parameters
{
    public class VehicleDBModel
    {
        public long Id { get; set; }
        public string Plate { get; set; }
        public long? IdTransportType { get; set; }
    }
}
