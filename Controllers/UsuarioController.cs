using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutoManager.Models;

namespace ProdutoManager.Controllers
{
    public class UsuarioController : Controller
    {
        static List<Usuario> ListaDeUsuario = new List<Usuario>
        {
            new Usuario{Id=1, Nome="Helinho", Cpf= "242.424.242-4", Email="helinhogatinhonaruto@hotmail.com"},
            new Usuario{Id=2, Nome="Guilherminho Falcão", Cpf= "242.424.242-4", Email="guilherminhodaquebrada@hotmail.com"},
            new Usuario{Id=3, Nome="Leozinhoh", Cpf= "123.456.789-1", Email="bichosoltodequebradabelga@hotmail.com"}
        };

        // GET: Usuario
        public ActionResult Index()
        {
            return View(ListaDeUsuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            ListaDeUsuario.Where(x => x.Id == id);
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                ListaDeUsuario.Add(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}