using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Model
{
    public class Categoria
    {

        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
