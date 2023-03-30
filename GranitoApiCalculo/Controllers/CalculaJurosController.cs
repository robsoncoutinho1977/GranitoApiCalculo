using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GranitoApiCalculo.Controllers
{
    [Route("granito/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public CalculaJurosController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        [HttpGet]
        public async Task<ActionResult<decimal>> GetTaxa(Decimal valorinicial, int tempo)
        {
            string urlbase = configuration["Parametros:api_endpoint_urlbase"];
            string url = urlbase + configuration["Parametros:api_endpoint_taxa"];
            decimal retorno = 0;
            try
            {
                HttpMessageHandler handler = new HttpClientHandler()
                {
                };

                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(url),
                    Timeout = new TimeSpan(0, 2, 0)
                };

                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (jsonResponse != null && jsonResponse != "[]")
                {
                    var taxa = JsonConvert.DeserializeObject<string>(jsonResponse);
                    Double taxajuros = Convert.ToDouble(taxa)/100;
                    Double M, C, i, t;
                    C = Convert.ToDouble(valorinicial); //CAPITAL INICIAL DE MIL REAIS;
                    i = taxajuros; //JUROS DE 10% AO MÊS;
                    t = Convert.ToDouble(tempo); //PERIODO DE 2 MESES;
                    M = C * Math.Pow(i + 1, t);

                    return Convert.ToDecimal(M);
                }
                else
                {
                    return BadRequest("Ërro ao recuperar taxa.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Ërro: " + ex.Message);
            }
        }

        
    }
}
