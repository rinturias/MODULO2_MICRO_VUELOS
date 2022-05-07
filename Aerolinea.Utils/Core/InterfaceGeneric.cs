using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharedkernel.Core
{
    public interface InterfaceGeneric<T, in TId> where T : AggregateRoot<TId>
    {

        Task<T> FindByIdAsync(TId id);

        Task CreateAsync(T obj);



    }
}
