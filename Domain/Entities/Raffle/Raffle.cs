using Domain.Entities.Base;

namespace Domain.Entities.Raffle
{
    public class Raffle: EntityBase
    {
        public Guid UserId { get; set; }
        public string CodeGenerate { get; set; }
        public Guid ClientId { get; set; }
    }
}
