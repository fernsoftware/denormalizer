namespace Denormalizer.Entities.PowerBI
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public long DatabaseId { get; set; }
    }
}