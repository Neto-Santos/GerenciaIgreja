using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GerenciaIgreja.Models;
using GerenciaIgreja.Aplicacao;
using GerenciaIgreja.Contexto;
using System.Web.Mvc;

namespace GerenciaIgreja.Controllers.Cadastro
{
    public class MembroController : Controller
    {
        Contexto.Contexto contexto = new Contexto.Contexto();
        appMembro appMembro = new appMembro();
        const int quantMaxLinhasPagina = 5;
               
        public ActionResult Index()
        {
            var quant = appMembro.RecuperaQuantidade();
            ViewBag.ListaTamanhoPagina = new SelectList(new int[] { quantMaxLinhasPagina, 10, 15 }, quantMaxLinhasPagina);
            ViewBag.QuantMaxLinhasPagina = quantMaxLinhasPagina;
            ViewBag.PaginaAtual = 1;
            var difQuantPaginas = (quant % ViewBag.QuantMaxLinhasPagina) > 0 ? 1 : 0;
            ViewBag.QuantPaginas = (quant / ViewBag.QuantMaxLinhasPagina) + difQuantPaginas;

            ViewBag.model = new Membro();

            return View(appMembro.paginacao(ViewBag.PaginaAtual,ViewBag.QuantMaxLinhasPagina));
        }
        public JsonResult Recuperar(int Id)
        {

            return Json(appMembro.Recuperar(Id));
        }

        public JsonResult Inserir(Membro Membro)
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
                    var id = appMembro.Inserir(Membro);

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
            return Json(appMembro.Excluir(Id));
        }
        public JsonResult paginacao(int pagina, int tamPagina)
        {
            var lista = appMembro.paginacao(pagina, tamPagina);

            return Json(lista);
        }
    }

}