using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CrossCutting.Settings
{
    public class ConfiguracoesDoApp
    {
        public string Schema { get; set; }
        public string TipoConexao { get; set; }
        public bool IsOracle => TipoConexao.ToUpper().Equals("ORACLE");
        public bool IsSQLServer => TipoConexao.ToUpper().Equals("SQLSERVER");
        public bool IsPostgre => TipoConexao.ToUpper().Equals("POSTGRE");
        public bool IsMySQL => TipoConexao.ToUpper().Equals("MYSQL");

        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string SQLSERVER { get; set; }
        public string ORACLE { get; set; }
        public string POSTGRE { get; set; }
        public string MYSQL { get; set; }
    }
}
