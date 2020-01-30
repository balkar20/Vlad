//Author Maxim Kuzmin//makc//

using Vlad2020.Data.Base;
using Vlad2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vlad2020.Data.Entity.Schema
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "ProductProductFeature".
    /// </summary>
    public class DataEntitySchemaProductProductFeature : DataEntitySchema<DataEntityObjectProductProductFeature>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaProductProductFeature(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectProductProductFeature> builder)
        {
            var setting = DataBaseSettings.ProductProductFeature;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.ObjectProductId, x.ObjectProductFeatureId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ObjectProductId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForProductId);

            builder.Property(x => x.ObjectProductFeatureId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForProductFeatureId);

            builder.HasOne(x => x.ObjectProduct)
                .WithMany(x => x.ObjectsProductProductFeature)
                .HasForeignKey(x => x.ObjectProductId)
                .HasConstraintName(setting.DbForeignKeyToProduct);

            builder.HasOne(x => x.ObjectProductFeature)
                .WithMany(x => x.ObjectsProductProductFeature)
                .HasForeignKey(x => x.ObjectProductFeatureId)
                .HasConstraintName(setting.DbForeignKeyToProductFeature);
        }

        /// <summary>
        /// Засеять тестовые данные.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        public static void SeedTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataEntityObjectProductProductFeature>().HasData(
                Enumerable.Range(1, 100).SelectMany(id => CreateTestDataItem(id)).ToArray()
                );
        }

        #endregion Public methods

        #region Private methods

        private static List<DataEntityObjectProductProductFeature> CreateTestDataItem(long id)
        {
            var result = new List<DataEntityObjectProductProductFeature>();

            foreach (var linkedId in Enumerable.Range(1, 10))
            {
                var isEven = new Random(Guid.NewGuid().GetHashCode()).Next(1, 10) % 2 == 0;

                if (isEven) continue;

                var item = new DataEntityObjectProductProductFeature
                {
                    ObjectProductId = id,
                    ObjectProductFeatureId = linkedId,
                };

                result.Add(item);
            }

            return result;
        }

        #endregion Private methods
    }
}