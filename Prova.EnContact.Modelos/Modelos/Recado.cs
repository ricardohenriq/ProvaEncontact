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

        public IRecado CloneDescompartilhado()
        {
            return Clone() as Recado;
        }

        public object Clone()
        {
            var clone = new Recado();
            clone.Agrupamento = Agrupamento;
            clone.Assunto = string.Copy(Assunto);
            clone.DataAlteracao = new DateTime(DataAlteracao.Year, DataAlteracao.Month, DataAlteracao.Day);
            clone.DataCriacao = new DateTime(DataCriacao.Year, DataCriacao.Month, DataCriacao.Day);
            clone.De = string.Copy(De);
            clone.IdPai = IdPai;
            clone.IdUnico = IdUnico;
            clone.Mensagem = string.Copy(Mensagem);
            clone.Para = string.Copy(Mensagem);

            return clone;
        }
    }
}
