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
    public class AdminRoleMap : IEntityTypeConfiguration<AdminRoles>
    {
        public void Configure(EntityTypeBuilder<AdminRoles> builder)
        {
            builder.ToTable("admin_roles");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").IsRequired();

            builder.Property(t => t.Appid).HasColumnName("appid").IsRequired();
            builder.Property(t => t.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(t => t.RoleId).HasColumnName("role_id").IsRequired();
        }
    }
}
