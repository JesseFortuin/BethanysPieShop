using BethanyPieShop.Shared.Dtos;

namespace BethanyPieShop.Application
{
    public interface IOrderFacade
    {
        public ApiResponseDto<bool> AddOrder(OrderDto orderDto);

        public ApiResponseDto<OrderDto> getOrderById(int OrderId);
    }
}