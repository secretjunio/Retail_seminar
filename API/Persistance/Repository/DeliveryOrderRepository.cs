using API.Entities;
using API.Persistance.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Persistance.Repository
{
    public class DeliveryOrderRepository : IDeliveryOrderRepository
    {
        private readonly Context context;
        public DeliveryOrderRepository(Context context)
        {
            this.context = context;
        }
        public void createDeliveryOrder(DeliveryOrder DeliveryOrder)
        {
            context.DeliveryOrders.Add(DeliveryOrder);
            context.SaveChanges();
        }

        public void editDeliveryOrder(DeliveryOrder DeliveryOrder)
        {
            //context.DeliveryOrders.Update(DeliveryOrder);
            context.SaveChanges();
        }

        public IEnumerable<DeliveryOrder> DeliveryOrders()
        {
            return context.DeliveryOrders.ToList();
        }

        public DeliveryOrder FindByID(string id)
        {
            return context.DeliveryOrders.Find(id);
        }

        public void removeDeliveryOrder(string id)
        {
            context.DeliveryOrders.Remove(context.DeliveryOrders.Find(id));
            context.SaveChanges();
        }
    }
}
