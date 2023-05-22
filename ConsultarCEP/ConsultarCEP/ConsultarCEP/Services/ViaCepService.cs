using ConsultarCEP.Services.Entitys;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ConsultarCEP.Services
{
    public class ViaCepService
    {
        private static string Url = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoPorCep(string cep)
        {
            string novaUrl = String.Format(Url, cep);
            WebClient wc = new WebClient();

            string conteudo = wc.DownloadString(novaUrl);
            Endereco ed = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if(ed.cep == null) return null;

            return ed;
        }
    }
}
