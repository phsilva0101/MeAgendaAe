using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.ViewModel.Agendamentos.Entrada
{
    public class CancelarAgendamentoRequestViewModel
    {
        public Guid IdAgendamento { get; set; }
        public string MotivoCancelamento { get; set; }
    }
}
