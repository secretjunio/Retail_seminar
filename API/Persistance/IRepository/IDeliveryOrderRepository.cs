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
        DeliveryOrder FindByID(string id);
        IEnumerable<DeliveryOrder> DeliveryOrders();
        void createDeliveryOrder(DeliveryOrder DeliveryOrder);
        void editDeliveryOrder(DeliveryOrder DeliveryOrder);
        void removeDeliveryOrder(string id);
    }
}
