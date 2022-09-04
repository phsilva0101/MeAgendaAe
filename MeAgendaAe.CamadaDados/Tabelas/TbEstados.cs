using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Tabelas
{
    public class TbEstados
    {
        [Key]
        public long IdEstado { get; set; }

        [Required]
        public string Descricao { get; set; }

        public virtual ICollection< TbUsuarios> TbUsuarios { get; set; }
        public virtual ICollection< TbEmpresas> TbEmpresas { get; set; }
        public virtual ICollection< TbCliente> TbCliente { get; set; }
    }
}
