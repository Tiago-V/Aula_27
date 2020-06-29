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
        
        public Produto()
        {
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


        //  1   ; sapato ; 34,99
        //Codigo; Produto; Preço
        private string PrepararLinha(Produto p){
            return $"codigo={p.Codigo};nome={p.Nome};preço={p.Preco}";
        }



    }
}