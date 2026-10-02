using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using MiBotica.SolPedido.Utiles.Helpers;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class UsuarioController : BaseLN
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<Usuario> usuario = new List<Usuario>();
            usuario = new UsuarioLN().ListaUsuarios(); /*hace referencia a un método
            ListarUsuario en la capa UsuarioLN.Que por ahora no existe.Para crear esta
            método dar clik derecho sobre UsuarioLN() y pulsar ir a Definición.*/

            return View(usuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
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
                usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);

                new UsuarioLN().InsertarUsuario(usuario);
                TempData["Mensaje"] = "Usuario creado correctamente.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = new Usuario();

            List<Usuario> lista = new UsuarioLN().ListaUsuarios();

            usuario = lista.Find(x => x.IdUsuario == id);

            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(usuario.ClaveTexto))
                {
                    usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);

                    new UsuarioLN().ModificarUsuario(usuario, true);
                }
                else
                {
                    new UsuarioLN().ModificarUsuario(usuario, false);
                }

                TempData["Mensaje"] = "Cambios guardados correctamente.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Usuario usuario = new UsuarioLN().BuscarUsuarioPorId(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmacion(int id)
        {
            new UsuarioLN().EliminarUsuario(id);
            TempData["Mensaje"] = "El registro se eliminó correctamente.";
            return RedirectToAction("Index");
        }
    }
}
