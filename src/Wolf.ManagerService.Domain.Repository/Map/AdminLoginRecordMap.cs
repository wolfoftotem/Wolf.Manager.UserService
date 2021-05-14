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
    public class AdminLoginRecordMap : IEntityTypeConfiguration<AdminLoginRecords>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<AdminLoginRecords> builder)
        {
            builder.ToTable("admin_login_records");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasMaxLength(36).IsRequired();

            builder.Property(t => t.UserId).HasColumnName("user_id").HasMaxLength(36);
            builder.Property(t => t.Appid).HasColumnName("appid");
            builder.Property(t => t.Ip).HasColumnName("ip").HasMaxLength(15);
            builder.Property(t => t.UserAgent).HasColumnName("user_agent").HasMaxLength(500);
            builder.Property(t => t.CreateTime).HasColumnName("create_time");
        }
    }
}
