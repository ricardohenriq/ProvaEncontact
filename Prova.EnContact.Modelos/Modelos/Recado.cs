using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Modelos.Modelos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prova.EnContact.Modelos.Modelos
{
    public class Recado : ObjetoPersistenteId, IRecado
    {
        [Required(ErrorMessage = ConstantesPalavras.CAMPO_OBRIGATORIO)]
        [MaxLength(100, ErrorMessage = ConstantesPalavras.TAMANHO_MAXIMO)]
        [Display(Name = ConstantesPalavras.DE)]
        public string De { get; set; }

        [Required(ErrorMessage = ConstantesPalavras.CAMPO_OBRIGATORIO)]
        [MaxLength(100, ErrorMessage = ConstantesPalavras.TAMANHO_MAXIMO)]
        [Display(Name = ConstantesPalavras.PARA)]
        public string Para { get; set; }

        [Required(ErrorMessage = ConstantesPalavras.CAMPO_OBRIGATORIO)]
        [MaxLength(400, ErrorMessage = ConstantesPalavras.TAMANHO_MAXIMO)]
        [Display(Name = ConstantesPalavras.ASSUNTO)]
        public string Assunto { get; set; }

        [Required(ErrorMessage = ConstantesPalavras.CAMPO_OBRIGATORIO)]
        [MaxLength(5000, ErrorMessage = ConstantesPalavras.TAMANHO_MAXIMO)]
        [Display(Name = ConstantesPalavras.MENSAGEM)]
        public string Mensagem { get; set; }

        public Guid IdPai { get; set; }

        public Agrupamento Agrupamento { get; set; }

        public Recado()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
