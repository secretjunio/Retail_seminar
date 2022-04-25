using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities
{
    public class DeliveryOrderDetail
    {
        public string delivery_order_id { get; set; }
        public string product_line_id { get; set; }
        public int quantity{ get; set; }
    }
}
