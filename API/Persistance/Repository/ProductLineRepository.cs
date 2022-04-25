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
                _context.ProductLines.Update(ProductLine);
                _context.SaveChanges();
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
