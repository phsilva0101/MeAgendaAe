using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Tabelas
{
    public class TbConfiguracoes
    {
        [Key]
        public int IdConfiguracao { get; set; }
        public bool Ativo { get; set; }
    }
}
