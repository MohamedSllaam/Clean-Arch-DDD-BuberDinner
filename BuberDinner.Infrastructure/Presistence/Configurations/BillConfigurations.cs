using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class BillConfigurations : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        ConfigureBillsTable(builder);
    }

    private static void ConfigureBillsTable(EntityTypeBuilder<Bill> builder)
    {
        builder
            .ToTable("Bills");

        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BillId.Create(value));

        builder
            .OwnsOne(b => b.Price);

        builder
            .Property(b => b.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder
            .Property(b => b.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder
            .Property(b => b.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));
    }
}