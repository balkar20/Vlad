﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Data.Base;
using Vlad2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vlad2020.Data.Entity.Schema
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "UserToken".
    /// </summary>
    public class DataEntitySchemaUserToken : DataEntitySchema<DataEntityObjectUserToken>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaUserToken(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectUserToken> builder)
        {
            var setting = DataBaseSettings.UserToken;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.UserId, x.LoginProvider, x.Name })
                .HasName(setting.DbPrimaryKey);

            builder.HasOne(x => x.ObjectUser)
                .WithMany(x => x.ObjectsUserToken)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUser);
        }

        #endregion Public methods
    }
}