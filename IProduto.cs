using System.Collections.Generic;

namespace Aulas_27_28_29_30
{
    public interface IProduto
    {   
        // CRUD
        //   C       R       U       D
        // Create - Read - Uptade - Delete
        // Criar - Ler - Atualizar - Deletar

        List<Produto> Ler();

        void Adicionar(Produto prod);

        void Deletar(string _termo);

        void Atualizar(Produto _produtoAlterado); 

    }
}