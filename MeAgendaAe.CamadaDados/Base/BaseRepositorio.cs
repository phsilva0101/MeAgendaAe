using MeAgendaAe.Dominio.Base;
using MeAgendaAe.Dominio.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Base
{
    public class BaseRepositorio<TContext, TEntidade> : IBaseRepositorio<TEntidade> where TEntidade : class where TContext : DbContext
    {
        protected readonly TContext _context;

        public BaseRepositorio(TContext context)
        {
            _context = context;
        }

        public async Task CriarAsync(TEntidade entidade)
        {
            await _context.Set<TEntidade>().AddAsync(entidade);
        }

        public void DeleteAsync(TEntidade entidade)
        {
             _context.Set<TEntidade>().Remove(entidade);

        }
    }
}
