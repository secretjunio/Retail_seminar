using API.Entities;
using API.Persistance.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Persistance.Repository
{
    public class DeliveryOrderDetailRepository : IDeliveryOrderDetailRepository
    {
        private readonly Context _context;
        public DeliveryOrderDetailRepository(Context context)
        {
            this._context = context;
        }
        public void createDeliveryOrderDetail(DeliveryOrderDetail DeliveryOrderDetail)
        {
            _context.DeliveryOrderDetails.Add(DeliveryOrderDetail);
            _context.SaveChanges();
        }

        public void editDeliveryOrderDetail(DeliveryOrderDetail DeliveryOrderDetail)
        {
            var toUpdate = _context.DeliveryOrderDetails.Where(x => x.delivery_order_id == DeliveryOrderDetail.delivery_order_id).FirstOrDefault();
            DeliveryOrderDetail.delivery_order_id = toUpdate.delivery_order_id;
            if (toUpdate != null)
            {
                _context.Entry(toUpdate).CurrentValues.SetValues(DeliveryOrderDetail);
                _context.SaveChanges();
            }
        }

        public IEnumerable<DeliveryOrderDetail> DeliveryOrderDetails()
        {
            return _context.DeliveryOrderDetails.ToList();
        }

        public DeliveryOrderDetail FindById(string Id)
        {
            return _context.DeliveryOrderDetails.Find(Id);
        }

        public void removeDeliveryOrderDetail(string Id)
        {
            _context.DeliveryOrderDetails.Remove(_context.DeliveryOrderDetails.Find(Id));
            _context.SaveChanges();
        }
    }
}
