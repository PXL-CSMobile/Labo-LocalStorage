namespace PieShop.API.Entities
{
    public class Pie
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Price { get; set; }

        public double PurchasePrice { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public bool InStock { get; set; }
    }
}
