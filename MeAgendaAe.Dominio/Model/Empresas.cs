﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Model
{
    public class Empresas
    {
        public long IdEmpresa { get; set; }

        public string NomeEmpresa { get; set; }

        public long IdCidade { get; set; }

        public long IdEstado { get; set; }

        public bool Ativo { get; set; }
    }
}
