using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class DeliveryOrderDetail
    {
        public string delivery_order_id { get; set; }
        public string product_instance_id { get; set; }
        public bool is_checked { get; set; }
    }
}
