using System;
using System.IO;

namespace EditorDeTexto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("---- Menu ----");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("9 - Sair\n");
            Console.WriteLine("Escolha uma opção: ");
            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 9: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();     //lê o texto até o final
                Console.WriteLine(text);        //exibe o arquivo na tela
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("-----------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();     //concatena o texto do usuario na variavel text
                text += Environment.NewLine;    //concatena os espaços do texto do usuario
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);     //finaliza o texto quando o usuario pressionar a tecla Esc

            Salvar(text);        //Exibe o texto para o usuario
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para salvar o caminho?");
            var path = Console.ReadLine();      //lê o caminho para a pasta onde sera salvo o arquivo

            using (var file = new StreamWriter(path))    //o using abre e fecha o objeto automaticamente 
            {
                file.Write(text);       //escreve um arquivo
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}