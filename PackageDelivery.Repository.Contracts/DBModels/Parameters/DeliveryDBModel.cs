using System;

namespace PackageDelivery.Repository.Contracts.DBModels.Parameters
{
    public class DeliveryDBModel
    {
        public long Id { get; set; }
        public System.DateTime SendDate { get; set; }
        public decimal Price { get; set; }
        public Nullable<long> IdSender { get; set; }
        public Nullable<long> IdAddressDestination { get; set; }
        public Nullable<long> IdPackage { get; set; }
        public Nullable<long> IdDeliveryState { get; set; }
        public Nullable<long> IdTransportType { get; set; }

    }
}
