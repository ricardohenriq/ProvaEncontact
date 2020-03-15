using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Prova.EnContact.Servicos.Utilitarios
{
    public static class GeradorDeEntidadesMock
    {
        public static IList<IRecado> ObtenhaRecadosMock()
        {
            var recados = new List<IRecado>
            {
                new Recado
                {
                    DataCriacao = DateTime.ParseExact("01/01/2019", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "Primeiro recado",
                    De = "Fulano",
                    Para = "Ciclano",
                    Mensagem = "Mensagem"
                },
                new Recado
                {
                    DataCriacao = DateTime.ParseExact("05/01/2019", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "respondendo: Primeiro recado",
                    De = "Ciclano",
                    Para = "Fulano",
                    Mensagem = "Mensagem"
                },
                new Recado
                {
                    DataCriacao = DateTime.ParseExact("02/02/2019", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "Segundo recado",
                    De = "Ciclano",
                    Para = "Fulano",
                    Mensagem = "Mensagem"
                },
                new Recado
                {
                    DataCriacao = DateTime.ParseExact("05/03/2019", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "complementando: Primeiro recado",
                    De = "Ciclano",
                    Para = "Fulano",
                    Mensagem = "Mensagem"
                },
                new Recado
                {
                    DataCriacao = DateTime.ParseExact("01/09/2019", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "referente: Primeiro recado",
                    De = "Fulano",
                    Para = "Ciclano",
                    Mensagem = "Mensagem"
                },
                new Recado
                {
                    DataCriacao = DateTime.ParseExact("30/12/2019", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "respondendo: Segundo recado",
                    De = "Fulano",
                    Para = "Ciclano",
                    Mensagem = "Mensagem"
                },
                new Recado
                {
                    DataCriacao = DateTime.ParseExact("01/01/2020", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "Primeiro recado",
                    De = "Fulano",
                    Para = "Deltano",
                    Mensagem = "Mensagem"
                },
                new Recado
                {
                    DataCriacao = DateTime.ParseExact("01/01/2020", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "Primeiro recado",
                    De = "Deltano",
                    Para = "Fulano",
                    Mensagem = "Mensagem"
                },
                new Recado
                {
                    DataCriacao = DateTime.ParseExact("01/07/2020", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "Primeiro recado",
                    De = "Fulano",
                    Para = "Deltano",
                    Mensagem = "Mensagem"
                },
            };

            return recados;
        }

        public static IRecado ObtenhaRecado()
        {
            var recado = new Recado
            {
                DataCriacao = DateTime.ParseExact("01/01/2019", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                Assunto = "Primeiro recado",
                De = "Fulano",
                Para = "Ciclano",
                Mensagem = "Mensagem"
            };

            return recado;
        }
    }
}
