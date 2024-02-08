﻿using Booky.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booky.Infrastructure.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(200)
            .HasConversion(x => x.Value, value => new FirstName(value));

        builder.Property(x => x.LastName)
            .HasMaxLength(200)
            .HasConversion(x => x.Value, value => new LastName(value));

        builder.Property(x => x.Email)
            .HasMaxLength(400)
            .HasConversion(x => x.Value, value => new Domain.Users.Email(value));

        builder.HasIndex(x => x.Email).IsUnique();
    }
}