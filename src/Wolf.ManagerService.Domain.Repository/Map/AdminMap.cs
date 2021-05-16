// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wolf.ManagerService.Domain.AggregatesModel;

namespace Wolf.ManagerService.Domain.Repository.Map
{
    /// <summary>
    ///
    /// </summary>
    public class AdminMap : IEntityTypeConfiguration<Admins>
    {
        public void Configure(EntityTypeBuilder<Admins> builder)
        {
            builder.ToTable("admin");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasMaxLength(36).IsRequired();

            builder.Property(t => t.Account).HasColumnName("account").HasMaxLength(30).IsRequired();
            builder.Property(t => t.RealName).HasColumnName("real_name").HasMaxLength(20);
            builder.Property(t => t.PasswordSalt).HasColumnName("password_salt").HasMaxLength(6).IsRequired();
            builder.Property(t => t.PasswordHash).HasColumnName("password").HasMaxLength(200).IsRequired();
            builder.Property(t => t.UserState).HasColumnName("user_state").IsRequired();
            builder.Property(t => t.RegisterTime).HasColumnName("register_time").IsRequired();
            builder.Property(t => t.ForbitTime).HasColumnName("forbit_time");
            builder.Property(t => t.LastUpdateTime).HasColumnName("last_update_time").IsRequired();
        }
    }
}
