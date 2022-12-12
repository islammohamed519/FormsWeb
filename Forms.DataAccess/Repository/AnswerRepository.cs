
using Forms.DataAccess.Repository.IRepository;
using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.DataAccess.Repository
{
    public class AnswerRepository : Repository<FrmAnswers>, IAnswerRepository
    {
        private readonly DynamicFormsContext _context;
        public AnswerRepository(DynamicFormsContext context) : base(context)
        {
            _context = context;
        }
        public void Update(FrmAnswers answer)
        {
            _context.Update(answer);

        }
    }
}

