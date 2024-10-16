using Domain.Entities.Base;
namespace Domain.Entities.Raflee
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid IdUser { get; set; }
    }
}
