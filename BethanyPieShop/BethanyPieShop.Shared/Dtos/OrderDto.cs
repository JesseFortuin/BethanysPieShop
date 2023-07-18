namespace BethanyPieShop.Shared.Dtos
{
    public class OrderDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DeliveryAddress { get; set; }

        public string DeliveryState { get; set; }

        public int PostalCode { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string Price { get; set; }

        public string Pie { get; set; }

        public string Description { get; set; }

        public string Comment { get; set; }
    }
}