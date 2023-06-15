namespace PackageDelivery.Repository.DBModels.Parameters
{
    public class VehicleDBModel
    {
        public long Id { get; set; }
        public string Placa { get; set; }
        public long? IdTransportType { get; set; }
        public string TrasportTypeName { get; set; }
    }
}
