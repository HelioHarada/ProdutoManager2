using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoManager.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Categoria { get; set; }
        public decimal Preco { get; set; }


    }
}
