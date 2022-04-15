using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryOrderController : ControllerBase
    {
        private readonly Context _context;

        public DeliveryOrderController(Context context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("GetListDeliveryOrder")]
        public IEnumerable<DeliveryOrder> GetListDeliveryOrder()
        {
            return _context.DeliveryOrders.ToList();

        }
        [HttpGet]
        [Route("GetOneDeliveryOrder")]
        public DeliveryOrder getDeliveryOrder(string deliveryOrderId)
        {
            return _context.DeliveryOrders.Where(x => x.delivery_order_id == deliveryOrderId).FirstOrDefault();
        }
        [HttpPut]
        [Route("UpdateDeliveryOrder")]
        public void GetProductIntance(DeliveryOrder d)
        {
            if (d.delivery_order_id != "")
            {
                DeliveryOrder toUpdate = _context.DeliveryOrders
                  .Where(p => p.delivery_order_id == d.delivery_order_id).FirstOrDefault();
                DeliveryOrder tmp = new DeliveryOrder();
                tmp.delivery_order_id = toUpdate.delivery_order_id;//primary key can not change
                tmp.delivery_order_date = d.delivery_order_date;
                tmp.actual_quantity = d.actual_quantity;
                tmp.expected_quantity = d.expected_quantity;
                tmp.order_status = d.order_status;
                if (toUpdate != null)
                {
                    _context.Entry(toUpdate).CurrentValues.SetValues(tmp);
                }
            }
            _context.SaveChanges();
        }
        [HttpPost]
        [Route("AddDeliveryOrder")]
        public IEnumerable<DeliveryOrder> AddDeliveryOrder(DeliveryOrder d)
        {

            if (_context.DeliveryOrders.ToList().Where(x => x.delivery_order_id == d.delivery_order_id).FirstOrDefault() == null)
            {
                DeliveryOrder tmp=new DeliveryOrder();
                tmp.delivery_order_id = d.delivery_order_id;
                tmp.delivery_order_date = d.delivery_order_date;
                tmp.actual_quantity = d.actual_quantity;
                tmp.expected_quantity = d.expected_quantity;
                tmp.order_status = d.order_status;
                _context.DeliveryOrders.Add(tmp);
                _context.SaveChanges();

            }
            else
            {
                Console.WriteLine("can not insert duplicate");
            }

            return _context.DeliveryOrders.ToList();
        }
        [HttpDelete]
        [Route("DeleteDeliveryOrder")]
        public IEnumerable<DeliveryOrder> DeleteDeliveryOrder(string deliveryOrder)
        {
            var tmpDeliveryOrderDetail = _context.DeliveryOrderDetail.Where(x => x.delivery_order_id == deliveryOrder).ToList();
            var tmpDeliveryOrder = _context.DeliveryOrders.Where(x => x.delivery_order_id == deliveryOrder).FirstOrDefault();
            if (tmpDeliveryOrder != null)
            {
                
                if (tmpDeliveryOrderDetail != null)
                {
                    foreach(var i in tmpDeliveryOrderDetail)
                    {
                        _context.DeliveryOrderDetail.Remove(i);
                    }
                    _context.DeliveryOrders.Remove(tmpDeliveryOrder);
                }
            }

            _context.SaveChanges();
            return _context.DeliveryOrders.ToList();
        }
    }
}
