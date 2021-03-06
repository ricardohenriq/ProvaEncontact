﻿using Microsoft.EntityFrameworkCore;
using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Modelos.Modelos.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Prova.EnContact.Mapeadores.Data;
using Prova.EnContact.Mapeadores.Excecoes;
using Prova.EnContact.Interfaces.Interfaces.Modelos.Base;

namespace Prova.EnContact.Mapeadores.Mapeadores.Base
{
    public abstract class MapeadorEntidade<T> where T: class, IObjetoPersistenteId
    {
        protected ApplicationDbContext _contexto;

        protected MapeadorEntidade(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public virtual T ObtenhaPorId(Guid id)
        {
            try
            {
                var model = _contexto.Set<T>().FirstOrDefault(x => x.IdUnico == id);

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

        public virtual IList<T> ObtenhaTodos()
        {
            try
            {
                var model = _contexto.Set<T>().ToList();

                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                throw;
            }
        }

        public virtual void Atualizar(T model)
        {
            using (var transacao = _contexto.Database.BeginTransaction())
            {
                try
                {
                    _contexto.Entry(model).State = EntityState.Modified;
                    _contexto.Entry(model).Property(x => x.DataCriacao).IsModified = false;

                    _contexto.Update(model);
                    _contexto.SaveChanges();
                    transacao.Commit();
                }
                catch(Exception ex)
                {
                    transacao.Rollback();

                    Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                    throw;
                }
            }
        }

        public virtual void Salvar(IList<T> models)
        {
            using (var transacao = _contexto.Database.BeginTransaction())
            {
                try
                {
                    _contexto.AddRange(models);
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

        public virtual void Excluir(Guid id)
        {
            using (var transacao = _contexto.Database.BeginTransaction())
            {
                try
                {
                    var model = _contexto.Set<T>().FirstOrDefault(x => x.IdUnico == id);

                    if (model == null)
                    {
                        throw new EntidadeNaoEncontrada(string.Format(ConstantesPalavras.ENT_NAO_ENCONTRADA, id.ToString()));
                    }

                    _contexto.Remove(model);
                    _contexto.SaveChanges();
                    transacao.Commit();
                }
                catch (EntidadeNaoEncontrada ex)
                {
                    transacao.Rollback();

                    Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                    throw;
                }
                catch (Exception ex)
                {
                    transacao.Rollback();

                    Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                    throw;
                }
            }
        }
    }
}