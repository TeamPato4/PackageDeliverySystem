namespace PackageDelivery.Repository.DBModels.Parameters
{
    public class WarehouseDBModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public long IdTown { get; set; }
        public string TownName { get; set;}
    }
}
