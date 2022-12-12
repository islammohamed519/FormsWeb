using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Forms.DataAccess.Repository.IRepository
{
    public interface IFormRepository : IRepository<FrmForms>
    {
        void Update(FrmForms form);
    }
}
