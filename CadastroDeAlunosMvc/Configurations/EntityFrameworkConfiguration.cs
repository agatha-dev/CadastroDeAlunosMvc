using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoDomain.Mvc.Contracts.Repositories;
using ProjetoInfraMvc.Contexts;
using ProjetoInfraMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeAlunosMvc.Configurations
{
    public class EntityFrameworkConfiguration
    {
        public static void AddEntityFramework(IServiceCollection services)
        {
            //configurando a classe SqlContext do projeto Infra.Data
            services.AddDbContext<DataContext>
                (options => options.UseInMemoryDatabase("BDCadastroAluno"));
        }

        public static void ReturnDataContext(IServiceCollection services)
        {
            services.AddScoped<IAlunoRepository, AlunoRepository>()
                .AddDbContext<DataContext>
                (options => options.UseInMemoryDatabase("BDCadastroAluno"));
        }
    }
}
