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
    public class ApplicationMap : IEntityTypeConfiguration<Applications>
    {
        public void Configure(EntityTypeBuilder<Applications> builder)
        {
            builder.ToTable("applications");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();

            builder.Property(t => t.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
            builder.Property(t => t.State).HasColumnName("state");
            builder.Property(t => t.Summary).HasColumnName("summary").HasMaxLength(50);
            builder.Property(t => t.CreateTime).HasColumnName("create_time").IsRequired();
            builder.Property(t => t.AddUserId).HasColumnName("add_user_id").IsRequired();
            builder.Property(t => t.UpdateTime).HasColumnName("update_time").IsRequired();
            builder.Property(t => t.EditUserId).HasColumnName("edit_user_id").IsRequired();
        }
    }
}
