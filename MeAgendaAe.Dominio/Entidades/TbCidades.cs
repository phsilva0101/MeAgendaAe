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
    public class TbCidades : EntidadeBase
    {

        [Required]
        public string Descricao { get; set; }

        [Required]
        public Guid IdEstado { get; set; }

        public virtual ICollection<TbUsuarios> TbUsuarios { get; set; }
        public virtual ICollection<TbEmpresas> TbEmpresas { get; set; }
        public virtual ICollection<TbCliente> TbCliente { get; set; }

        [ForeignKey("Id")]
        public virtual TbEstados TbEstados { get; set; }


    }
}
