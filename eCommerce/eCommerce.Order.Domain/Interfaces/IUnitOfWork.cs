namespace eCommerce.Order.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void AddPublishedEvent(Common.Events.Base.IntegrationEvent integrationEvent);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
