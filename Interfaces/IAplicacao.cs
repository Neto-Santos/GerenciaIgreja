using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GerenciaIgreja.Models;
using GerenciaIgreja.Aplicacao;
using System.Threading.Tasks;

namespace GerenciaIgreja
{
    interface IAplicacao
    {
        int Inserir(object objeto);
        void Alterar(object objeto);
        IEnumerable<object> Listar();
        object Recuperar(int Id);
        bool Excluir(int Id);
        object RetornaUltimo();
        
    }
}
