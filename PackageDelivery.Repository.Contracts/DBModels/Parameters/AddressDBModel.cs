namespace PackageDelivery.Repository.Contracts.DBModels.Parameters
{
    public class AddressDBModel
    {
        public long Id { get; set; }
        public string StreetType { get; set; }
        public string Number { get; set; }
        public string PropertyType { get; set; }
        public string Neighborhood { get; set; }
        public string Observations { get; set; }
        public bool Current { get; set; }
        public long? IdTown { get; set; }
        public long IdPerson { get; set; }
    }
}
