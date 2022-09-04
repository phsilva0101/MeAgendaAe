using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Tabelas
{
    public class TbPaises
    {
        [Key]
        public long IdPais { get; set; }

        [Required]
        public string NomePais { get; set; }

        public virtual ICollection<TbEstados> TbEstados { get; set; }
    }
}
