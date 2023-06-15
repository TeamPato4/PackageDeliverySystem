namespace PackageDelivery.Repository.DBModels.Parameters
{
    public class DeliveryDBModel
    {
        public long Id { get; set; }
        public System.DateTime SendDate { get; set; }
        public decimal Price { get; set; }
        public long? IdSender { get; set; }
        public long? IdAddressDestination { get; set; }
        public long? IdPackage { get; set; }
        public long? IdDeliveryState { get; set; }
        public long? IdTransportType { get; set; }
        public string TrasportTypeName { get; set; }
        public string DeliveryStateName { get; set; }
    }
}
