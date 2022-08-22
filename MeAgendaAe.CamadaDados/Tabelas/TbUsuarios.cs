using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Tabelas
{
    public class TbUsuarios
    {
        [Key]
        public long IdUsuario { get; set; }

        [Required]
        public string PrimeiroNome { get; set; }

        [Required]
        public string UltimoNome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string Foto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInclusao { get; set; }
        public bool Ativo { get; set; }

        [ForeignKey("TbCidades")]
        public long IdCidade { get; set; }
        public virtual TbCidades TbCidades { get; set; }


        [ForeignKey("TbEstados")]
        public long IdEstado { get; set; }
        public virtual TbEstados TbEstados { get; set; }
    }
}
