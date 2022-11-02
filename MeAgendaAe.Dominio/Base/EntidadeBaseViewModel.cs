using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Base
{
    public class EntidadeBaseViewModel
    {
        public int TamanhoPagina { get; set; } = 100;
        public int NumeroPagina { get; set; } = 1;
        public string OrdenarPor { get; set; } = "";
        public bool OrdernacaoDesc { get; set; } = true;
        public string TermoBusca { get; set; } = "";
        public string OrderColumn { get; set; } = "";
        public bool OrderDirection { get; set; } = true;
        public bool SomenteAtivos { get; set; }
    }
}
