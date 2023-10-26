using AlunosWebApp.Data;
using AlunosWebApp.Models;
using AlunosWebApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlunosWebApp.Controllers
{
    public class AlunosController : Controller
    {
        private readonly AlunosWebAppDbContext _alunosWebAppDbContext;

        public AlunosController(AlunosWebAppDbContext alunosWebAppDbContext)
        {
            _alunosWebAppDbContext = alunosWebAppDbContext;
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Adicionar(AdicionarAlunoViewModel adicionarAlunoViewModel)
        {
            Aluno aluno = new Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = adicionarAlunoViewModel.Nome,
                Email = adicionarAlunoViewModel.Email,
                Ativo = adicionarAlunoViewModel.Ativo,
            };

            await _alunosWebAppDbContext.Alunos.AddAsync(aluno);
            await _alunosWebAppDbContext.SaveChangesAsync();

            return RedirectToAction("Adicionar");
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Aluno> alunos = await _alunosWebAppDbContext.Alunos.ToListAsync();
            return View(alunos);
        }
    }
}
