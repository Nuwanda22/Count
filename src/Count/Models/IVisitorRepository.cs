using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Count.Models
{
    public interface IVisitorRepository
    {
        void Add(VisitorItem item);
        IEnumerable<VisitorItem> GetAll();
        VisitorItem Find(long key);
        void Remove(long key);
        void Update(VisitorItem item);
    }
}
