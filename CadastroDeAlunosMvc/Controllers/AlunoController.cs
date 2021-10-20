using CadastroDeAlunosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using ProjetoDomain.Mvc;
using ProjetoDomain.Mvc.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeAlunosMvc.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(AlunoCadastroModel alunoCadastro,
           [FromServices] IAlunoRepository alunoRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var aluno = new Aluno();

                    aluno.Id = Guid.NewGuid();
                    aluno.Nome = alunoCadastro.Nome;
                    aluno.Matricula = alunoCadastro.Matricula;
                    aluno.DataNascimento = alunoCadastro.DataNascimento.Date;

                    alunoRepository.Insert(aluno);

                    TempData["MensagemSucesso"] = "Aluno cadastrado com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Ocorreu um erro: " + e.Message;
                }
            }

            return View();
        }

        public IActionResult Consultar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Consultar(AlunoConsultaModel model, 
            [FromServices] IAlunoRepository alunoRepository)
        {
            try
            {
                model.Alunos = alunoRepository.GetAll();

                if (model.Alunos.Count > 0)
                {
                    TempData["MensagemSucesso"] = $"Consulta realizada com sucesso. {model.Alunos.Count} Aluno(s) obtido(s).";
                }
                else
                {
                    TempData["MensagemAlerta"] = "Nenhum resultado foi encontrado para a busca realizada.";
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Ocorreu um erro: " + e.Message;
            }

            return View(model);
        }

        public IActionResult Exclusao(Guid Id,
            [FromServices] IAlunoRepository alunoRepository)
        {
            try
            {
                var aluno = alunoRepository.GetById(Id);

                if(aluno != null)
                {
                    alunoRepository.Delete(aluno);
                    TempData["MensagemSucesso"] = $"O Aluno {aluno.Nome} deletado com sucesso.";
                }
                else
                {
                    TempData["MensagemAlerta"] = "Nenhum resultado foi encontrado para deletar a busca realizada.";
                }
            }
            catch (Exception e)
            {
                TempData["MensagemError"] = "Ocorreu um erro: " + e.Message;
            }
            return View("Consultar");
        }

        public IActionResult Edicao(Guid Id, 
            [FromServices] IAlunoRepository alunoRepository)
        {
            var model = new AlunoEdicaoModel();

            try
            {
                var aluno = alunoRepository.GetById(Id);

                if (aluno != null)
                {
                    model.Id = aluno.Id;
                    model.Nome = aluno.Nome;
                    model.Matricula = aluno.Matricula;
                    model.DataNascimento = aluno.DataNascimento;
                }
                else
                {
                    TempData["MensagemAlerta"] = "Aluno não foi encontrado.";
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Ocorreu um erro: " + e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edicao(AlunoEdicaoModel model, 
            [FromServices] IAlunoRepository alunoRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var aluno = alunoRepository.GetById(model.Id);

                    aluno.Id = model.Id;
                    aluno.Nome = model.Nome;
                    aluno.Matricula = model.Matricula;
                    aluno.DataNascimento = model.DataNascimento;

                    alunoRepository.Update(aluno);

                    TempData["MensagemSucesso"] = $"Aluno '{aluno.Nome}', atualizado com sucesso.";
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Ocorreu um erro: " + e.Message;
                }             
            }
            else
            {
                TempData["MensagemAlerta"] = "Ocorreram erros de validação no preenchimento do formulário.";
            }

            return View();
        }
    }
}
