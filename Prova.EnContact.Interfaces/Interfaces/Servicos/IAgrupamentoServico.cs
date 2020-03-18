using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Interfaces.Interfaces.Modelos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Interfaces.Interfaces.Servicos
{
    public interface IAgrupamentoServico<T> : IServicoEntidade<T>
        where T : IObjetoPersistenteId
    {
        void SalvarRecado(IRecado recado);

        void EditarRecado(IRecado recado);
    }
}
