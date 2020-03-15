using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Interfaces.Interfaces.Modelos
{
    public interface IAgrupamento
    {
        bool RecadoPertenceAoAgrupamanto(IRecado recado);

        IList<IRecado> ObtenhaListaDeRecados();

        void AdicioneRecado(IRecado recado);
    }
}
