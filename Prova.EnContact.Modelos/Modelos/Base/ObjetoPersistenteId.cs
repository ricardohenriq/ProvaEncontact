using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Interfaces.Interfaces.Modelos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prova.EnContact.Modelos.Modelos.Base
{
    public abstract class ObjetoPersistenteId : ObjetoPersistente, IObjetoPersistenteId
    {
        protected ObjetoPersistenteId(Guid id)
        {
            IdUnico = id;
        }

        protected ObjetoPersistenteId() : this(Guid.NewGuid())
        {
        }

        [Key]
        [Display(Name = ConstantesPalavras.ID)]
        public Guid IdUnico { get; set; }
    }
}
