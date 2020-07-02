using System;
using System.Collections.Generic;

namespace Aulas_27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 1;
            p1.Nome = "Coca-Cola";
            p1.Preco = 5f;

            p1.Cadastrar(p1);
            // p1.Remover("Sprite");

            Produto alterado = new Produto();

            alterado.Codigo = 2;
            alterado.Nome = "Pepsi";
            alterado.Preco = 5;

            p1.Alterar();

            List<Produto> lista = p1.Ler();
            
            foreach (Produto item in lista)
            {
                Console.WriteLine( $"R$:{item.Preco} - {item.Nome}" );
            }

            p1.Filtrar("Sprite");


        }
    }
}
