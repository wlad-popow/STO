using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IQueryable<T> Items { get; }

        T AddItem(T item);

        T UpdateItem(T item);

        T Remove(T item);

        void Save();
    }
}
