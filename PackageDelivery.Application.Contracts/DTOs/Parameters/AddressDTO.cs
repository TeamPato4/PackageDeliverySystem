namespace PackageDelivery.Application.DTOs.Parameters
{
    public class AddressDTO
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
        public string TownName { get; set; }
        public string PersonName { get; set; }
    }
}
