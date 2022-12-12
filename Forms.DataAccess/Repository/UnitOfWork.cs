
using Forms.DataAccess.Repository.IRepository;
using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DynamicFormsContext _context;
        public UnitOfWork(DynamicFormsContext context)
        {
            _context = context;
            Form = new FormRepository(_context);
            Question = new QuestionRepository(_context);
            Answer = new AnswerRepository(_context);
            Controltype = new ControlTypeRepository(_context);
            DataSources = new DataSourceRepository(_context);
            DataSourceCtrl = new DataSourceCtrlRepository(_context);

        }
        public IFormRepository Form { get; private set; }
        public IQuestionRepository Question { get; private set; }
        public IAnswerRepository Answer { get; private set; }
        public IControlTypeRepository Controltype { get; private set; }
        public IDataSourceRepository DataSources { get; private set; }
        public IDataSourceCtrlRepository DataSourceCtrl { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
