using MeAgendaAe.Dominio.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Entidades
{
    public class TbPaises : EntidadeBase
    {

        [Required]
        public string NomePais { get; set; }

        public virtual ICollection<TbEstados> TbEstados { get; set; }
    }
}
