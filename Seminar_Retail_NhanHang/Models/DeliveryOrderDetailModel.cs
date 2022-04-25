using System.ComponentModel.DataAnnotations;

namespace Seminar_Retail_NhanHang.Models
{
    public class DeliveryOrderDetailModel
    {
        [Required]
        public string delivery_order_id { get; set; }
        public string product_line_id { get; set; }
        public int quantity { get; set; }
    }
}
