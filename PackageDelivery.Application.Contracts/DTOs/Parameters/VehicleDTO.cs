namespace PackageDelivery.Application.DTOs.Parameters
{
    public class VehicleDTO
    {
        public long Id { get; set; }
        public string Placa { get; set; }
        public long? IdTransportType { get; set; }
        public string TrasportTypeName { get; set; }
    }
}
