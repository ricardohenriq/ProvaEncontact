using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Interfaces.Interfaces.Modelos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prova.EnContact.Modelos.Modelos.Base
{
    public abstract class ObjetoPersistente : IObjetoPersistente
    {
        [Display(Name = ConstantesPalavras.DT_CRIACAO)]
        public DateTime DataCriacao { get; set; }

        [Display(Name = ConstantesPalavras.DT_MODIFICACAO)]
        public DateTime DataAlteracao { get; set; }
    }
}
