using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Interfaces.DTOs
{
    public class DtoErro
    {
        public string RequisicaoId { get; set; }

        public bool ExibirRequisicaoId => !string.IsNullOrEmpty(RequisicaoId);
    }
}
