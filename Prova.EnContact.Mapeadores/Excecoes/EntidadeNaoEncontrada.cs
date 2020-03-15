using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Prova.EnContact.Mapeadores.Excecoes
{
    public class EntidadeNaoEncontrada : Exception
    {
        public EntidadeNaoEncontrada() : base() { }

        public EntidadeNaoEncontrada(string message) : base(message) { }

        public EntidadeNaoEncontrada(string message, Exception innerException)
             : base(message, innerException) { }

        protected EntidadeNaoEncontrada(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
