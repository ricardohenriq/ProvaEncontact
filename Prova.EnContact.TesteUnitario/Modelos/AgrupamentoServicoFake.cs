using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Interfaces.Interfaces.Servicos;
using Prova.EnContact.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.TesteUnitario.Servicos
{
    public class AgrupamentoServicoFake : IAgrupamentoServico<Agrupamento>
    {
        private readonly IList<Agrupamento> _agrupamentos;

        public AgrupamentoServicoFake()
        {
            _agrupamentos = new List<Agrupamento>();
        }

        public Agrupamento ObtenhaPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Agrupamento> ObtenhaTodos()
        {
            throw new NotImplementedException();
        }

        public void SalvarRecado(IRecado recado)
        {
            throw new NotImplementedException();
        }
    }
}
