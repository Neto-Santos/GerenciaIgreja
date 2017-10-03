using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciaIgreja.Models
{
    public class FuncaoMinisterial
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}