using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.DataAccess.Repository.IRepository
{
    public interface IDataSourceCtrlRepository : IRepository<DataSourceCtrl>
    {
        void Update(DataSourceCtrl data);
    }
}
