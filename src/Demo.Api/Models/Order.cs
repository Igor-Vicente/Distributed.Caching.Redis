namespace Demo.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid? VoucherId { get; set; }
        public bool VoucherApplied { get; set; }
        public decimal TotalPrice { get; set; }
        //public List<PedidoItem> Items { get; set; } just an example
    }
}
