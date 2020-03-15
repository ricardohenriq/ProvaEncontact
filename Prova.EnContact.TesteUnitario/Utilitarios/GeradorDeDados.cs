using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Modelos.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Prova.EnContact.TesteUnitario.Utilitarios
{
    public class GeradorDeRecadosAgrupaveis : IEnumerable<object[]>
    {
        private readonly List<object[]> _recados = new List<object[]>
        {
            //Titulo coincide com o primeiro com base na regra: 3, está dentro do prazo de 6 meses, e o De/Para é igual ao De do primeiro recado
            new object[] {
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
                }
            },
            //Titulo coincide integralmente com o primeiro recado, está dentro do prazo de 6 meses, e o De/Para é igual ao De do primeiro recado
            new object[] {
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
                    DataCriacao = DateTime.ParseExact("05/03/2019", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "Primeiro recado",
                    De = "Ciclano",
                    Para = "Fulano",
                    Mensagem = "Mensagem"
                }
            }
        };

        public IEnumerator<object[]> GetEnumerator() => _recados.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class GeradorDeRecadosNaoAgrupaveis : IEnumerable<object[]>
    {
        private readonly List<object[]> _recados = new List<object[]>
        {
            //Titulo do Segundo não coincide com o primeiro
            new object[] {
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
                    DataCriacao = DateTime.ParseExact("02/02/2019", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "Segundo recado",
                    De = "Ciclano",
                    Para = "Fulano",
                    Mensagem = "Mensagem"
                }
            },
            //De/Para é diferente ao De do primeiro recado
            new object[] {
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
                    DataCriacao = DateTime.ParseExact("01/03/2019", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "Primeiro recado",
                    De = "Beltrano",
                    Para = "Deltano",
                    Mensagem = "Mensagem"
                },
            },
            //Fora do prazo de 6 meses
            new object[] {
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
                    DataCriacao = DateTime.ParseExact("05/10/2019", ConstantesUtilitarios.DATA_PT_BR, CultureInfo.InvariantCulture),
                    Assunto = "respondendo: Primeiro recado",
                    De = "Ciclano",
                    Para = "Fulano",
                    Mensagem = "Mensagem"
                }
            }
        };

        public IEnumerator<object[]> GetEnumerator() => _recados.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
