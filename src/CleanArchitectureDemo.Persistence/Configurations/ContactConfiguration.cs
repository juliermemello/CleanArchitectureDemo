using CleanArchitectureDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureDemo.Persistence.Configurations;

internal class ContactConfiguration //: IEntityTypeConfiguration<Contact>
{
    //public void Configure(EntityTypeBuilder<Contact> builder)
    //{
    //    builder.Property(p => p.Name)
    //        .HasMaxLength(100)
    //        .IsRequired();

    //    builder.Property(p => p.Email)
    //        .HasMaxLength(100)
    //        .IsRequired();

    //    builder.Property(p => p.Phone)
    //        .HasMaxLength(30);

    //    builder.Property(p => p.MobilePhone)
    //        .HasMaxLength(30);

    //    builder.Property(p => p.Address)
    //        .HasMaxLength(100);

    //    builder.Property(p => p.City)
    //        .HasMaxLength(100);

    //    builder.Property(p => p.State)
    //        .HasMaxLength(100);

    //    builder.Property(p => p.PostalCode)
    //        .HasMaxLength(10);

    //    builder.Property(p => p.Country)
    //        .HasMaxLength(100);

    //    builder.Property(p => p.HomePage)
    //        .HasMaxLength(100);
    //}
}
