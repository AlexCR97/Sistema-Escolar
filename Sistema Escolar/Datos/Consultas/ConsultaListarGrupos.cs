﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas
{
    class ConsultaListarGrupos : Consulta
    {
        public ConsultaListarGrupos(params object[] args) : base(args)
        {
        }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>();
        }

        protected override string DefinirQuery()
        {
            return "select * from aulas";
        }
    }
}
