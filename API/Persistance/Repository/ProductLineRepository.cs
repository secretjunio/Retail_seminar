using API.Entities;
using API.Persistance.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Persistance.Repository
{
    public class ProductLineRepository : IRepository.IProductLineRepository
    {
        private readonly Context _context;
        public ProductLineRepository(Context context)
        {
            this._context = context;
        }
        public void createProductLine(ProductLine ProductLine)
        {
            _context.ProductLines.Add(ProductLine);
            _context.SaveChanges();
        }

        public void editProductLine(ProductLine ProductLine)
        {
            var toUpdate = _context.ProductLines.Where(x => x.product_line_id == ProductLine.product_line_id).FirstOrDefault();
            ProductLine.product_line_id = toUpdate.product_line_id;
            if (toUpdate != null)
            {
                _context.Entry(toUpdate).CurrentValues.SetValues(ProductLine);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ProductLine> ProductLines()
        {
            return _context.ProductLines.ToList();
        }

        public ProductLine FindById(string Id)
        {
            return _context.ProductLines.Find(Id);
        }

        public void removeProductLine(string Id)
        {
            _context.ProductLines.Remove(_context.ProductLines.Find(Id));
            _context.SaveChanges();
        }
    }
}
