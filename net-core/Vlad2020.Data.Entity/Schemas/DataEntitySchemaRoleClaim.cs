﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Data.Base;
using Vlad2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vlad2020.Data.Entity.Schema
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "RoleClaim".
    /// </summary>
    public class DataEntitySchemaRoleClaim : DataEntitySchema<DataEntityObjectRoleClaim>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaRoleClaim(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }        

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectRoleClaim> builder)
        {
            var setting = DataBaseSettings.RoleClaim;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);            

            builder.HasIndex(x => x.RoleId)
                .IsUnique()
                .HasName(setting.DbIndexForRoleId);

            builder.HasOne(x => x.ObjectRole)
                .WithMany(x => x.ObjectsRoleClaim)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(setting.DbForeignKeyToRole);
        }

        #endregion Public methods
    }
}