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
    public class TbEstados : EntidadeBase
    {

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string UF { get; set; }

        [Required]
        public int CodigoIBGE { get; set; }

        public Guid IdPais { get; set; }

        public string DDD { get; set; }

        public virtual ICollection<TbUsuarios> TbUsuarios { get; set; }
        public virtual ICollection<TbEmpresas> TbEmpresas { get; set; }
        public virtual ICollection<TbCliente> TbCliente { get; set; }
        public virtual ICollection<TbCidades> TbCidades { get; set; }

        [ForeignKey("IdPais")]
        public virtual TbPaises TbPaises { get; set; }

    }
}
