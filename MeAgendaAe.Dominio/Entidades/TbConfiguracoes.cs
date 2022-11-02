using MeAgendaAe.Dominio.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Entidades
{
    public class TbConfiguracoes : EntidadeBase
    {
       
        public bool Ativo { get; set; }
    }
}
