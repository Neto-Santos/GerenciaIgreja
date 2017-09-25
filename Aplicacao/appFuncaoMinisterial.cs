using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GerenciaIgreja.Models;
using GerenciaIgreja.Contexto;


namespace GerenciaIgreja.Aplicacao
{
    public class appFuncaoMinisterial : IAplicacao
    {
        Contexto.Contexto contexto = new Contexto.Contexto();

        public IEnumerable<object> Listar()
        {
            return contexto.FuncaoMinisterial.ToList();
        }

        public object Recuperar(int Id)
        {
            return contexto.FuncaoMinisterial.Where(x => x.Id == Id).First();
        }

        public object RetornaUltimo()
        {
            return contexto.FuncaoMinisterial.Last();
        }

        public int Inserir(object objeto)
        {
            var Id = 0;
            var objFuncaoMinisterial = (FuncaoMinisterial)objeto;

            if (objFuncaoMinisterial.Id == 0)
            {
                contexto.FuncaoMinisterial.Add(objFuncaoMinisterial);
                contexto.SaveChanges();
                Id = objFuncaoMinisterial.Id;
            }
            else
            {
               Id =  Alterar(objFuncaoMinisterial);
            }

            return Id;

        }

        public bool Excluir(int Id)
        {

            var ret = false;
            try
            {
                FuncaoMinisterial objFuncaoMinisterial = contexto.FuncaoMinisterial.Where(x => x.Id == Id).First();
                contexto.Set<FuncaoMinisterial>().Remove(objFuncaoMinisterial);
                contexto.SaveChanges();
                ret = true;
            }
            catch (Exception)
            {
                ret = false;
                throw;
            }

            return ret;
        }

        public IEnumerable<object> paginacao(int paginaAtual, int itensPagina)
        {

            return contexto.FuncaoMinisterial.OrderBy(x => x.Id)
                       .Skip((paginaAtual - 1) * itensPagina)
                       .Take(itensPagina);
        }

        public int RecuperaQuantidade()
        {
            return contexto.FuncaoMinisterial.Count();
        }

        public int Alterar(object objeto)
        {
            var modelo = (FuncaoMinisterial)objeto;
            var alterar = contexto.FuncaoMinisterial.Where(x => x.Id == modelo.Id).First();
            alterar.Nome = modelo.Nome;
            alterar.Ativo = modelo.Ativo;
            contexto.SaveChanges();

            return modelo.Id;
        }
    }
}