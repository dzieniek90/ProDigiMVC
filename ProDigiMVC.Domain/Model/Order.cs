namespace ProDigiMVC.Domain.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int OrderTypeId { get; set; }
        public virtual OrderType OrderType { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderedOn { get; set; }
        public DateTime Deadline { get; set; }
        public ICollection<OrderTag> OrderTags { get; set; }
    }
}