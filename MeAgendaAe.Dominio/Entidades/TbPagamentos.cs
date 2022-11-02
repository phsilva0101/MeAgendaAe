using MeAgendaAe.Dominio.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Entidades
{
    public class TbPagamentos : EntidadeBase
    {

        [Required]
        [ForeignKey("TbFormasPagamentos")]
        public Guid IdFormaPagamento { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal ValorTotal { get; set; }

        [Required]
        public int Parcelas { get; set; }

        public virtual TbFormasPagamentos TbFormasPagamentos { get; set; }
    }
}
