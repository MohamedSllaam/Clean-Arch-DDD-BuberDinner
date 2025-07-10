using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId, Guid>
{
    public Guest(GuestId id) : base(id)
    {
    }

#pragma warning disable CS8618
    private Guest() { }
#pragma warning restore CS8618
}