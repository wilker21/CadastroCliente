using CadastroCliente.Infraestrutura;
using CadastroCliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CadastroCliente.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClienteRepository _repo;

        public HomeController(ClienteRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var clientes = await _repo.ListarAsync();

            return View(new ListarViewModel
            {
                Clientes = clientes.Select(ClienteDto.ParaResultado)
            });
        }

        [HttpPost]
        public async Task<ActionResult> Index(ListarViewModel model) 
        {
            var clientes = await _repo.ListarAsync(model.Filtro.Filtro);

            return View(new ListarViewModel
            {
                Clientes = clientes.Select(ClienteDto.ParaResultado),
                Filtro = model.Filtro
            });;
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(AdicionarViewModel cliente)
        {
            if (!ViewData.ModelState.IsValid) return View(cliente);
            
            if (cliente is null) return RedirectToAction(nameof(Index));
            var entidade = AdicionarViewModel.ParaEntidade(cliente);

            await _repo.AdicionarAsync(entidade);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Editar(Guid id)
        {
            var cliente = await _repo.ObterAsync(id);
            if (cliente is null) return RedirectToAction(nameof(Index));

            return View(EditarViewModel.ParaResultado(cliente));
        }

        [HttpPost]
        public async Task<ActionResult> Editar(EditarViewModel cliente)
        {
            if (cliente is null) return RedirectToAction(nameof(Index));
            if (!ViewData.ModelState.IsValid) return View(cliente);

            var entidade = await _repo.ObterAsync(cliente.Id);
            if (entidade is null) return View(nameof(Index));

            entidade.Alterar(cliente.Nome, cliente.Documento, cliente.Telefone, cliente.TipoPessoa) ;

            await _repo.AtualizarAsync(entidade);

            return RedirectToAction(nameof(Editar), new { id = cliente.Id });
        }

        public async Task<ActionResult> Apagar(Guid id)
        {
            var cliente = await _repo.ObterAsync(id);
            if (cliente is null) return RedirectToAction(nameof(Index));

            await _repo.DeletarAsync(cliente);
            return RedirectToAction(nameof(Index));
        }
    }
}