﻿using Biblioteca.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Requests
{
    public class AtividadeRequest
    {
        public int CodAtividade { get; set; }
        public int CodAtividadePrincipal { get; set; }
        public NaoSimEnum TipoAtividade { get; set; }
        public string DescAtividade { get; set; }
    }
}
