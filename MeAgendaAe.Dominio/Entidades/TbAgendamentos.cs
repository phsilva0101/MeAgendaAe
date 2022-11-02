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
    public class TbAgendamentos : EntidadeBase
    {

        [Required]
        public Guid IdCliente { get; set; }
        public string NumeroAgendamento { get; set; }

        public string DiaSemana { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataAgendamento { get; set; }
        public TimeSpan Horario { get; set; }

        [Required]
        public Guid IdEmpresa { get; set; }

        [Required]
        public long IdStatusAgendamento { get; set; }

        public string MotivoCancelamento { get; set; }

        [ForeignKey("Id")]
        public virtual TbEmpresas TbEmpresas { get; set; }

        [ForeignKey("Id")]
        public virtual TbStatusAgendamentos TbStatusAgendamentos { get; set; }

        [ForeignKey("Id")]
        public virtual TbCliente TbCliente { get; set; }

    }
}
