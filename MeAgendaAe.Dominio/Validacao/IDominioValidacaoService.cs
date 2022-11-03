using MeAgendaAe.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Validacao
{
    public interface IDominioValidacaoService
    {
        TipoRetorno Retorno { get;  }
        string[] Mensagens { get;  }
        bool TemNotificacao { get; }
        void AddMensagem(string msg);
        void AddMensagens(IList<string> msgs);
        void AddMensagens(ICollection<string> msgs);
        void AddMensagens(ValidationResult validationResult);
        void AsNotFound();
    }

}
