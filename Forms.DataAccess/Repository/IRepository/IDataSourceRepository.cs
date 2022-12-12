using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.DataAccess.Repository.IRepository
{
    public interface IDataSourceRepository : IRepository<DataSources>
    {
        void Update(DataSources sources);
    }
}
