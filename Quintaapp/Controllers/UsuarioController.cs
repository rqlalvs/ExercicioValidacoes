using Quintaapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quintaapp.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
			var usuario = new Usuario();
            return View(usuario);
        }
		[HttpPost]
		public ActionResult Index(Usuario usuario)
		{
			if (string.IsNullOrEmpty(usuario.Nome))
			{
				ModelState.AddModelError("Nome", "O campo nome é obrigatório.");
			}
			if (usuario.Senha != usuario.ConfirmarSenha)
			{
				ModelState.AddModelError("", "As senhas são diferentes.");
			}
			if (ModelState.IsValid)
			{
				return View("Resultado", usuario);
			}
			return View(usuario);
		}
		public ActionResult Resultado (Usuario usuario)
		{
            return View(usuario);
		}
        public ActionResult ValidaLogin(string login)
        {
            var dbEXEMPLO = new Collection<string>
            {
                "Catraio",
                "fedelho",
                "Infante"
            };
            return Json(dbEXEMPLO.All(a => a.ToLower() != login.ToLower()), JsonRequestBehavior.AllowGet);
        }
    }
}