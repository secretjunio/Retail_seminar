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
            return _context.ProductInstances.ToList();

        }
        [HttpGet]
        [Route("GetOneProductInstance")]
        public ProductInstance getproductinstance(string productInstanceID)
        {
            return _context.ProductInstances.Where(x => x.product_instance_id == productInstanceID).FirstOrDefault();
        }
       
        [HttpPost]
        [Route("AddProductInstance")]
        public IEnumerable<ProductInstance> AddProductInstance(ProductInstance p)
        {

            if (_context.ProductInstances.ToList().Where(x => x.product_instance_id == p.product_instance_id).FirstOrDefault() == null)
            {
                //if (_context.ProductLine.ToList().Where(x => x.product_line_id == p.product_line_id).FirstOrDefault() != null)
                //{
              
                _context.ProductInstances.Add(p);
                _context.SaveChanges();
                //}

            }

            return _context.ProductInstances.ToList();
        }
        [HttpDelete]
        [Route("DeleteProductInstance")]
        public IEnumerable<ProductInstance> DeleteProductInstance(string productInstanceId)
        {
           
            var tmpProductInstance = _context.ProductInstances.Where(x => x.product_instance_id == productInstanceId).FirstOrDefault();
            if (tmpProductInstance != null)
            {
                _context.ProductInstances.Remove(tmpProductInstance);
            }

            _context.SaveChanges();
            return _context.ProductInstances.ToList();
        }
    }
}
