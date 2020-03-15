using PagedList.Core;
using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Interfaces.Interfaces.Modelos.Base;

namespace Prova.EnContact.Interfaces.Interfaces.Servicos
{
    public interface IRecadoServico<T> : IServicoEntidade<T>
        where T : IObjetoPersistenteId
    {
    }
}
