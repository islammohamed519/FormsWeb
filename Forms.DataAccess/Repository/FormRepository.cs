
using Forms.DataAccess.Repository.IRepository;
using Forms.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.DataAccess.Repository
{
    public class FormRepository : Repository<FrmForms>, IFormRepository
    {
        private readonly DynamicFormsContext _context;
        public FormRepository(DynamicFormsContext context) : base(context)
        {
            _context = context;
        }
        public void Update(FrmForms form)
        {
            _context.Update(form);

        }
    }
}
