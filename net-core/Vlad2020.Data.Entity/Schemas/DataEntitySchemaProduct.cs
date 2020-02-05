//Author Maxim Kuzmin//makc//

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
            var setting = DataBaseSettings.Product;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasColumnType("nvarchar(255)");
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description).IsRequired().IsUnicode();

            builder.Property(x => x.ObjectProductCategoryId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForProductCategoryId);

            builder.HasIndex(x => x.Name)
                .IsUnique()
                .HasName(setting.DbUniqueIndexForName);

            builder.HasOne(x => x.ObjectProductCategory)
                .WithMany(x => x.ObjectsProduct)
                .HasForeignKey(x => x.ObjectProductCategoryId)
                .HasConstraintName(setting.DbForeignKeyToProductCategory);
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
                ObjectProductCategoryId = new Random(Guid.NewGuid().GetHashCode()).Next(1, 10),
                Price = 1000M + id + (id / 100M),
                Description = $"Description-{id}",
            };
        }

        #endregion Private methods
    }
}