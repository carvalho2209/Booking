﻿using Booky.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booky.Infrastructure.Configurations;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");

        builder.HasKey(role => role.Id);

        builder.HasMany(role => role.Users)
            .WithMany(user => user.Roles);

        builder.HasData(Role.Registered);
    }
}