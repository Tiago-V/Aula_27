using System;
using System.IO;

namespace Aulas_27_28_29_30
{
    public class Teste
    {
        private const string Pasta = "C:/Users/User/Desktop/EAD SENAI/EAD DEV/Aula_27_28_29_30/Aulas_27_28_29_30/Database/";

            public Teste()
        {
            //Cria o arquivo caso não exista
            if(!Directory.Exists(Pasta))
            {
                Directory.CreateDirectory(Pasta);
            }

        }

    }
}
