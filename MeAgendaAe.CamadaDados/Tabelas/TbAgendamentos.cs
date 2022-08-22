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
        public long IdAgendamento { get; set; }
        [Required]
        public string NomeCliente { get; set; }
        public string Dia { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataAgendamento { get; set; }
        public TimeSpan Horario { get; set; }

        [Required]
        [ForeignKey("TbEmpresas")]
        public long IdEmpresa { get; set; }

        public virtual TbEmpresas TbEmpresas { get; set; }

    }
}
