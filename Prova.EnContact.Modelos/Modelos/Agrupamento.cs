using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Modelos.Modelos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Prova.EnContact.Modelos.Modelos
{
    public class Agrupamento : ObjetoPersistenteId, IAgrupamento
    {
        #region CAMPOS E PROPRIEDADES

        private readonly int _carenciaEmMeses = 6;
        private readonly List<string> _partesIgnoradasDoAssunto = new List<string> { "referente:", "respondendo:", "complementando:" };

        public IList<Recado> RecadosResposta { get; set; }

        [NotMapped]
        public IRecado RecadoInicial { get { return RecadosResposta.FirstOrDefault(); } }

        [NotMapped]
        public IRecado RecadoFinal { get { return RecadosResposta?.OrderBy(x => DataCriacao)?.LastOrDefault(); } }

        #endregion

        public Agrupamento()
        {
            RecadosResposta = new List<Recado>();
            DataCriacao = DateTime.Now;
        }

        public bool RecadoPertenceAoAgrupamanto(IRecado recado)
        {
            var resultado = RecadoInicial != null && DeParaIgualAoDoRecadoInicial(recado)
                && RecadoInicialDentroDoPrazoDeCarenciaDoAtendimentoEmMeses(recado)
                && RefereseAoMesmoAssuntoDoRecadoInicial(recado);

            return resultado;
        }

        public bool RecadoPertenceAoAgrupamantoEdicao(IRecado recado)
        {
            var resultado = RecadoInicial != null && DeParaIgualAoDoRecadoInicial(recado)
                && RecadoInicialDentroDoPrazoDeCarenciaDoAtendimentoEmMesesEdicao(recado)
                && RefereseAoMesmoAssuntoDoRecadoInicialEdicao(recado);

            return resultado;
        }
        public IList<IRecado> ObtenhaListaDeRecados()
        {
            return RecadosResposta.OrderBy(x => x.DataCriacao).Cast<IRecado>().ToList();
        }

        public void AdicioneRecado(IRecado recado)
        {
            RecadosResposta.Add((Recado)recado);
        }

        #region REGRAS PARA INCLUSAO NO AGRUPAMENTO

        private bool DeParaIgualAoDoRecadoInicial(IRecado recado)
        {
            var resultado = recado.De.ToLowerInvariant().Equals(RecadoInicial.De.ToLowerInvariant()) 
                || recado.Para.ToLowerInvariant().Equals(RecadoInicial.De.ToLowerInvariant());

            return resultado;
        }

        private bool RecadoInicialDentroDoPrazoDeCarenciaDoAtendimentoEmMesesEdicao(IRecado recado)
        {
            var resultado = (RecadoInicial.DataCriacao.Date.AddMonths(-_carenciaEmMeses) < recado.DataCriacao.Date) 
                && (RecadoFinal.DataCriacao.Date.AddMonths(_carenciaEmMeses) > recado.DataCriacao.Date);

            return resultado;
        }

        private bool RecadoInicialDentroDoPrazoDeCarenciaDoAtendimentoEmMeses(IRecado recado)
        {
            var resultado = RecadoFinal.DataCriacao.Date.AddMonths(_carenciaEmMeses)
                > recado.DataCriacao.Date;

            return resultado;
        }

        private bool RefereseAoMesmoAssuntoDoRecadoInicial(IRecado recado)
        {
            var assunto = string.Copy(recado.Assunto).Trim().ToLowerInvariant();
            var resultado = _partesIgnoradasDoAssunto.Any(x => 
                (assunto.StartsWith(x.ToLowerInvariant()) && assunto.Replace(x.ToLowerInvariant(), "")
                    .Trim()
                    .Equals(RecadoInicial.Assunto.Trim().ToLowerInvariant()))
                || (assunto.Equals(RecadoInicial.Assunto.Trim().ToLowerInvariant())));

            return resultado;
        }

        private bool RefereseAoMesmoAssuntoDoRecadoInicialEdicao(IRecado recado)
        {
            var assunto = string.Copy(recado.Assunto).Trim().ToLowerInvariant();

            foreach (var ignorado in _partesIgnoradasDoAssunto)
            {
                if (assunto.StartsWith(ignorado))
                {
                    assunto = assunto.Replace(ignorado, "");
                    break;
                }
            }

            var resultado = _partesIgnoradasDoAssunto.Any(x => RecadoInicial.Assunto.ToLowerInvariant().Replace(x, "").Trim()
                .Equals(assunto.Trim()));
            return resultado;
        }

        #endregion
    }
}
