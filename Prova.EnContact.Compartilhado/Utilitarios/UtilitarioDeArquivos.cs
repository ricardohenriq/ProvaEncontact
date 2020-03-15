using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;

namespace Prova.EnContact.Compartilhado.Utilitarios
{
    public static class UtilitarioDeArquivos
    {
        public static string CarregueArquivoTexto(string endereco)
        {
            using (var sr = new StreamReader(endereco))
            {
                var arquivoTexto = sr.ReadToEnd();
                return arquivoTexto;
            }
        }

        public static T CarregueJsonArquivo<T>(string endereco)
        {
            var jsonTexto = CarregueArquivoTexto(endereco);
            var jsonObj = JsonConvert.DeserializeObject<T>(jsonTexto);

            return jsonObj;
        }

        public static dynamic CarregueJsonArquivo(string endereco)
        {
            var jsonTexto = CarregueArquivoTexto(endereco);
            dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(jsonTexto);

            return jsonObj;
        }
    }
}
