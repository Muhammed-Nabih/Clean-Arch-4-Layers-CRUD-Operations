using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CRUD.Domain
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
