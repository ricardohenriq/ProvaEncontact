using PagedList.Core;
using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Interfaces.Interfaces.Modelos.Base;
using Prova.EnContact.Interfaces.Interfaces.Servicos;
using Prova.EnContact.Mapeadores.Data;
using Prova.EnContact.Mapeadores.Mapeadores.Base;
using Prova.EnContact.Modelos.Modelos.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Prova.EnContact.Servicos.Servicos.Base
{
    public abstract class ServicoEntidade<T, U> : IServicoEntidade<U>
        where U : class, IObjetoPersistenteId
        where T : MapeadorEntidade<U>
    {
        public T _mapeador { get; set; }

        protected ServicoEntidade(ApplicationDbContext contexto)
        {
            _mapeador = (T)Activator.CreateInstance(typeof(T), contexto);
        }

        public virtual void Atualizar(U model)
        {
            try
            {
                _mapeador.Atualizar(model);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                throw;
            }
        }

        public virtual U ObtenhaPorId(Guid id)
        {
            try
            {
                return _mapeador.ObtenhaPorId(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                throw;
            }
        }

        public virtual IList<U> ObtenhaTodos()
        {
            try
            {
                return _mapeador.ObtenhaTodos();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                throw;
            }
        }

        public virtual IPagedList<U> ObtenhaTodos(int pagina)
        {
            try
            {
                //return _mapeador.ObtenhaTodos(id);
                throw new Exception();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                throw;
            }
        }

        public virtual void Salvar(IList<U> models)
        {
            try
            {
                _mapeador.Salvar(models);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format(ConstantesPalavras.ERRO, ex.Message));
                throw;
            }
        }
    }
}
