
using Forms.DataAccess.Repository.IRepository;
using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.DataAccess.Repository
{
    public class ControlTypeRepository : Repository<ControlType>, IControlTypeRepository
    {
        private readonly DynamicFormsContext _context;
        public ControlTypeRepository(DynamicFormsContext context) : base(context)
        {
            _context = context;
        }
        public void Update(ControlType type)
        {
            _context.Update(type);

        }
    }
}

