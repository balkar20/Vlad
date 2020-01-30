//Author Maxim Kuzmin//makc//

using Vlad2020.Data.Base;
using Vlad2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Vlad2020.Data.Entity.Schema
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "ProductFeature".
    /// </summary>
    public class DataEntitySchemaProductFeature : DataEntitySchema<DataEntityObjectProductFeature>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaProductFeature(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectProductFeature> builder)
        {
            var setting = DataBaseSettings.ProductFeature;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().IsFixedLength(false).IsUnicode().HasMaxLength(50);

            builder.HasIndex(x => x.Name)
                .IsUnique()
                .HasName(setting.DbUniqueIndexForName);
        }

        /// <summary>
        /// Засеять тестовые данные.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        public static void SeedTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataEntityObjectProductFeature>().HasData(
                Enumerable.Range(1, 10).Select(id => CreateTestDataItem(id)).ToArray()
                );
        }

        #endregion Public methods

        #region Private methods

        private static DataEntityObjectProductFeature CreateTestDataItem(long id)
        {
            return new DataEntityObjectProductFeature
            {
                Id = id,
                Name = $"Name-{id}"
            };
        }

        #endregion Private methods
    }
}
