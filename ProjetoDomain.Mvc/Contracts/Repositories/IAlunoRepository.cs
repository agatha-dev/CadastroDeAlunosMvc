using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDomain.Mvc.Contracts.Repositories
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        Aluno GetMatricula(string matricula);
        List<Aluno> GetName(string nome);
    }
}
