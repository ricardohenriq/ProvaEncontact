using PagedList.Core;
using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Interfaces.Interfaces.Servicos;
using Prova.EnContact.Mapeadores.Data;
using Prova.EnContact.Mapeadores.Mapeadores;
using Prova.EnContact.Modelos.Modelos;
using Prova.EnContact.Servicos.Servicos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Servicos.Servicos
{
    public class RecadoServico : ServicoEntidade<RecadoMapeador, Recado>, IRecadoServico<Recado>
    {
        public RecadoServico(ApplicationDbContext contexto):base(contexto)
        {
        }
    }
}
