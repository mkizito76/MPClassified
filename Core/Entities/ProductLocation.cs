namespace Core.Entities
{
    public class ProductLocation : BaseEntity
    {
        public int CityId { get; set; }
        public City City { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}