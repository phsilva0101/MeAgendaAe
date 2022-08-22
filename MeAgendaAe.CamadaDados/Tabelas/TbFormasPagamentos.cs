using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Tabelas
{
    public class TbFormasPagamentos
    {
        [Key]
        public int IdFormasPagamentos { get; set; }
        public string DescricaoFormaPagamento { get; set; }

        public virtual ICollection<TbPagamentos> TbPagamentos { get; set; }

    }
}
