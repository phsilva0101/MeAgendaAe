using MeAgendaAe.Dominio.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Entidades
{
    public class TbFormasPagamentos : EntidadeBase
    {
       
        public string FormaPagamento { get; set; }

        public virtual ICollection<TbPagamentos> TbPagamentos { get; set; }

    }
}
