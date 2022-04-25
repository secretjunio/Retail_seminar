using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Entities;

namespace API.Persistance.IRepository
{
    public interface IDeliveryOrderRepository
    {
        DeliveryOrder FindById(string Id);
        IEnumerable<DeliveryOrder> DeliveryOrders();
        void createDeliveryOrder(DeliveryOrder DeliveryOrder);
        void editDeliveryOrder(DeliveryOrder DeliveryOrder);
        void removeDeliveryOrder(string Id);
    }
    public interface ITagReaderRepository
    {
        TagReader FindById(string Id);
        IEnumerable<TagReader> TagReaders();
        void createTagReader(TagReader tagReader);
        void editTagReader(TagReader tagReader);
        void removeTagReader(string Id);
    }
    public interface IProductInstanceRepository
    {
        ProductInstance FindById(string Id);
        IEnumerable<ProductInstance> ProductInstances();
        void createProductInstance(ProductInstance productInstance);
        void editProductInstance(ProductInstance productInstance);
        void removeProductInstance(string Id);
    }
    public interface IProductLineRepository
    {
        ProductLine FindById(string Id);
        IEnumerable<ProductLine> ProductLines();
        void createProductLine(ProductLine productLine);
        void editProductLine(ProductLine productLine);
        void removeProductLine(string Id);
    }
    public interface IDeliveryOrderDetailRepository
    {
        DeliveryOrderDetail FindById(string Id,string lineId);
        IEnumerable<DeliveryOrderDetail> DeliveryOrderDetails();
        void createDeliveryOrderDetail(DeliveryOrderDetail deliveryOrderDetail);
        void editDeliveryOrderDetail(DeliveryOrderDetail deliveryOrderDetail);
        void removeDeliveryOrderDetail(string Id,string lineId);
    }
}
