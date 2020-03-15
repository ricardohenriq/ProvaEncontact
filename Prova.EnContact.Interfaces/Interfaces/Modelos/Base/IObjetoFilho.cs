using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Interfaces.Interfaces.Modelos.Base
{
    public interface IObjetoFilho<T>
    {
        T IdPai { get; set; }
    }
}
