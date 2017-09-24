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

        public void Excluir(int Id)
        {
            FuncaoMinisterial objFuncaoMinisterial = contexto.FuncaoMinisterial.Where(x => x.Id == Id).First();
            contexto.Set<FuncaoMinisterial>().Remove(objFuncaoMinisterial);
            contexto.SaveChanges();
        }

        public void Inserir(object funcaoMinisterial)
        {
            contexto.FuncaoMinisterial.Add((FuncaoMinisterial)funcaoMinisterial);
            contexto.SaveChanges();
        }

        public void Alterar(object funcaoMinisterial)
        {
            var modelo = (FuncaoMinisterial)funcaoMinisterial;
            var alterar = contexto.FuncaoMinisterial.Where(x => x.Id == modelo.Id).First();
            alterar.Nome = modelo.Nome;
            alterar.Ativo = modelo.Ativo;
            contexto.SaveChanges();
        }


    }
}