using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Tabelas
{
    public class TbEmpresas
    {
        [Key]
        public long IdEmpresa { get; set; }

        [Required]
        public string NomeEmpresa { get; set; }

        [Required]
        [ForeignKey("TbCidades")]
        public long IdCidade { get; set; }

        [Required]
        [ForeignKey("TbEstados")]
        public long IdEstado { get; set; }

        public bool Ativo { get; set; }


        public virtual TbEstados TbEstados { get; set; }
        public virtual TbCidades TbCidades { get; set; }
        public virtual ICollection<TbAgendamentos> TbAgendamentos { get; set; }
    }
}
