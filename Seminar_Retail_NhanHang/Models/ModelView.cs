using API.Entities;
using System.Collections.Generic;

namespace Seminar_Retail_NhanHang.Models
{
    public class ModelView
    {
        public IEnumerable<DeliveryOrder> DeliveryOrders { get; set; }
        public DeliveryOrder DeliveryOrder { get; set; }    
        public IEnumerable<DeliveryOrderDetail> DeliveryOrderDetails { get; set; }
        public DeliveryOrderDetail DeliveryOrderDetail { get; set; }   
        public ProductInstance ProductInstance { get; set; }
        public IEnumerable<ProductInstance> ProductInstances { get; set; }
        public IEnumerable<ProductLine> ProductLines { get; set; }
        public ProductLine ProductLine { get; set; }
        public TagReader tagReader { get; set; }
        public IEnumerable<TagReader> tagReaders { get; set; }

        public DeliveryOrderModel DOM { get; set; }
        public DeliveryOrderModel DeliveryOrderModel { get; set; }
        public ProductInstanceModel ProductInstanceModel { get; set; }
        public IEnumerable<ProductInstanceModel> ProductInstanceModels { get; set; }
    }
}
