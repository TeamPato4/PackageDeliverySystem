namespace PackageDelivery.Application.DTOs.Parameters
{
    public class TownDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? IdDepartment { get; set; }
        public string DepartmentName { get; set; }
    }
}
