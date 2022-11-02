using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.ViewModel.Clientes.Saida
{
    public class ClientesModel
    {
        public long IdCliente { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string CPF { get; set; }
        public string Email { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public int Idade { get; set; }

        public long IdCidade { get; set; } //FK

        public bool IsAtivo { get; set; }

        public long IdEstado { get; set; }

        public long IdUsuario { get; set; }

        public int? QtdVisitas { get; set; }
    }
}
