﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Data.Base;
using Vlad2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vlad2020.Data.Entity.Schema
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "UserRole".
    /// </summary>
    public class DataEntitySchemaUserRole : DataEntitySchema<DataEntityObjectUserRole>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaUserRole(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectUserRole> builder)
        {
            var setting = DataBaseSettings.UserRole;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.UserId, x.RoleId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForUserId);

            builder.Property(x => x.RoleId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForRoleId);

            builder.HasOne(x => x.ObjectUser)
                .WithMany(x => x.ObjectsUserRole)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUser);

            builder.HasOne(x => x.ObjectRole)
                .WithMany(x => x.ObjectsUserRole)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(setting.DbForeignKeyToRole);

            builder.HasIndex(x => x.RoleId)
                .HasName(setting.DbIndexForRoleId);
        }

        #endregion Public methods
    }
}