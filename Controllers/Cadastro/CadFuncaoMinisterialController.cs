using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GerenciaIgreja.Aplicacao;
using System.Web.Mvc;
using GerenciaIgreja.Models;
using GerenciaIgreja.Contexto;


namespace GerenciaIgreja.Controllers.Cadastro
{
    public class CadFuncaoMinisterialController : Controller
    {
        appFuncaoMinisterial aplicacaoFuncMinisterial = new appFuncaoMinisterial();
        public ActionResult Index()
        { 
            return View(aplicacaoFuncMinisterial.Listar());
        }

        public JsonResult Recuperar(int Id)
        {
            return Json(aplicacaoFuncMinisterial.Recuperar(Id));
        }
    }
}