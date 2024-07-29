using eCommerce.Order.Domain.Interfaces;
using OrderEntity = eCommerce.Order.Domain.Orders.Order;
using eCommerce.Order.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;

namespace eCommerce.Order.Persistence.Context
{
    public class OrderDbContext : DbContext, IUnitOfWork
    {
        private readonly IAuditService _auditService;
        public DbSet<OrderEntity> Orders { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> dbContextOptions, IAuditService auditService) : base(dbContextOptions)
        {
            _auditService = auditService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDbContext).Assembly);
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
