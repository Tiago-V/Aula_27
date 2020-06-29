using System;

namespace Aulas_27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 3;
            p1.Nome = "Nike Dominant";
            p1.Preco = 120f;

            p1.Cadastrar(p1);


            
            
            
        }
    }
}
