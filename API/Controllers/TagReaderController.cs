using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagReaderController : ControllerBase
    {
        private readonly Context _context;
        public TagReaderController(Context context)
        {
            this._context = context;
        }
        [Route("GetTagReader")]
        [HttpGet]
        public TagReader GetTagReader(string Id)
        {
            return _context.tagReaders.Where(x => x.TagUii == Id).FirstOrDefault();
        }

        [Route("GetListTagReader")]
        [HttpGet]
        public IEnumerable<TagReader> GetListTagReader()
        {
            return _context.tagReaders.ToList();
        }

        [Route("AddTagReader")]
        [HttpPost]
        public IEnumerable<TagReader> AddTagReader(TagReader t)
        {
            if(_context.tagReaders.Where(x => x.TagUii == t.TagUii).FirstOrDefault() == null)
            {
                _context.tagReaders.Add(t);
                _context.SaveChanges();
            }
            return _context.tagReaders.ToList();
        }
        [Route("DeleteTagReader")]
        [HttpDelete]
        public IEnumerable<TagReader> DeleteTagReader(string TagUii)
        {
            TagReader t = _context.tagReaders.Where(x => x.TagUii == TagUii).FirstOrDefault();
            if (t != null)
            {
                _context.tagReaders.Remove(t);
                _context.SaveChanges();
            }
            return _context.tagReaders.ToList();
        }
        [Route("EditDeleteTagReader")]
        [HttpPut]
        public IEnumerable<TagReader> EditTagReader(TagReader t)
        {
            TagReader ToUpdate = _context.tagReaders.Where(x => x.TagUii == t.TagUii).FirstOrDefault();
            TagReader temp = new TagReader();
            if (temp != null)
            {
                temp.TagUii = ToUpdate.TagUii;
                temp.TagRssi = t.TagRssi;
                temp.Number = t.Number;
                if (ToUpdate != null)
                {
                    _context.Entry(ToUpdate).CurrentValues.SetValues(temp);
                }
                _context.SaveChanges();
            }
            return _context.tagReaders.ToList();
        }
    }
}
