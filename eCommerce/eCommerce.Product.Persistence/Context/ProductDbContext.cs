using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Domain.Interfaces;
using eCommerce.Product.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using ProductEntity = eCommerce.Product.Domain.Aggregates.Products.Product;

namespace eCommerce.Product.Persistence.Context
{
    public class ProductDbContext : DbContext, IUnitOfWork
    {
        private readonly IAuditService _auditService;
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions, IAuditService auditService) : base(dbContextOptions)
        {
            _auditService = auditService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var modifiedEntries = GetModifiedEntries();
                _auditService.ApplyAuditInformation(modifiedEntries);

                var result = await base.SaveChangesAsync(cancellationToken);
                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
                //throw new ConcurrencyException("A concurrency error occurred while saving changes.", ex);
            }
        }

        private IEnumerable<EntityEntry> GetModifiedEntries()
        {
            return ChangeTracker
                .Entries()
                .Where(e => e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted);
        }
    }
}
