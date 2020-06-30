using System;
using System.Collections.Generic;
using System.IO;

namespace Aulas_27_28_29_30
{
    public class Produto
    {
        public int Codigo { get; set; } 
        public string Nome { get; set; }    
        public float Preco { get; set; }    

        //Caminho
        private const string PATH = "Database/produto.csv";
        private const string Pasta = "C:/Users/User/Desktop/EAD SENAI/EAD DEV/Aula_27_28_29_30/Aulas_27_28_29_30/Database/";

        public Produto()
        {
            //Cria o arquivo caso não exista
            if(!Directory.Exists(Pasta))
            {
                Directory.CreateDirectory(Pasta);
            }
            //Cria o arquivo caso não exista
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public void Cadastrar(Produto prod){

            string[] linha = new string[] { PrepararLinha(prod) };
            File.AppendAllLines(PATH, linha);

        }

        public List<Produto> Ler()
        {
            // Criamos lista para guardar o retorno
            List<Produto> prod = new List<Produto>();

            // Lemos o .csv e separamos um array de linhas 
            string[] linhas = File.ReadAllLines(PATH);

            // Varremos nossas linhas
            foreach(string linha in linhas)
            {
                // codigo=1;nome=Gibson;preco=5500
                string[] dado = linha.Split(";");

                Produto p = new Produto();
                p.Codigo = Int32.Parse( dado[0].Split("=")[1] );
                p.Nome = dado[1].Split("=")[1];
                p.Preco = float.Parse( dado[2].Split("=")[1] );

                prod.Add(p);
            }
            
            return prod;
        }

        /// <summary>
        /// Método que separa o simbolo = da string do csv
        /// </summary>
        /// <param name="dado">Coluna do csv separada</param>
        /// <returns>string apenas com o valor da coluna</returns>
        public string Separar(string dado)
        {
            // codigo=1
            // [0]codigo
            // [1]1
            return dado.Split("=")[1];
        }

        //  1   ; sapato ; 34,99
        //Codigo; Produto; Preço
        private string PrepararLinha(Produto p){
            return $"codigo={p.Codigo};nome={p.Nome};preço={p.Preco}";
        }



    }
}