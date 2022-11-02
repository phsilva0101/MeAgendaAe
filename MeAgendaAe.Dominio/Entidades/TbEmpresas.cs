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
    public class TbEmpresas : EntidadeBase
    {

        [Required]
        public string NomeEmpresa { get; set; }

        [Required]
        [ForeignKey("TbCidades")]
        public Guid IdCidade { get; set; }

        [Required]
        [ForeignKey("TbEstados")]
        public Guid IdEstado { get; set; }

        public bool Ativo { get; set; }


        public virtual TbEstados TbEstados { get; set; }
        public virtual TbCidades TbCidades { get; set; }
        public virtual ICollection<TbAgendamentos> TbAgendamentos { get; set; }
    }
}
