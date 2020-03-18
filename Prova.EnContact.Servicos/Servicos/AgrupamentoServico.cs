using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Interfaces.Interfaces.Servicos;
using Prova.EnContact.Mapeadores.Data;
using Prova.EnContact.Mapeadores.Mapeadores;
using Prova.EnContact.Modelos.Modelos;
using Prova.EnContact.Servicos.Servicos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prova.EnContact.Servicos.Servicos
{
    public class AgrupamentoServico : ServicoEntidade<AgrupamentoMapeador, Agrupamento>, IAgrupamentoServico<Agrupamento>
    {
        public AgrupamentoServico(ApplicationDbContext contexto) : base(contexto)
        {
        }

        public void EditarRecado(IRecado recado)
        {
            var agrupamentos = _mapeador.ObtenhaTodos();
            var agrupamento = agrupamentos.First(x => x.RecadosResposta.Any(y => y.IdUnico == recado.IdUnico));

            if (agrupamento.RecadoPertenceAoAgrupamantoEdicao(recado))
            {
                var recadoJahAgrupado = agrupamento.RecadosResposta.First(x => x.IdUnico == recado.IdUnico);

                recadoJahAgrupado.DataAlteracao = DateTime.Today;
                recadoJahAgrupado.Assunto = recado.Assunto;
                recadoJahAgrupado.De = recado.De;
                recadoJahAgrupado.Para = recado.Para;
                recadoJahAgrupado.Mensagem = recado.Mensagem;

                _mapeador.Atualizar(agrupamento);
            }
            else
            {
                //Removo do agrupamento onde estava
                if(agrupamento.RecadosResposta.Count > 1)
                {
                    var recadosResponsta = agrupamento.RecadosResposta.ToList();
                    recadosResponsta.RemoveAll(x => x.IdUnico == recado.IdUnico);
                    agrupamento.RecadosResposta = recadosResponsta;
                    _mapeador.Atualizar(agrupamento);
                }
                //Removo o argupamento
                else if (agrupamento.RecadosResposta.Count == 1)
                {
                    _mapeador.Excluir(agrupamento.IdUnico);
                }

                var possivelProximoAgrupamento = agrupamentos.FirstOrDefault(x => x.RecadoPertenceAoAgrupamantoEdicao(recado));

                if (possivelProximoAgrupamento != null)
                {
                    possivelProximoAgrupamento.AdicioneRecado(recado);
                    _mapeador.Atualizar(possivelProximoAgrupamento);
                }
                else
                {
                    possivelProximoAgrupamento = new Agrupamento();
                    possivelProximoAgrupamento.AdicioneRecado(recado);
                    agrupamentos.Add(possivelProximoAgrupamento);
                    _mapeador.Salvar(possivelProximoAgrupamento);
                }
            }
        }

        public void SalvarRecado(IRecado recado)
        {
            var agrupamentos = _mapeador.ObtenhaTodos();
            var agrupamento = agrupamentos.FirstOrDefault(x => x.RecadoPertenceAoAgrupamanto(recado));

            if (agrupamento != null)
            {
                agrupamento.AdicioneRecado(recado);
                _mapeador.Atualizar(agrupamento);
            }
            else
            {
                agrupamento = new Agrupamento();
                agrupamento.AdicioneRecado(recado);
                agrupamentos.Add(agrupamento);
                _mapeador.Salvar(agrupamento);
            }
        }
    }
}
