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
        public ActionResult Details(int Id)
        {
         var produto = ListaDeProdutos.FirstOrDefault(x => x.Id == Id);

         return View(produto);
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
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var produto = ListaDeProdutos.FirstOrDefault(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id", "Nome", "Categoria", "Preco")] Produto produto)
        {
            try
            {
                // TODO: Add update logic here

                if (id != produto.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    var ProdutoTemp = ListaDeProdutos.FirstOrDefault(c => c.Id == id);
                    if (ProdutoTemp != null)
                    {
                        ProdutoTemp.Nome = produto.Nome;
                        ProdutoTemp.Categoria = produto.Categoria;
                        ProdutoTemp.Preco = produto.Preco;
                    }
                    else
                    {
                        return NotFound();
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = ListaDeProdutos.FirstOrDefault(y => y.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var produto = ListaDeProdutos.FirstOrDefault(y => y.Id == id);
                ListaDeProdutos.Remove(produto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}