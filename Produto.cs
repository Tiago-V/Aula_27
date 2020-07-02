using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Aulas_27_28_29_30
{
    public class Produto
    {
        public Produto(int codigo, string nome, float preco) 
        {
            this.Codigo = codigo;
                this.Nome = nome;
                this.Preco = preco;
               
        }
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

        /// <summary>
        /// Lê o csv
        /// </summary>
        /// <returns>Ler a lista do csv</returns>
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

            prod = prod.OrderBy(z => z.Nome).ToList();

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

        // DESAFIO: Criar Metódo de Busca por nome, passado como argumento
        // EXPRESSÃO LAMBDA (x => x.Nome == "nome")

        /// <summary>
        /// Filtrar produtos por nome
        /// </summary>
        /// <param name="_nome">Inserir nome do produto</param>
        /// <returns>Retornar todos os produto do nome inserido</returns>
        public List<Produto> Filtrar(string _nome)
        {
            return Ler().FindAll( x => x.Nome == _nome);
        }

        /// <summary>
        /// Remover produtos por lista do arquivo
        /// </summary>
        /// <param name="_termo">Termo a ser excluído</param>
        public void Remover(string _termo)
        {
            // Criamos lista de linhas para fazer uma espécie do backup na memória do sistema
            List<string> linhas = new List<string>();

            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null){
                    linhas.Add(linha);
                }
                // código=2;nome=Tagina;preço=5500
                linhas.RemoveAll(z => z.Contains(_termo));
            }
            
            // Criamos uma forma de reescrever o arquivo sem as linhas removidas
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in linhas)
                {
                    output.Write(ln+"\n");
                }
            }

            ReescreverCSV(linhas);
        }

        /// <summary>
        /// Altera o produto
        /// </summary>
        /// <param name="_produtoAlterado">Objeto de produto</param>
        public void Alterar(Produto _produtoAlterado)
        {
             // Criamos lista de linhas para fazer uma espécie do backup na memória do sistema
            List<string> linhas = new List<string>();

            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }

            }
            // codigo=2;nome=Sprite;preço=4,5
            // linhas.RemoveAll( z => z.Split(";")[0].Contains( _produtoAlterado.Codigo.ToString() ) );

            // codigo=1;nome=Coca-Cola;preço=5
            linhas.RemoveAll( z => z.Split(";")[0].Split("=")[1] == _produtoAlterado.Codigo.ToString() );

            // Adicionamos a linha alterada na lista de backup
            linhas.Add( PrepararLinha( _produtoAlterado ) );

            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            ReescreverCSV(linhas);

        }

        private void ReescreverCSV(List<string> lines)
        {
             using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in lines)
                {
                    output.Write(ln+"\n");
                }
            }
        }

        //  1   ; sapato ; 34,99
        //Codigo; Produto; Preço
        private string PrepararLinha(Produto p){
            return $"codigo={p.Codigo};nome={p.Nome};preço={p.Preco}";
        }


        
    }
}