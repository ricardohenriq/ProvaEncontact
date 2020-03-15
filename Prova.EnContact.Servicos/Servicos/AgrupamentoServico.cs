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
