using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Base
{
    public interface IBaseRepositorio<TEntidade> where TEntidade : class
    {
        Task CriarAsync(TEntidade entidade);
        void DeleteAsync(TEntidade entidade);
    }
}
