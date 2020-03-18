using Prova.EnContact.Interfaces.Interfaces.Modelos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Interfaces.Interfaces.Modelos
{
    public interface IRecado : IObjetoPersistenteId, IObjetoFilho<Guid>, ICloneDescompartilhado<IRecado>
    {
        string De { get; set; }

        string Para { get; set; }

        string Assunto { get; set; }

        string Mensagem { get; set; }
    }
}
