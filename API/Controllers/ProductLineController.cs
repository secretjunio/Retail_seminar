using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductLineController : ControllerBase
    {
        private readonly Context _context;

        public ProductLineController(Context context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("GetListProductLine")]
        public IEnumerable<ProductLine> GetListProductLine()
        {
            return _context.ProductLine.ToList();

        }
        [HttpGet]
        [Route("GetOneProductLine")]
        public ProductLine getProductLine(string ProductLineID)
        {
            return _context.ProductLine.Where(x => x.product_line_id == ProductLineID).FirstOrDefault();
        }

        [HttpPost]
        [Route("AddProductLine")]
        public IEnumerable<ProductLine> AddProductLine(ProductLine p)
        {

            if (_context.ProductLine.ToList().Where(x => x.product_line_id == p.product_line_id).FirstOrDefault() == null)
            {
                    _context.ProductLine.Add(p);
                    _context.SaveChanges();
            }

            return _context.ProductLine.ToList();
        }
        [HttpDelete]
        [Route("DeleteProductLine")]
        public IEnumerable<ProductLine> DeleteProductLine(string ProductLineId)
        {
            var tmpProductInstance = _context.ProductInstance.Where(x => x.product_line_id == ProductLineId).ToList();
            var tmpProductLine = _context.ProductLine.Where(x => x.product_line_id == ProductLineId).FirstOrDefault();
            if (tmpProductLine != null)
            {
                _context.ProductLine.Remove(tmpProductLine);
                if (tmpProductInstance != null)
                {
                    foreach(var i in tmpProductInstance)
                    {
                        _context.ProductInstance.Remove(i);
                    }
                    
                }
            }

            _context.SaveChanges();
            return _context.ProductLine.ToList();
        }
    }
}
