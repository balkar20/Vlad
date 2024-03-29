﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Data.Base;
using Vlad2020.Data.Entity.Objects;
using Vlad2020.Data.Entity.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Vlad2020.Data.Entity.Db
{
    /// <summary>
    /// Данные. Entity Framework. База данных. Контекст.
    /// </summary>
    public class DataEntityDbContext : IdentityDbContext
        <
            DataEntityObjectUser,
            DataEntityObjectRole,
            long,
            DataEntityObjectUserClaim,
            DataEntityObjectUserRole,
            DataEntityObjectUserLogin,
            DataEntityObjectRoleClaim,
            DataEntityObjectUserToken
        >
    {
        #region Properties

        private DataBaseSettings DataBaseSettings { get; set; }

        /// <summary>
        /// Данные сущности "DummyMain".
        /// </summary>
        public DbSet<DataEntityObjectDummyMain> DummyMain { get; set; }

        /// <summary>
        /// Данные сущности "DummyManyToMany".
        /// </summary>
        public DbSet<DataEntityObjectDummyManyToMany> DummyManyToMany { get; set; }

        /// <summary>
        /// Данные сущности "DummyMainDummyManyToMany".
        /// </summary>
        public DbSet<DataEntityObjectDummyMainDummyManyToMany> DummyMainDummyManyToMany { get; set; }

        /// <summary>
        /// Данные сущности "DummyOneToMany".
        /// </summary>
        public DbSet<DataEntityObjectDummyOneToMany> DummyOneToMany { get; set; }

        /// <summary>
        /// Данные сущности "DummyTree".
        /// </summary>
        public DbSet<DataEntityObjectDummyTree> DummyTree { get; set; }

        /// <summary>
        /// Данные сущности "Product".
        /// </summary>
        public DbSet<DataEntityObjectProduct> Product { get; set; }

        /// <summary>
        /// Данные сущности "ProductCategory".
        /// </summary>
        public DbSet<DataEntityObjectProductCategory> ProductCategory { get; set; }

        /// <summary>
        /// Данные сущности "ProductFeature".
        /// </summary>
        public DbSet<DataEntityObjectProductFeature> ProductFeature { get; set; }

        /// <summary>
        /// Данные сущности "ProductProductFeature".
        /// </summary>
        public DbSet<DataEntityObjectProductProductFeature> ProductProductFeature { get; set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public DataEntityDbContext(DbContextOptions<DataEntityDbContext> options)
            : this(options, null)
        {
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Опции.</param>
        /// <param name="dataBaseSettings">Настройки основы данных.</param>
        public DataEntityDbContext(DbContextOptions<DataEntityDbContext> options, DataBaseSettings dataBaseSettings)
            : base(options)
        {
            DataBaseSettings = dataBaseSettings;
        }

        #endregion Constructors

        #region Protected methods

        /// <summary>
        /// Обработать событие создания модели.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyMain(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyManyToMany(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyMainDummyManyToMany(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyOneToMany(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyTree(DataBaseSettings));

            modelBuilder.ApplyConfiguration(new DataEntitySchemaProduct(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaProductCategory(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaProductFeature(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaProductProductFeature(DataBaseSettings));

            modelBuilder.ApplyConfiguration(new DataEntitySchemaRole(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaRoleClaim(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUser(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUserClaim(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUserLogin(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUserRole(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUserToken(DataBaseSettings));

#if TEST || DEBUG
            DataEntitySchemaDummyOneToMany.SeedTestData(modelBuilder);
            DataEntitySchemaDummyMain.SeedTestData(modelBuilder);
            DataEntitySchemaDummyManyToMany.SeedTestData(modelBuilder);
            DataEntitySchemaDummyMainDummyManyToMany.SeedTestData(modelBuilder);

            DataEntitySchemaProductCategory.SeedTestData(modelBuilder);
            DataEntitySchemaProduct.SeedTestData(modelBuilder);
            DataEntitySchemaProductFeature.SeedTestData(modelBuilder);
            DataEntitySchemaProductProductFeature.SeedTestData(modelBuilder);
#endif
        }

        #endregion Protected methods
    }
}