namespace BuberDinner.Domain.Common.Models
{
    public class Entity<TId> :IEquatable<Entity<TId>>
        where TId : notnull
    {
        public TId Id { get; protected set; } = default!;

        protected Entity(TId id)
        {
            Id = id;
        }
        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Equals(entity);
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals((object?)other);
            // if (other is null) return false;
            // if (ReferenceEquals(this, other)) return true;
            // return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }
        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return Id is not null ? Id.GetHashCode() : 0;
        }
    }
   
}