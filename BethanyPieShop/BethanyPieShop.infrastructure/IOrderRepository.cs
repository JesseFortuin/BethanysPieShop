using BethanyPieShop.Domain;

namespace BethanyPieShop.Infrastructure
{
    public interface IOrderRepository
    {
        public bool AddOrder(PieOrder order);

        public PieOrder GetPieOrderByOrderId(int orderId);
    }
}
