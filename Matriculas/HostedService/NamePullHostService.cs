using Matriculas.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Matriculas.HostedService
{
    
    public class NamePullHostService : IHostedService
    {

        HttpClient client;
        Uri usuarioUri;

        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public NamePullHostService(ILogger<NamePullHostService> logger)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
            
        }

        private void ExecuteProcess(object state)
        {
            _logger.LogInformation("### Proccess executing ###");
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://github.com/centraldedados/gerador-nome#api");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                _logger.LogInformation($"{client}");
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (client == HttpClient.DefaultProxy)
            {
                getAll();
            }
        }

        private void getAll()
        {
            //chamando a api pela url
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Matriculas").Result;

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
               
            }

            //Se der erro na chamada, mostra o status do código de erro.
            else
            {

            }
        }


        

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("### Proccess stoping ###");
            _logger.LogInformation($"{client}");
            return Task.CompletedTask;
        }
    }
}
