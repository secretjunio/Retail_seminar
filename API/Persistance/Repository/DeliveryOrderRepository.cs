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
        private readonly Context _context;
        public DeliveryOrderRepository(Context context)
        {
            this._context = context;
        }
        public void createDeliveryOrder(DeliveryOrder DeliveryOrder)
        {
            _context.DeliveryOrders.Add(DeliveryOrder);
            _context.SaveChanges();
        }

        public void editDeliveryOrder(DeliveryOrder DeliveryOrder)
        {
            var toUpdate = _context.DeliveryOrders.Where(x => x.delivery_order_id == DeliveryOrder.delivery_order_id).FirstOrDefault();
            DeliveryOrder.delivery_order_id = toUpdate.delivery_order_id;
            if (toUpdate != null)
            {
                _context.Entry(toUpdate).CurrentValues.SetValues(DeliveryOrder);
                _context.SaveChanges();
            }
        }

        public IEnumerable<DeliveryOrder> DeliveryOrders()
        {
            return _context.DeliveryOrders.ToList();
        }

        public DeliveryOrder FindById(string Id)
        {
            return _context.DeliveryOrders.Find(Id);
        }

        public void removeDeliveryOrder(string Id)
        {
            _context.DeliveryOrders.Remove(_context.DeliveryOrders.Find(Id));
            _context.SaveChanges();
        }
    }
}
