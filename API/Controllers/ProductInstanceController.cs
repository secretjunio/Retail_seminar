using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductInstanceController : ControllerBase
    {
        private readonly Context _context;

        public ProductInstanceController(Context context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("GetListProductInstance")]
        public IEnumerable<ProductInstance> GetListProductInstance()
        {
            return _context.ProductInstance.ToList();

        }
        [HttpGet]
        [Route("GetOneProductInstance")]
        public ProductInstance getproductinstance(string productInstanceID)
        {
            return _context.ProductInstance.Where(x => x.product_intance_id == productInstanceID).FirstOrDefault();
        }
       
        [HttpPost]
        [Route("AddProductInstance")]
        public IEnumerable<ProductInstance> AddProductInstance(ProductInstance p)
        {

            if (_context.ProductInstance.ToList().Where(x => x.product_intance_id == p.product_intance_id).FirstOrDefault() == null)
            {
                if (_context.ProductLine.ToList().Where(x => x.product_line_id == p.product_line_id).FirstOrDefault() != null)
                {
                    _context.ProductInstance.Add(p);
                    _context.SaveChanges();
                }

            }

            return _context.ProductInstance.ToList();
        }
        [HttpDelete]
        [Route("DeleteProductInstance")]
        public IEnumerable<ProductInstance> DeleteProductInstance(string productInstanceId)
        {
            var tmpDeliveryOrderDetail = _context.DeliveryOrderDetail.Where(x => x.product_instance_id == productInstanceId).FirstOrDefault();
            var tmpProductInstance = _context.ProductInstance.Where(x => x.product_intance_id == productInstanceId).FirstOrDefault();
            if (tmpProductInstance != null)
            {
                _context.ProductInstance.Remove(tmpProductInstance);
                if (tmpDeliveryOrderDetail != null)
                {
                    _context.DeliveryOrderDetail.Remove(tmpDeliveryOrderDetail);
                }
            }

            _context.SaveChanges();
            return _context.ProductInstance.ToList();
        }
    }
}
