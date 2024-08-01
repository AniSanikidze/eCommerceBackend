using eCommerce.Order.Domain.Interfaces;
using OrderEntity = eCommerce.Order.Domain.Orders.Order;
using eCommerce.Order.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using eCommerce.Common.Events.Base;
using eCommerce.Order.Domain.Outbox.Publisher;
using eCommerce.Order.Domain.Outbox;

namespace eCommerce.Order.Persistence.Context
{
    public class OrderDbContext : DbContext, IUnitOfWork
    {
        private readonly IAuditService _auditService;

        private List<IntegrationEvent> publishedEvents = new List<IntegrationEvent>();
        public IReadOnlyCollection<IntegrationEvent> PublishedEvents => publishedEvents;

        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PublisherOutboxMessage> PublisherOutboxMessages { get; set; }
        public DbSet<ConsumerOutboxMessage> ConsumerOutboxMessages { get; set; }

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

        public void AddPublishedEvent(IntegrationEvent integrationEvent)
        {
            publishedEvents.Add(integrationEvent);
        }

        public void ClearPublishedEvents()
        {
            publishedEvents.Clear();
        }
    }
}
