using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryOrderDetailDetailController : ControllerBase
    {
        private readonly Context _context;

        public DeliveryOrderDetailDetailController(Context context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("GetListDeliveryOrderDetail")]
        public IEnumerable<DeliveryOrderDetail> GetListDeliveryOrderDetail()
        {
            return _context.DeliveryOrderDetail.ToList();

        }
        [HttpGet]
        [Route("GetOneDeliveryOrderDetail")]
        public DeliveryOrderDetail getDeliveryOrderDetail(string DeliveryOrderDetailId)
        {
            return _context.DeliveryOrderDetail.Where(x => x.delivery_order_id == DeliveryOrderDetailId).FirstOrDefault();
        }
        [HttpPut]
        [Route("UpdateDeliveryOrderDetail")]
        public void GetProductIntance(DeliveryOrderDetail d)
        {
            if (d.delivery_order_id != "")
            {
                DeliveryOrderDetail toUpdate = _context.DeliveryOrderDetail
                  .Where(p => p.delivery_order_id == d.delivery_order_id && p.product_instance_id == d.product_instance_id).FirstOrDefault();
                DeliveryOrderDetail tmp = new DeliveryOrderDetail();
                tmp.delivery_order_id = toUpdate.delivery_order_id;//primary key can not change
                tmp.product_instance_id = toUpdate.product_instance_id;
                tmp.is_checked = d.is_checked;
                if (toUpdate != null)
                {
                    _context.Entry(toUpdate).CurrentValues.SetValues(tmp);
                }
            }
            _context.SaveChanges();
        }
        [HttpPost]
        [Route("AddDeliveryOrderDetail")]
        public IEnumerable<DeliveryOrderDetail> AddDeliveryOrderDetail(DeliveryOrderDetail d)
        {

            if (_context.DeliveryOrderDetail.ToList().Where(x => x.delivery_order_id == d.delivery_order_id && x.product_instance_id == d.product_instance_id).FirstOrDefault() == null)
            {
                if (_context.DeliveryOrders.Where(x => x.delivery_order_id == d.delivery_order_id).FirstOrDefault() != null)
                {
                    DeliveryOrderDetail tmp = new DeliveryOrderDetail();
                    tmp.delivery_order_id = d.delivery_order_id;
                    tmp.product_instance_id = d.product_instance_id;
                    tmp.is_checked = d.is_checked;

                    _context.DeliveryOrderDetail.Add(tmp);
                    _context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("can not insert duplicate");
            }

            return _context.DeliveryOrderDetail.ToList();
        }
        [HttpDelete]
        [Route("DeleteDeliveryOrderDetail")]
        public IEnumerable<DeliveryOrderDetail> DeleteDeliveryOrderDetail(string DeliveryOrderDetail, string productInstanceId)
        {

            var tmpDeliveryOrderDetail = _context.DeliveryOrderDetail.Where(x => x.delivery_order_id == DeliveryOrderDetail && x.product_instance_id == productInstanceId).FirstOrDefault();
            if (tmpDeliveryOrderDetail != null)
            {
                _context.DeliveryOrderDetail.Remove(tmpDeliveryOrderDetail);

            }

            _context.SaveChanges();
            return _context.DeliveryOrderDetail.ToList();
        }
    }
}
