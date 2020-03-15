using Microsoft.EntityFrameworkCore;
using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Mapeadores.Data;
using Prova.EnContact.Mapeadores.Excecoes;
using Prova.EnContact.Mapeadores.Mapeadores.Base;
using Prova.EnContact.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Prova.EnContact.Mapeadores.Mapeadores
{
    public class AgrupamentoMapeador : MapeadorEntidade<Agrupamento>
    {
        public AgrupamentoMapeador(ApplicationDbContext contexto) : base(contexto)
        {
        }

        public override Agrupamento ObtenhaPorId(Guid id)
        {
            try
            {
                var model = _contexto.Agrupamentos.Include(x => x.RecadosResposta).FirstOrDefault(x => x.IdUnico == id);

                if (model == null)
                {
                    throw new EntidadeNaoEncontrada(string.Format(ConstantesPalavras.ENT_NAO_ENCONTRADA, id.ToString()));
                }

                return model;
            }
            catch (EntidadeNaoEncontrada ex)
            {
                Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                throw;
            }
        }

        public override IList<Agrupamento> ObtenhaTodos()
        {
            try
            {
                var agrupamentos = _contexto
                    .Agrupamentos
                    .Include(x => x.RecadosResposta)
                    .OrderBy(x => x.DataCriacao)
                    .ToList();

                foreach(var agrupamento in agrupamentos)
                {
                    agrupamento.RecadosResposta = agrupamento.RecadosResposta.OrderBy(x => x.DataCriacao).ToList();
                }

                return agrupamentos;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                throw;
            }
        }

        public override void Atualizar(Agrupamento model)
        {
            using (var transacao = _contexto.Database.BeginTransaction())
            {
                try
                {
                    _contexto.Update(model);
                    _contexto.SaveChanges();
                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                    throw;
                }
            }
        }

        public void Salvar(Agrupamento model)
        {
            using (var transacao = _contexto.Database.BeginTransaction())
            {
                try
                {
                    _contexto.Add(model);
                    _contexto.SaveChanges();
                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                    throw;
                }
            }
        }
    }
}
