using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Count.Models
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly VisitorContext _context;

        public VisitorRepository(VisitorContext context)
        {
            _context = context;
            
            //if (_context.Visitors.Count() == 0)
            //    Add(new VisitorItem { Referer = "Item1" });
        }

        public IEnumerable<VisitorItem> GetAll()
        {
            return _context.Visitors.ToList();
        }

        public void Add(VisitorItem item)
        {
            _context.Visitors.Add(item);
            _context.SaveChanges();
        }

        public VisitorItem Find(long key)
        {
            return _context.Visitors.FirstOrDefault(t => t.Key == key);
        }

        public void Remove(long key)
        {
            var entity = _context.Visitors.First(t => t.Key == key);
            _context.Visitors.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(VisitorItem item)
        {
            _context.Visitors.Update(item);
            _context.SaveChanges();
        }
    }
}
