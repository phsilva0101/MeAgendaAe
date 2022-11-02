using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeAgendaAe.Dominio.Enums;

namespace MeAgendaAe.Dominio.Model
{
    public class Agendamentos
    {
        public Guid Id { get; set; }
        public long IdCliente { get; set; }

        public string DiaSemana { get; set; }

        public DateTime DataAgendamento { get; set; }
        public TimeSpan Horario { get; set; }

        public long IdEmpresa { get; set; }
        public EnumStatusAgendamento StatusAgendamento { get; set; }


    }
}
