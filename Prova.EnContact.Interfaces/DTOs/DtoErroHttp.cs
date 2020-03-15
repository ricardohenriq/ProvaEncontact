using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Interfaces.DTOs
{
    public class DtoErroHttp : DtoErro
    {
        public int CodigoHttp { get; set; }

        public string Titulo { get; set; }

        public string Mensagem { get; set; }
    }
}
