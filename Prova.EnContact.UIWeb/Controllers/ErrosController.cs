using Microsoft.AspNetCore.Mvc;
using Prova.EnContact.Compartilhado.Constantes;
using Prova.EnContact.Interfaces.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.EnContact.UIWeb.Controllers
{
    public class ErrosController : Controller
    {
        [Route("Erros/Erro")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Erro()
        {
            var erro = new DtoErro { RequisicaoId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier };
            return View(erro);
        }

        [Route("Erros/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var erro = new DtoErroHttp();
            erro.RequisicaoId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            erro.CodigoHttp = statusCode;

            switch (statusCode)
            {
                case ConstantesStatus.VERSAO_HTTP_NAO_SUPORTADA:
                    erro.Titulo = ConstantesPalavras.ERRO_505;
                    break;
                case ConstantesStatus.UPGRADE_OBRIGATORIO:
                    erro.Titulo = ConstantesPalavras.ERRO_426;
                    break;
                case ConstantesStatus.TIPO_DE_MIDIA_NAO_SUPORTADO:
                    erro.Titulo = ConstantesPalavras.ERRO_415;
                    break;
                case ConstantesStatus.TEMPO_DE_REQUISICAO_ESGOTOU:
                    erro.Titulo = ConstantesPalavras.ERRO_408;
                    break;
                case ConstantesStatus.SOLICITADA_DE_FAIXA_NAO_SATISFATORIA:
                    erro.Titulo = ConstantesPalavras.ERRO_416;
                    break;
                case ConstantesStatus.SERVICO_INDISPONIVEL:
                    erro.Titulo = ConstantesPalavras.ERRO_503;
                    break;
                case ConstantesStatus.REQUISICAO_INVALIDA:
                    erro.Titulo = ConstantesPalavras.ERRO_400;
                    break;
                case ConstantesStatus.PROIBIDO:
                    erro.Titulo = ConstantesPalavras.ERRO_403;
                    break;
                case ConstantesStatus.PRE_CONDICAO_FALHOU:
                    erro.Titulo = ConstantesPalavras.ERRO_412;
                    break;
                case ConstantesStatus.PEDIDO_URI_MUITO_GRANDE:
                    erro.Titulo = ConstantesPalavras.ERRO_414;
                    break;
                case ConstantesStatus.PAGAMENTO_NECESSARIO:
                    erro.Titulo = ConstantesPalavras.ERRO_402;
                    break;
                case ConstantesStatus.NAO_IMPLEMENTADO:
                    erro.Titulo = ConstantesPalavras.ERR0_501;
                    break;
                case ConstantesStatus.NAO_ENCONTRADO:
                    erro.Titulo = ConstantesPalavras.ERRO_404;
                    break;
                case ConstantesStatus.NAO_AUTORIZADO:
                    erro.Titulo = ConstantesPalavras.ERRO_401;
                    break;
                case ConstantesStatus.NAO_ACEITAVEL:
                    erro.Titulo = ConstantesPalavras.ERRO_406;
                    break;
                case ConstantesStatus.METODO_NAO_PERMITIDO:
                    erro.Titulo = ConstantesPalavras.ERRO_405;
                    break;
                case ConstantesStatus.GONE:
                    erro.Titulo = ConstantesPalavras.ERRO_410;
                    break;
                case ConstantesStatus.GATEWAY_TIME_OUT:
                    erro.Titulo = ConstantesPalavras.ERRO_504;
                    break;
                case ConstantesStatus.FECHADO:
                    erro.Titulo = ConstantesPalavras.ERRO_423;
                    break;
                case ConstantesStatus.FALHA_NA_EXPECTATIVA:
                    erro.Titulo = ConstantesPalavras.ERRO_417;
                    break;
                case ConstantesStatus.FALHA_DE_DEPENDENCIA:
                    erro.Titulo = ConstantesPalavras.ERRO_424;
                    break;
                case ConstantesStatus.ERRO_INTERNO_DO_SERVIDOR:
                    erro.Titulo = ConstantesPalavras.ERRO_500;
                    break;
                case ConstantesStatus.ENTIDADE_IMPROCESSAVEL:
                    erro.Titulo = ConstantesPalavras.ERRO_422;
                    break;
                case ConstantesStatus.ENTIDADE_DE_SOLICITACAO_MUITO_GRANDE:
                    erro.Titulo = ConstantesPalavras.ERRO_413;
                    break;
                case ConstantesStatus.CONFLITO:
                    erro.Titulo = ConstantesPalavras.ERRO_409;
                    break;
                case ConstantesStatus.COMPRIMENTO_NECESSARIO:
                    erro.Titulo = ConstantesPalavras.ERROO_411;
                    break;
                case ConstantesStatus.COLECAO_NAO_ORDENADA:
                    erro.Titulo = ConstantesPalavras.ERRO_425;
                    break;
                case ConstantesStatus.BLOQUEADOS_PELO_CONTROLE_DE_PAIS_DO_WINDOWS:
                    erro.Titulo = ConstantesPalavras.ERRO_450;
                    break;
                case ConstantesStatus.BAD_GATEWAY:
                    erro.Titulo = ConstantesPalavras.ERRO_502;
                    break;
                case ConstantesStatus.AUTENTICACAO_DE_PROXY_NECESSARIA:
                    erro.Titulo = ConstantesPalavras.ERRO_407;
                    break;
                default:
                    erro.CodigoHttp = ConstantesStatus.ERRO_INTERNO_DO_SERVIDOR;
                    erro.Titulo = ConstantesPalavras.ERRO_500;
                    break;
            }

            return View(erro);
        }
    }
}
