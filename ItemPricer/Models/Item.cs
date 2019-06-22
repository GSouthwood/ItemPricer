namespace ItemPricer.Models
{
    public class Item
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string PriceDisplay()
        {
            return Price.ToString("C2");
        }
    }
}