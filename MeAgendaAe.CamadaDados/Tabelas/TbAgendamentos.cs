using MeAgendaAe.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Tabelas
{
    public class TbAgendamentos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdAgendamento { get; set; }

        [Required]
        public long IdCliente { get; set; }

        public string DiaSemana { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataAgendamento { get; set; }
        public TimeSpan Horario { get; set; }

        [Required]
        public long IdEmpresa { get; set; }

        [Required]
        public long IdStatusAgendamento { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual TbEmpresas TbEmpresas { get; set; }

        [ForeignKey("IdStatusAgendamento")]
        public virtual TbStatusAgendamentos TbStatusAgendamentos { get; set; }

        [ForeignKey("IdCliente")]
        public virtual TbCliente TbCliente { get; set; }

    }
}
