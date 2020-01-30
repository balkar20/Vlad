﻿//Author Maxim Kuzmin//makc//

using Vlad2020.Data.Base;
using Vlad2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Vlad2020.Data.Entity.Schema
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "Product".
    /// </summary>
    public class DataEntitySchemaProduct : DataEntitySchema<DataEntityObjectProduct>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaProduct(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }        

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectProduct> builder)
        {
            //var setting = DataBaseSettings.Product;

            //builder.ToTable(setting.DbTable, setting.DbSchema);

            //builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);            

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.PropBoolean).IsRequired();
            builder.Property(x => x.PropBooleanNullable);
            builder.Property(x => x.PropDate).IsRequired();
            builder.Property(x => x.PropDateNullable);
            builder.Property(x => x.PropDateTimeOffset).IsRequired();
            builder.Property(x => x.PropDateTimeOffsetNullable);
            builder.Property(x => x.PropDecimal).IsRequired();
            builder.Property(x => x.PropDecimalNullable);
            builder.Property(x => x.PropInt32).IsRequired();
            builder.Property(x => x.PropInt32Nullable);
            builder.Property(x => x.PropInt64).IsRequired();
            builder.Property(x => x.PropInt64Nullable);
            builder.Property(x => x.PropString).IsRequired().IsUnicode();
            builder.Property(x => x.PropStringNullable).IsUnicode();

            //builder.Property(x => x.ObjectDummyOneToManyId)
            //    .IsRequired()
            //    .HasColumnName(setting.DbColumnForDummyOneToManyId);

            //builder.HasIndex(x => x.Name)
            //    .IsUnique()
            //    .HasName(setting.DbUniqueIndexForName);

            //builder.HasOne(x => x.ObjectDummyOneToMany)
            //    .WithMany(x => x.ObjectsProduct)
            //    .HasForeignKey(x => x.ObjectDummyOneToManyId)
            //    .HasConstraintName(setting.DbForeignKeyToDummyOneToMany);
        }

        /// <summary>
        /// Засеять тестовые данные.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        public static void SeedTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataEntityObjectProduct>().HasData(
                Enumerable.Range(1, 100).Select(id => CreateTestDataItem(id)).ToArray()
                );
        }

        #endregion Public methods

        #region Private methods

        private static DataEntityObjectProduct CreateTestDataItem(long id)
        {
            var isEven = id % 2 == 0;

            var day = isEven ? 2 : 1;

            var localTime = new DateTime(2018, 03, day, 06, 32, 00);

            var dateAndOffsetLocal = new DateTimeOffset(
                localTime, 
                TimeZoneInfo.Local.GetUtcOffset(localTime)
                );

            return new DataEntityObjectProduct
            {
                Id = id,
                Name = $"Name-{id}",
                ObjectDummyOneToManyId = new Random(Guid.NewGuid().GetHashCode()).Next(1, 10),
                PropBoolean = isEven,
                PropBooleanNullable = isEven ? new bool?(!isEven) : null,
                PropDate = new DateTime(2018, 01, day),
                PropDateNullable = isEven ? new DateTime?(new DateTime(2018, 02, day)) : null,
                PropDateTimeOffset = dateAndOffsetLocal,
                PropDateTimeOffsetNullable = isEven ? new DateTimeOffset?(dateAndOffsetLocal) : null,
                PropDecimal = 1000M + id + (id / 100M),
                PropDecimalNullable = isEven ? new decimal?(2000M + id + (id / 200M)) : null,
                PropInt32 = 1000 + (int)id,
                PropInt32Nullable = isEven ? new int?(1000 + (int)id) : null,
                PropInt64 = 3000 + id,
                PropInt64Nullable = isEven ? new long?(3000 + id) : null,
                PropString = $"PropString-{id}",
                PropStringNullable = isEven ? $"PropStringNullable-{id}" : null
            };
        }

        #endregion Private methods
    }
}