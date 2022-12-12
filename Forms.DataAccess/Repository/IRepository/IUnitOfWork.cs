using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IFormRepository Form { get; }
        IQuestionRepository Question { get; }
        IAnswerRepository Answer { get; }
        IControlTypeRepository Controltype { get; }
        IDataSourceRepository DataSources { get; }
        IDataSourceCtrlRepository DataSourceCtrl { get; }
        void Save();
    }
}
