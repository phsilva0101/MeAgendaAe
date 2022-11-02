using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.ViewModel
{
    public class ItensPaginadosVW<TEntidade> where TEntidade : class 
    {
        public int TamanhoPagina { get; private set; }
        public int NumeroPagina { get; private set; }
        public long Count { get; private set; }
        public IEnumerable<TEntidade> Lista { get; private set; }

        public ItensPaginadosVW(int tamanhoPagina, int numeroPagina, long count, IEnumerable<TEntidade> lista)
        {
            TamanhoPagina = tamanhoPagina;
            NumeroPagina = numeroPagina;
            Count = count;
            Lista = lista;
        }
    }


}
