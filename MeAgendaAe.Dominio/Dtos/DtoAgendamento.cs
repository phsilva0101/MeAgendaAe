using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Dtos
{
    public class DtoAgendamento
    {
        public long IdAgendamento { get; set; }
        public long IdCliente { get; set; }

        public string DiaSemana { get; set; }

        public DateTime DataAgendamento { get; set; }
        public TimeSpan Horario { get; set; }

        public long IdEmpresa { get; set; }
        public EnumStatusAgendamento StatusAgendamento { get; set; }
    }
}
