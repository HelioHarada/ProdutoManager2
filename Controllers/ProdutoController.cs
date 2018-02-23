using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutoManager.Models;

namespace ProdutoManager.Controllers
{
    public class ProdutoController : Controller
    {
        static List<Produto> ListaDeProdutos = new List<Produto>
        {
            new Produto{Id=1, Nome="Soup tomato", Categoria= "Groceries", Preco=1},
            new Produto{Id=2, Nome="Yo-Yo", Categoria="toys", Preco = 3.78M},
            new Produto{Id=3, Nome="Hammer", Categoria="Hardware", Preco= 16.99M}
        };

        // GET: Produto
        public ActionResult Index()
        {
            return View(ListaDeProdutos);
            
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            ListaDeProduto.Where(x => x.Id == id);
            return View();
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            try
            {
                ListaDeProdutos.Add(produto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produto/Edit/5
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

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produto/Delete/5
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