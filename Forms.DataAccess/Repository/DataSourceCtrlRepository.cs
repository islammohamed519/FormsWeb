
using Forms.DataAccess.Repository.IRepository;
using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.DataAccess.Repository
{
    public class DataSourceCtrlRepository : Repository<DataSourceCtrl>, IDataSourceCtrlRepository
    {
        private readonly DynamicFormsContext _context;
        public DataSourceCtrlRepository(DynamicFormsContext context) : base(context)
        {
            _context = context;
        }
        public void Update(DataSourceCtrl data)
        {
            _context.Update(data);

        }
    }
}

