using MeAgendaAe.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Validacao
{
    public class DominioValidacaoService : IDominioValidacaoService
    {
        public TipoRetorno Retorno { get; private set; }
        private readonly List<string> _mensagens;

        public string[] Mensagens => _mensagens.ToArray();
        public bool TemNotificacao => Retorno != TipoRetorno.OK;

        public DominioValidacaoService()
        {
            Retorno = TipoRetorno.OK;
            _mensagens = new List<string>();
        }

        public void AddMensagem(string msg)
        {
            Retorno = TipoRetorno.BadRequest;
           _mensagens?.Add(msg);
        }

        public void AddMensagens(IList<string> msgs)
        {
            Retorno = TipoRetorno.BadRequest;
            _mensagens?.AddRange(msgs);
        }

        public void AddMensagens(ICollection<string> msgs)
        {
            Retorno = TipoRetorno.BadRequest;
            _mensagens?.AddRange(msgs);
        }

        public void AddMensagens(ValidationResult validationResult)
        {
            Retorno = TipoRetorno.BadRequest;
            AddMensagem(validationResult.ErrorMessage);
        }

        public void AsNotFound()
        {
            Retorno = TipoRetorno.NotFound;
        }
    }
}
