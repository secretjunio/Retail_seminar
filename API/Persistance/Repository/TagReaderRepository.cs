using API.Entities;
using API.Persistance.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Persistance.Repository
{
    public class TagReaderRepository : IRepository.ITagReaderRepository
    {
        private readonly Context _context;
        public TagReaderRepository(Context context)
        {
            this._context = context;
        }
        public void createTagReader(TagReader TagReader)
        {
            _context.TagReaders.Add(TagReader);
            _context.SaveChanges();
        }

        public void editTagReader(TagReader TagReader)
        {
            var toUpdate = _context.TagReaders.Where(x => x.TagUii == TagReader.TagUii).FirstOrDefault();
            TagReader.TagUii = toUpdate.TagUii;
            if (toUpdate != null)
            {
                _context.Entry(toUpdate).CurrentValues.SetValues(TagReader);
                _context.SaveChanges();
            }
        }

        public IEnumerable<TagReader> TagReaders()
        {
            return _context.TagReaders.ToList();
        }

        public TagReader FindById(string Id)
        {
            return _context.TagReaders.Find(Id);
        }

        public void removeTagReader(string Id)
        {
            _context.TagReaders.Remove(_context.TagReaders.Find(Id));
            _context.SaveChanges();
        }
    }
}
