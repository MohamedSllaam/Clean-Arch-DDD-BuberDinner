namespace BuberDinner.Domain.Common.Models
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (left is null && right is null)
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return Equals(left, right);
        }
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }
        public override int GetHashCode()
        {
            return GetEqualityComponents()
            .Select(obj => obj?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x ^ y);
        }

        public bool Equals(ValueObject? other)
        {
            return other is not null && Equals((object)other);
        }
    }
    


    public class Price : ValueObject
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }

}