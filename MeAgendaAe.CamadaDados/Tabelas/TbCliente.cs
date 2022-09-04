﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Tabelas
{
    public class TbCliente
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdCliente { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        [StringLength(maximumLength:16)]
        public string CPF { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public int Idade { get; set; }

        [ForeignKey("TbCidades")]
        [Required]
        public long IdCidade { get; set; } //FK

        [Required]
        public bool IsAtivo { get; set; }


        [ForeignKey("TbEstados")]
        [Required]
        public long IdEstado { get; set; }

        [ForeignKey("TbUsuarios")]
        [Required]
        public long IdUsuario { get; set; }

        public int? QtdVisitas { get; set; }


        public virtual TbEstados TbEstados { get; set; }
        public virtual TbCidades TbCidades { get; set; }
        public virtual TbUsuarios TbUsuarios { get; set; }
        public virtual ICollection< TbAgendamentos> TbAgendamentos { get; set; }

    }
}
