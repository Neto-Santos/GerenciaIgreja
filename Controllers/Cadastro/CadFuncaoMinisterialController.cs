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
    public class FuncaoMinisterialController : Controller
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

        public JsonResult Inserir(FuncaoMinisterial funcaoMinisterial)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var id = aplicacaoFuncMinisterial.Inserir(funcaoMinisterial);

                    if (id > 0)
                    {
                        idSalvo = id.ToString();
                    }
                    else
                    {
                        resultado = "ERRO";
                    }
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }
            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        public JsonResult Excluir(int Id)
        {
            return Json(aplicacaoFuncMinisterial.Excluir(Id));
        }
    }

    }
