using BethanyPieShop.Domain;
using BethanyPieShop.Infrastructure;
using BethanyPieShop.Shared.Dtos;

namespace BethanyPieShop.Application
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IOrderRepository orderRepository;

        public OrderFacade(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public ApiResponseDto<bool> AddOrder(OrderDto orderDto)
        {
            var order = new PieOrder
            {
                FirstName = orderDto.FirstName,
                LastName = orderDto.LastName,
                DeliveryAddress = orderDto.DeliveryAddress,
                DeliveryState = orderDto.DeliveryState,
                PostalCode = orderDto.PostalCode,
                Longitude = orderDto.Longitude,
                Latitude = orderDto.Latitude,
                Comment = orderDto.Comment,
                Price = orderDto.Price,
                Pie = orderDto.Pie,
                Description = orderDto.Description
            };

            var result = orderRepository.AddOrder(order);

            return new ApiResponseDto<bool>(result);
        }

        public ApiResponseDto<OrderDto> getOrderById(int OrderId) 
        { 
            var order = orderRepository.GetPieOrderByOrderId(OrderId);

            var orderDto = new OrderDto
            {
                FirstName = order.FirstName,
                LastName = order.LastName,
                DeliveryAddress = order.DeliveryAddress,
                DeliveryState = order.DeliveryState,
                PostalCode = order.PostalCode,
                Longitude = order.Longitude,
                Latitude = order.Latitude,
                Comment = order.Comment,
                Price = order.Price,
                Pie = order.Pie,
                Description = order.Description
            };

            return new ApiResponseDto<OrderDto>(orderDto);
        }
    }
}