using Prova.EnContact.Mapeadores.Data;
using Prova.EnContact.Mapeadores.Mapeadores.Base;
using Prova.EnContact.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Mapeadores.Mapeadores
{
    public class RecadoMapeador : MapeadorEntidade<Recado>
    {
        public RecadoMapeador(ApplicationDbContext contexto) : base(contexto)
        {
        }
    }
}
