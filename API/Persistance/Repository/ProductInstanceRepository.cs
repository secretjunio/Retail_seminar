﻿using API.Entities;
using API.Persistance.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Persistance.Repository
{
    public class ProductInstanceRepository : IProductInstanceRepository
    {
        private readonly Context _context;
        public ProductInstanceRepository(Context context)
        {
            this._context = context;
        }
        public void createProductInstance(ProductInstance ProductInstance)
        {
            _context.ProductInstances.Add(ProductInstance);
            _context.SaveChanges();
        }

        public void editProductInstance(ProductInstance ProductInstance)
        {
            var toUpdate = _context.ProductInstances.Where(x => x.product_instance_id == ProductInstance.product_instance_id).FirstOrDefault();
            ProductInstance.product_instance_id = toUpdate.product_instance_id;
            if (toUpdate != null)
            {
                _context.Entry(toUpdate).CurrentValues.SetValues(ProductInstance);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ProductInstance> ProductInstances()
        {
            return _context.ProductInstances.ToList();
        }

        public ProductInstance FindById(string Id)
        {
            return _context.ProductInstances.Find(Id);
        }

        public void removeProductInstance(string Id)
        {
            _context.ProductInstances.Remove(_context.ProductInstances.Find(Id));
            _context.SaveChanges();
        }

    }
}
