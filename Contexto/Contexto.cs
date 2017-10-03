using System;
using System.Collections.Generic;
using System.Data.Entity;
using GerenciaIgreja.Models;
using System.Linq;
using System.Web;

namespace GerenciaIgreja.Contexto
{
    public class Contexto:DbContext
    {
        public Contexto():base("GerenciaIgreja")
        {            
        }

        public DbSet<FuncaoMinisterial> FuncaoMinisterial { get; set; }
        public DbSet<Membro> Membro { get; set; }

    }
}