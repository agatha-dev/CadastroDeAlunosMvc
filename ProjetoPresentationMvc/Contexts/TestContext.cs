using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPresentationMvc.Contexts
{
    public class TestContext
    {
        public HttpClient Client { get; set; }

        private TestServer testServer;

        //ler o arquivo appsettings.json do projeto API
        public TestContext()
        {
            //lendo o arquivo appsettings.json do projeto API
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //iniciando o servidor de testes
            testServer = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<ProjetoPresentationMvc.Contexts.TestContext>());

            //gerar o objeto para executar os testes
            Client = testServer.CreateClient();
        }
    }
}
