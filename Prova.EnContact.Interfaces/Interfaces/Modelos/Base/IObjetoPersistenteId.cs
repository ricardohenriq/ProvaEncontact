using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Interfaces.Interfaces.Modelos.Base
{
    public interface IObjetoPersistenteId : IObjetoPersistente
    {
        Guid IdUnico { get; set; }
    }
}
