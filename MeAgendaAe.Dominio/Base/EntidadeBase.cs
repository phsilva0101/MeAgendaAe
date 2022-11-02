using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Base
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataDesativacao { get; set; }

        protected EntidadeBase()
        {
            Id = Guid.NewGuid();
            DataRegistro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }
    }
}
