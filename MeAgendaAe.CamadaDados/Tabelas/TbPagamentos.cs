using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Tabelas
{
    public class TbPagamentos
    {
        [Key]
        public long IdPagamentos { get; set; }

        [Required]
        [ForeignKey("TbFormasPagamentos")]
        public int IdFormaPagamento { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal ValorTotal { get; set; }

        [Required]
        public int Parcelas { get; set; }

        public virtual TbFormasPagamentos TbFormasPagamentos { get; set; }
    }
}
