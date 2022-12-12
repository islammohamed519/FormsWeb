using Forms.DataAccess.Repository.IRepository;
using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.DataAccess.Repository
{
    public class QuestionRepository : Repository<FrmQuestions>, IQuestionRepository
    {
        private readonly DynamicFormsContext _context;
        public QuestionRepository(DynamicFormsContext context) : base(context)
        {
            _context = context;
        }
        public void Update(FrmQuestions question)
        {
            _context.Update(question);

        }
    }
}

