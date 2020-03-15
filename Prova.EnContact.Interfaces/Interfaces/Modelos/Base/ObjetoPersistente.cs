using System;

namespace Prova.EnContact.Interfaces.Interfaces.Modelos.Base
{
    public interface IObjetoPersistente
    {
        DateTime DataCriacao { get; set; }

        DateTime DataAlteracao { get; set; }
    }
}
