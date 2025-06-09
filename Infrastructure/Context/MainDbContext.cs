using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Entities.Base;
using System.Reflection;

namespace Projeto_Aplicado_II_API.Infrastructure.Context
{
    public class MainDbContext : DbContext
    {
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<BranchSize> BranchSizes => Set<BranchSize>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
        public DbSet<ProductInInventory> ProductsInInventory => Set<ProductInInventory>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<SaleItem> SaleItems => Set<SaleItem>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<SupplierProduct> SupplierProducts => Set<SupplierProduct>();
        public DbSet<UnityOfMeasure> UnitiesOfMeasure => Set<UnityOfMeasure>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserBranch> UserBranches => Set<UserBranch>();

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            Database.AutoSavepointsEnabled = false;
            Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public async Task RunInTransactionAsync(Action query)
        {
            await Database.OpenConnectionAsync();
            using var transaction = await Database.BeginTransactionAsync();

            try
            {
                query();

                await SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await Database.CloseConnectionAsync();
            }
        }

        public async Task RunInTransactionAsync(Func<Task> query)
        {
            await Database.OpenConnectionAsync();
            using var transaction = await Database.BeginTransactionAsync();

            try
            {
                await query();

                await SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await Database.CloseConnectionAsync();
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                var entity = entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.SetCreatedNow();
                        break;

                    case EntityState.Modified:
                        entity.SetUpdatedNow();
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
