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
    public class RoleMap : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("roles");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").IsRequired();

            builder.Property(t => t.Appid).HasColumnName("appid").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
            builder.Property(t => t.Summary).HasColumnName("summary").HasMaxLength(200);
            builder.Property(t => t.State).HasColumnName("state").IsRequired();
            builder.Property(t => t.CreateTime).HasColumnName("create_time").IsRequired();
            builder.Property(t => t.CreateUserId).HasColumnName("create_user_id").IsRequired();
            builder.Property(t => t.UpdateTime).HasColumnName("update_time").IsRequired();
            builder.Property(t => t.UpdateUserId).HasColumnName("update_user_id").IsRequired();
        }
    }
}
