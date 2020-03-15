using PagedList.Core;
using Prova.EnContact.Interfaces.Interfaces.Modelos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Interfaces.Interfaces.Servicos
{
    public interface IServicoEntidade<T>
        where T : IObjetoPersistenteId
    {
        IList<T> ObtenhaTodos();

        T ObtenhaPorId(Guid id);
    }
}
