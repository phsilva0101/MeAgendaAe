using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Tabelas
{
    public class TbStatusAgendamentos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long IdStatusAgendamento { get; set; }

        [Required]
        public string Descricao { get; set; }

        public virtual ICollection<TbAgendamentos> TbAgendamentos { get; set; }
    }
}
