using Prova.EnContact.Compartilhado.Constantes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Prova.EnContact.TesteIntegracao.Fixtures
{
    [CollectionDefinition(ConstantesUtilitarios._CONTROLLER_COLLECTION)]
    public class ControllerCollection : ICollectionFixture<ControllerFixture>
    {
        //Esta classe não tem código e nunca é criada.Sua finalidade é simplesmente
        //para ser o lugar para aplicar [CollectionDefinition] e todas as
        //ICollectionFixture <> interfaces.
    }
}
