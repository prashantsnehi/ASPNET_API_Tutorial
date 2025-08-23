using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API_Tutorial.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Tutorial.Infrastructure.EntityConfiguration;

public class UserConfiguratio : IEntityTypeConfiguration<User>
{
	
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users")
            .HasKey(x => x.UserId);
    }
}

