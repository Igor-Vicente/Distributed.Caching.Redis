using System.ComponentModel.DataAnnotations;

namespace Demo.Api.Models
{
    public struct AddOrderModel
    {
        [Required]
        public Guid ClientId { get; set; }

        public Guid? VoucherId { get; set; }

        [Required]
        public bool VoucherApplied { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
    }
}
