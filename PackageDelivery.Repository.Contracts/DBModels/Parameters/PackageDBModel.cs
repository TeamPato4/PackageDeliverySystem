namespace PackageDelivery.Repository.DBModels.Parameters
{
    public class PackageDBModel
    {
        public long Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Width { get; set; }
        public long? IdOffice { get; set; }
        public string OfficeName { get; set; }
    }
}
