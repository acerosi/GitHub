using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultaCEP.Serviço.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultaCEP.Serviço
{
   public class ViaCepServico
   {
      private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

      public static Endereco BuscarEnderecoViaCep(string cep)
      {
         string NovoEnderecoURL = string.Format(EnderecoURL, cep);

         WebClient wc = new WebClient();
         string conteudo = wc.DownloadString(NovoEnderecoURL);
         
         Endereco End = JsonConvert.DeserializeObject<Endereco>(conteudo);
         if (End.cep == null) return null;

         return End;
      }
      
   }
}
