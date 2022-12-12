
using Forms.DataAccess.Repository.IRepository;
using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.DataAccess.Repository
{
    public class DataSourceRepository : Repository<DataSources>, IDataSourceRepository
    {
        private readonly DynamicFormsContext _context;
        public DataSourceRepository(DynamicFormsContext context) : base(context)
        {
            _context = context;
        }
        public void Update(DataSources source)
        {
            _context.Update(source);

        }
    }
}

