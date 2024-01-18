using System.Collections;
using System.Diagnostics;
using ControleDeBiblioteca.Models;

internal class Program

{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Biblioteca biblioteca1 = new Biblioteca();

        bool exibirMenuPrincipal = true;

        while(exibirMenuPrincipal) {

                Console.Clear();
                Console.WriteLine(" 1 - Menu Biblioteca");
                Console.WriteLine(" 2 - Menu Usuário");
                Console.WriteLine(" 3 - Menu Funcionário");
                Console.WriteLine(" 4 - Encerrar programa");

            switch(Console.ReadLine()){

                case "1":
                    bool menuBiblioteca = true;
                    while(menuBiblioteca){
                    Console.Clear();
                    Console.WriteLine("1 - Adicionar livro");
                    Console.WriteLine("2 - Emprestar livro");
                    Console.WriteLine("3 - Listar livros");
                    Console.WriteLine("4 - Listar livros emprestados");
                    Console.WriteLine("5 - Procurar livros");
                    Console.WriteLine("6 - Remover livro");
                    Console.WriteLine("7 - Entregar livro");
                    Console.WriteLine("8 - Voltar ao Menu Principal");
                    
                    switch(Console.ReadLine()){

                        case "1": biblioteca1.AdicionarLivroNaBiblioteca();
                        break;
                        case "2": biblioteca1.EmprestarLivro();
                        break;
                        case "3": biblioteca1.ListarLivrosDaBiblioteca();
                        break;
                        case "4": biblioteca1.ListarLivroEmprestados();
                        break;
                        case "5": biblioteca1.ProcurarLivro();
                        break;
                        case "6": biblioteca1.RemoverLivro();
                        break;
                        case "7": biblioteca1.EntregarLivro();
                        break;
                        case "8": menuBiblioteca = false;
                        break;
                    }
                break;
                }
                    break;

                case "2": bool menuUsuario = true;
                while(menuUsuario){

                        Console.Clear();
                        Console.WriteLine("1 - Cadastrar Usuário");
                        Console.WriteLine("2 - Listar Usuário");
                        Console.WriteLine("3 - Remover Usuário");
                        Console.WriteLine("4 - Voltar ao menu principal");

                    switch(Console.ReadLine()){

                        case "1": biblioteca1.CadastrarUsuario();
                        break;
                        case "2": biblioteca1.ListarUsuarios();
                        break;
                        case "3": biblioteca1.RemoverUsuario();
                        break;
                        case "4": menuUsuario = false;
                        break;
                    }
                break;
                }
                break;

                case "3": bool menuFuncionario = true;
                    while(menuFuncionario){

                        Console.Clear();
                        Console.WriteLine("1 - Cadastrar Funcionário");
                        Console.WriteLine("2 - Listar Funcionário");
                        Console.WriteLine("3 - Remover Funcionário");
                        Console.WriteLine("4 - Voltar ao menu principal");

                        switch(Console.ReadLine()){

                            case "1": biblioteca1.CadastrarFuncionario();
                            break;
                            case "2": biblioteca1.ListarFuncionario();
                            break;
                            case "3": biblioteca1.RemoverFuncionario();
                            break;
                            case "4": menuFuncionario = false;
                            break;
                        }
                        break;
                    }

                break;
                
                case "4": exibirMenuPrincipal = false;
                break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;

                
            }

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadKey();

        }

          Console.WriteLine("O programa se encerrou");
    }
}