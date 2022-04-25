using System.ComponentModel.DataAnnotations;

namespace Seminar_Retail_NhanHang.Models
{
    public class ProductInstanceModel
    {
        //[Required]
        public string product_instance_id { get; set; }
        //[Required]
        public string product_line_id { get; set; }
    }
}
