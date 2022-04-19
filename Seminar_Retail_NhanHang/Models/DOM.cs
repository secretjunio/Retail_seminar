using System;
using System.ComponentModel.DataAnnotations;

namespace Seminar_Retail_NhanHang.Models
{
    public class DOM
    {

        public string delivery_order_id { get; set; }

        public int AutoID { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày đặt hàng")]
        [Display(Name = "Ngày tạo đơn")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string delivery_order_date { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn trạng thái đơn hàng")]
        [Display(Name = "Trạng thái đơn hàng")]
        public string order_status { get; set; }

        [Required(ErrorMessage = "Vui lòng điền số lượng sản phẩm mong muốn nhập")]
        [Range(10, int.MaxValue, ErrorMessage = "Vui lòng nhập số lượng từ 10 trở lên")]
        [Display(Name = "Số lượng sản phẩm mong muốn nhập")]
        public int expected_quantity { get; set; }

        [Display(Name = "Số lượng sản phẩm thực tế sau khi nhập")]
        public int actual_quantity { get; set; }

    }
}
