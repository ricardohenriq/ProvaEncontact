using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.EnContact.Compartilhado.Constantes
{
    public static class ConstantesStatus
    {
        public const int VERSAO_HTTP_NAO_SUPORTADA = 505;
        public const int UPGRADE_OBRIGATORIO = 426;
        public const int TIPO_DE_MIDIA_NAO_SUPORTADO = 415;
        public const int TEMPO_DE_REQUISICAO_ESGOTOU = 408;
        public const int SOLICITADA_DE_FAIXA_NAO_SATISFATORIA = 416;
        public const int SERVICO_INDISPONIVEL = 503;
        public const int REQUISICAO_INVALIDA = 400;
        public const int PROIBIDO = 403;
        public const int PRE_CONDICAO_FALHOU = 412;
        public const int PEDIDO_URI_MUITO_GRANDE = 414;
        public const int PAGAMENTO_NECESSARIO = 402;
        public const int NAO_IMPLEMENTADO = 501;
        public const int NAO_ENCONTRADO = 404;
        public const int NAO_AUTORIZADO = 401;
        public const int NAO_ACEITAVEL = 406;
        public const int METODO_NAO_PERMITIDO = 405;
        public const int GONE = 410;
        public const int GATEWAY_TIME_OUT = 504;
        public const int FECHADO = 423;
        public const int FALHA_NA_EXPECTATIVA = 417;
        public const int FALHA_DE_DEPENDENCIA = 424;
        public const int ERRO_INTERNO_DO_SERVIDOR = 500;
        public const int ENTIDADE_IMPROCESSAVEL = 422;
        public const int ENTIDADE_DE_SOLICITACAO_MUITO_GRANDE = 413;
        public const int CONFLITO = 409;
        public const int COMPRIMENTO_NECESSARIO = 411;
        public const int COLECAO_NAO_ORDENADA = 425;
        public const int BLOQUEADOS_PELO_CONTROLE_DE_PAIS_DO_WINDOWS = 450;
        public const int BAD_GATEWAY = 502;
        public const int AUTENTICACAO_DE_PROXY_NECESSARIA = 407;
    }
}
