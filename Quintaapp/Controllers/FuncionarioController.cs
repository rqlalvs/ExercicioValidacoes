using Quintaapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quintaapp.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
			Funcionario func = new Funcionario()
			{
				FuncId = 1,
				FuncNome = "Broquinho",
				FuncFuncao = "Fulião"
			};

            return View(func);
        }
		[HttpPost]
		public ActionResult Listar(Funcionario funcionario)
		{
			return View(funcionario);
		}

	}
	 
}