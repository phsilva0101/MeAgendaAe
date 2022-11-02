using MeAgendaAe.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.ViewModel.Agendamentos.Entrada
{
    public class AgendamentsRequestQueryModel : EntidadeBaseViewModel
    {
        public DateTime? DataAgendamento { get; set; }
    }
}
