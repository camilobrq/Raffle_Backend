using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities.Raffle
{
    public class Service: EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid IdUser { get; set; }
    }
}
