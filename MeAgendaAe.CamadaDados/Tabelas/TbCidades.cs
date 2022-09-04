using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Tabelas
{
    public class TbCidades
    {
        [Key]
        public long IdCidades { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public long IdEstado { get; set; }

        public virtual ICollection<TbUsuarios> TbUsuarios { get; set; }
        public virtual ICollection<TbEmpresas> TbEmpresas { get; set; }
        public virtual ICollection<TbCliente> TbCliente { get; set; }

        [ForeignKey("IdEstado")]
        public virtual TbEstados TbEstados { get; set; }


    }
}
