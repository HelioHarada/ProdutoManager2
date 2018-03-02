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
            new Usuario{Id=1, Nome="Helio", Cpf= "242.424.242-4", Email="helioo@hotmail.com"},
            new Usuario{Id=2, Nome="Tiago", Cpf= "242.424.242-4", Email="guilherminhodaquebrada@hotmail.com"},
            new Usuario{Id=3, Nome="Leozin", Cpf= "123.456.789-1", Email="bichosoltodequebradabelga@hotmail.com"}
        };

        // GET: Usuario
        public ActionResult Index()
        {
            return View(ListaDeUsuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {

            var usuario = ListaDeUsuario.FirstOrDefault(x => x.Id == id);

            return View(usuario);
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = ListaDeUsuario.FirstOrDefault(m => m.Id == id);
            if(usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id","Nome","Cpf","Email")] Usuario usuario)
        {
            try
            {
                // TODO: Add update logic here
                
                if (id != usuario.Id)
                {
                    return NotFound();
                }
                if(ModelState.IsValid)
                {
                    var UsuarioTemp = ListaDeUsuario.FirstOrDefault(c => c.Id == id);
                    if(UsuarioTemp != null)
                    {
                        UsuarioTemp.Nome = usuario.Nome;
                        UsuarioTemp.Cpf = usuario.Cpf;
                        UsuarioTemp.Email = usuario.Email;
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = ListaDeUsuario.FirstOrDefault(y => y.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var usuario = ListaDeUsuario.FirstOrDefault(m => m.Id == id);
                ListaDeUsuario.Remove(usuario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}