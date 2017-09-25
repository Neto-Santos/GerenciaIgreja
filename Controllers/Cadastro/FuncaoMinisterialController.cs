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

        const int quantMaxLinhasPagina = 5;
        public ActionResult Index()
        {
            var quant = aplicacaoFuncMinisterial.RecuperaQuantidade();
            ViewBag.ListaTamanhoPagina = new SelectList(new int[] { quantMaxLinhasPagina, 10, 15 }, quantMaxLinhasPagina);
            ViewBag.QuantMaxLinhasPagina = quantMaxLinhasPagina;
            ViewBag.PaginaAtual = 1;
            var difQuantPaginas = (quant % ViewBag.QuantMaxLinhasPagina) > 0 ? 1 : 0;
            ViewBag.QuantPaginas = (quant / ViewBag.QuantMaxLinhasPagina) + difQuantPaginas;

            return View(aplicacaoFuncMinisterial.paginacao(ViewBag.PaginaAtual,ViewBag.QuantMaxLinhasPagina));
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
        public JsonResult paginacao(int pagina,int tamPagina)
        {             
            var lista = aplicacaoFuncMinisterial.paginacao(pagina,tamPagina);

            return Json(lista);
        }
    }

}