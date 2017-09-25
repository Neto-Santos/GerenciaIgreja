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

        public void Alterar(object funcaoMinisterial)
        {
            var modelo = (FuncaoMinisterial)funcaoMinisterial;
            var alterar = contexto.FuncaoMinisterial.Where(x => x.Id == modelo.Id).First();
            alterar.Nome = modelo.Nome;
            alterar.Ativo = modelo.Ativo;
            contexto.SaveChanges();
        }

        public object RetornaUltimo()
        {
            return contexto.FuncaoMinisterial.Last();
        }

        public int Inserir(object objeto)
        {
            var Id = 0;
            var objFuncaoMinisterial = (FuncaoMinisterial)objeto;

            contexto.FuncaoMinisterial.Add(objFuncaoMinisterial);
            contexto.SaveChanges();
            Id = objFuncaoMinisterial.Id;

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
    }
}
