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
    public class TbStatusAgendamentos
    {
        public long Id { get; set; }
        [Required]
        public string Descricao { get; set; }

        public virtual ICollection<TbAgendamentos> TbAgendamentos { get; set; }
    }
}
