using ProjetoDomain.Mvc;
using ProjetoDomain.Mvc.Contracts.Repositories;
using ProjetoInfraMvc.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInfraMvc.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        private DataContext dataContext;
        public AlunoRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public Aluno GetMatricula(string matricula)
        {
            return dataContext.Aluno.FirstOrDefault(c => c.Matricula.Equals(matricula));
        }

        public List<Aluno> GetName(string nome)
        {
            return dataContext.Aluno.Where(x => x.Nome == nome).ToList();
        }
    }
}
