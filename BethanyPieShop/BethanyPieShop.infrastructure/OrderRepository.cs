using BethanyPieShop.Domain;

namespace BethanyPieShop.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PieContext pieContext;

        public OrderRepository(PieContext pieContext)
        {
            this.pieContext = pieContext;
        }

        public bool AddOrder(PieOrder order)
        {
            pieContext.orders.Add(order);

            pieContext.SaveChanges();

            return true;
        }

        public PieOrder GetPieOrderByOrderId(int orderId)
        {
            return pieContext.orders.Find(orderId);
        }
    }
}
