using System;
using System.Collections.Generic;

namespace Aulas_27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 2;
            p1.Nome = "Sprite";
            p1.Preco = 4.5f;

            p1.Cadastrar(p1);

            List<Produto> lista = p1.Ler();
            
            foreach (Produto item in lista)
            {
                Console.WriteLine( $"R$:{item.Preco} - {item.Nome}" );
            }

            p1.Buscar( "Coca-Cola" );


        }
    }
}
