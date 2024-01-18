using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Globalization;
using System.Runtime.CompilerServices;


namespace ControleDeBiblioteca.Models
{
    public class Biblioteca
    {

        List<Livro> livrosDaBiblioteca = new List<Livro>();
        List<Emprestimo> livrosEmprestados = new List<Emprestimo>();
        List<Usuario> listaDeUsuarios = new List<Usuario>();
        List<Funcionario> listaFuncionarios = new List<Funcionario>();

        public void AdicionarLivroNaBiblioteca(){

            Console.WriteLine("Nome do livro:");
            string titulo = Console.ReadLine();
           
            if(!String.IsNullOrEmpty(titulo)){
                Console.WriteLine("Nome do autor:");
            
                string nomeDoAutor = Console.ReadLine();

                if(!String.IsNullOrEmpty(nomeDoAutor)){

                    Console.WriteLine("Ano da publicação");
                    //Tratamento de excessão

                    try {
                    int ano = Convert.ToInt32(Console.ReadLine());
                    
                    // Gera um código aleatório para o livro
                    Random rnd = new Random();
                    int codigo = rnd.Next(10001);

                    // Verifica se o código é único 
                    if(livrosDaBiblioteca.Any(livro => livro.CodigoDoLivro == codigo)){

                        Console.WriteLine("Livro já existe.");

                    // Recebe as informações do livro e adiciona na lista Livros da Biblioteca. 
                    } else {

                    Livro novoLivro = new Livro { Titulo = titulo, Autor = nomeDoAutor, AnoDePublicacao = ano, CodigoDoLivro = codigo};
                    livrosDaBiblioteca.Add(novoLivro);

                    Console.WriteLine($" O livro {titulo}, de código {codigo}, foi adicionado com sucesso!");

                    }

                    // Tratamento de excessão 
                    } catch (FormatException ex){

                        Console.WriteLine("Insira um formato de ano válido. Erro: " + ex.Message);
                    }
                    catch (OverflowException ex){

                        Console.WriteLine("Erro de overflow: " + ex.Message);
                    
                    }

                } else {
                    Console.WriteLine("Digite um nome válido");
                }

            } else {
                Console.WriteLine("Digite um título válido");
            }
                
        }
        //Lista os livros da Biblioteca
        public void ListarLivrosDaBiblioteca(){

                int contador = 0;

                    Console.WriteLine("Os livros cadastrados são:");
          
                    foreach(Livro livro in livrosDaBiblioteca){
           
                    Console.WriteLine($"{contador + 1} - Código do livro - {livro.CodigoDoLivro} - Título: {livro.Titulo}, do autor(a) {livro.Autor} e publicado em {livro.AnoDePublicacao}");
                    contador ++;
                    }

                    if (contador == 0){

                        Console.WriteLine("Não há livros cadastrados. ");
                    }
                
                
                

        }
        public void ProcurarLivro(){
             
            Console.WriteLine("Qual livro deseja consultar?");
             //Recebe o título do livro 
            string livroParaConsultar = Console.ReadLine();
            // Verifica a entrada do usuário
            if(!String.IsNullOrEmpty(livroParaConsultar)){

                 //Verifica se o título do livro existe na lista Livros da Biblioteca
             bool livroConsulta = livrosDaBiblioteca.Any(Livro => Livro.Titulo.Contains(livroParaConsultar));

             if(livroConsulta){

                Console.WriteLine($"O livro: {livroParaConsultar}, está disponível na Biblioteca");

             } else {
                Console.WriteLine($"O livro solicitado não está diponível");
             }
            } else {
                Console.WriteLine("Digite um título válido");
            }
           
        }
        public void RemoverLivro(){

            //Recebe o código do livro para remover e trata exceções. 
            try {
                Console.WriteLine("Digite o código do livro que deseja remover?");

                int codigoParaRemover = Convert.ToInt32(Console.ReadLine());

                //Verifica se o código do livro existe na lista de livros da biblioteca
                bool livroRemover = livrosDaBiblioteca.Any(Livro => Livro.CodigoDoLivro==codigoParaRemover);

                if(livroRemover){

                livrosDaBiblioteca.RemoveAll(Livro => Livro.CodigoDoLivro == codigoParaRemover);
                Console.WriteLine("Livro removido");

                } else {
                Console.WriteLine("Livro não localizado");
                }

                } catch (FormatException){

                Console.WriteLine("Erro: O código do livro deve ser um número válido.");
                
                }
                catch (OverflowException){

                    Console.WriteLine("Erro: O código do livro fornecido é muito grande para ser convertido para um número inteiro.");
                    
                }
                catch (Exception ex){

                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                  
                }
        }
        //Cadastrar um novo usuário da biblioteca
        public void CadastrarUsuario(){
            //Recebe o input 
            Console.WriteLine("Nome completo do usuário");
            string nomeUsuario = Console.ReadLine();

            //Verifica a entrada da string
            if(!String.IsNullOrEmpty(nomeUsuario)){

            Console.WriteLine("Telefone (ex DDD - 9 9999-9999)");
            string telefoneUsuario = Console.ReadLine();

            //Valida a entrada de telefone do usuário
            var validarDigito = ValidarSeETelefone(telefoneUsuario);

            Console.WriteLine("Email");
            string emailUsario = Console.ReadLine();

            //Valida a entrada do e-mail do usuário
            var verificarEmailUsuario = ValidarEmail(emailUsario);
            if(verificarEmailUsuario){
                    //Gera um número aleatório para o usuários
                    Random rnd = new Random();
                    int codigoDoUsuario = rnd.Next(10001);

                    Usuario novoUsuario = new Usuario { NomeCompleto = nomeUsuario, Telefone = telefoneUsuario, 
                    Email = emailUsario, NumeroDeIndenticacao = codigoDoUsuario };
                    //Adiciona o novo usuário na lista de usuários
                    listaDeUsuarios.Add(novoUsuario);

                    Console.WriteLine($"O usuário {nomeUsuario}, de código {codigoDoUsuario} foi cadastrado com sucesso!");
            } else {
                Console.WriteLine("Digite um email válido");
            }
            } else {

                Console.WriteLine("Digite um nome válido");
            }
       
        }
        //Lista os usuários cadastrados
        public void ListarUsuarios(){
            //Apresenta a quantidade de funcionários
            int contador = 0;

                Console.WriteLine("Usuários cadastrados na plataforma:");
                foreach(Usuario nomeUsuario in listaDeUsuarios){

                Console.WriteLine($" {contador + 1} Nome do usuário: {nomeUsuario.NomeCompleto}"); 
                Console.WriteLine($"Código do Usuário: {nomeUsuario.NumeroDeIndenticacao}.");
                Console.WriteLine($"Telefone: {nomeUsuario.Telefone} ");
                Console.WriteLine($"Email: {nomeUsuario.Email}");
                contador ++;
                }
             if(contador == 0){

                Console.WriteLine("Não há usuários cadastrados");
            } 

            
            }
        // Verifica se já existe um código de usuário cadastrado, para não ter dois códigos de usuários iguais. 
        public int VerificarCodigoUsuario( int codigoUsuarioNovo){
            int verificar = 0;

            foreach(Usuario codigoUsuario in listaDeUsuarios){
                if (codigoUsuario.NumeroDeIndenticacao == codigoUsuarioNovo){

                    verificar = codigoUsuario.NumeroDeIndenticacao;

                }

            }
            return verificar;
        }
        
        public void EmprestarLivro(){
           ///Tratamendo de exceção 
           try {
            ///Recebe o codigo do livro
            Console.WriteLine("Digite o código do livro que vai ser emprestado");
            int codigoDoLivroEmprestado = Convert.ToInt32(Console.ReadLine());
            /// Verifica se o código existe
            bool livroExiste = livrosDaBiblioteca.Any(Livro => Livro.CodigoDoLivro.Equals(codigoDoLivroEmprestado));
            
            if(livroExiste){
            /// Verifica se o livro está emprestado
            int verificarCodigoLivro = VerificarLivroEmprestado(codigoDoLivroEmprestado);
            /// Se o livro estiver disponível, é solicitado o código do usuário
            if (verificarCodigoLivro != codigoDoLivroEmprestado ){

                Console.WriteLine("Código do usuário");
                int codigoDoUsarioDoLivro = Convert.ToInt32(Console.ReadLine());
                /// Verifica se usuário está cadastrado
                int verificarUsuarioNaLista = VerificarCodigoUsuario(codigoDoUsarioDoLivro);
           
                    if (verificarUsuarioNaLista == codigoDoUsarioDoLivro) {
                        /// Se o usuário estiver cadastrado, solicita o código do funcionário responsável pelo empréstimo. 
                        Console.WriteLine("Código do Funcionário");
                        int codigoDoFuncionarioResponsavel = Convert.ToInt32(Console.ReadLine());
                        //Verifica se funcionário está cadastrado
                        int verificarFuncionarioNaLista = VerificarFuncionario(codigoDoFuncionarioResponsavel);
                            
                            if(verificarFuncionarioNaLista==codigoDoFuncionarioResponsavel){
                                //Adiciona as informações na classe Emprestimo
                                Emprestimo novoEmprestimo = new Emprestimo{ CodigoDoLivro = codigoDoLivroEmprestado,
                                CodigoDoUsuario = codigoDoUsarioDoLivro, CodigoDoBibliotecario = codigoDoFuncionarioResponsavel, DataDoEmprestimo = DateTime.Now };
                                //Adiciona as informações da classe na Lista de livros Emprestados
                                livrosEmprestados.Add(novoEmprestimo);

                                Console.WriteLine("O livro foi emprestado com sucesso!");

                                } else {
                                        Console.WriteLine("Funcionário não cadastrado");
                                    }

                         } else {
                                Console.WriteLine("Usuário Não Cadastrado");
                            }

            } else {
                Console.WriteLine("O livro não está disponível");
            }
            } else {
                Console.WriteLine("O código solicitado não existe na plataforma.");
            }
            
           } catch (FormatException ex)  {

                Console.WriteLine("Insira um formato válido de código. Erro" + ex );

            } catch (OverflowException ex ){

                Console.WriteLine("Erro de overflow: " + ex.Message);
            }

        }
        //Verifica se o livro está com o status de emprestado
        public int VerificarLivroEmprestado(int codigoDoLivroEmprestadoAoUsuario){

            int verificarCodigoEmprestimo = 0 ;

            foreach(Emprestimo livro in livrosEmprestados ){
                if(livro.CodigoDoLivro == codigoDoLivroEmprestadoAoUsuario){

                    verificarCodigoEmprestimo = livro.CodigoDoLivro;
                } 
            }
            return verificarCodigoEmprestimo;
        }
        //Recebe o código do livro e retorna o Título do livro 
        public string ProcurarLivroPeloCodigo(int codigo){

            string resultado = " ";

             foreach(Livro livro in livrosDaBiblioteca){

                    if(livro.CodigoDoLivro == codigo)
                    {
                        resultado = livro.Titulo;
                    }
             }
             
             return resultado;
        }
        // Lista os livros que estão emprestados
         public void ListarLivroEmprestados(){

            int contador = 0;
           
                Console.WriteLine("Os livros emprestados são:");

                foreach(Emprestimo livro in livrosEmprestados){
                //Procura o livro pelo código e retorna o tírulo do livro que será apresentado no Console.WriteLine
                string nomeDoLivro = ProcurarLivroPeloCodigo(livro.CodigoDoLivro);
           
                Console.WriteLine($"{contador} - Nome do livro: {nomeDoLivro} - Código {livro.CodigoDoLivro}, emprestado para {livro.CodigoDoUsuario} ");
                contador ++;
                }

                if(contador == 0 ){
                Console.WriteLine("Não há livros cadastrados");
                }
        }
        //Cadastra um novo funcionário da biblioteca
        public void CadastrarFuncionario(){

            Console.WriteLine("Nome completo do funcionário");
            string nomeFuncionario = Console.ReadLine();
            //Verifica o input
            if(!String.IsNullOrWhiteSpace(nomeFuncionario)){

            Console.WriteLine("Telefone (ex DDD - 9 9999-9999)");
            string telefoneFuncionario = Console.ReadLine();
            // Valida o número de telefone se é digito e se tem 11 números
            var validarDigito = ValidarSeETelefone(telefoneFuncionario);

            if (validarDigito) {

                Console.WriteLine("Email");
                string emailFuncionario = Console.ReadLine();
                //Valida o email
                var verificarEmail = ValidarEmail(emailFuncionario);
                if (verificarEmail){
                        //Gera um código aleatório para o funcionário
                        Random rnd = new Random();
                        int codigoDoFuncionario = rnd.Next(20001);

                        //Recebe as informações do funcionário
                        Funcionario cadastrarFuncionario = new Funcionario 
                            {NomeCompleto= nomeFuncionario, 
                            Telefone = telefoneFuncionario, 
                            Email = emailFuncionario, 
                            NumeroDeIndenticacao = codigoDoFuncionario};
                        //Adiciona o funcionário na lista de funcionário
                        listaFuncionarios.Add(cadastrarFuncionario);

                        Console.WriteLine($" O funcionário {nomeFuncionario}, de código {codigoDoFuncionario} foi cadastrado com sucesso!");

                } else {
                    Console.WriteLine("Email inválido");
                }

            }else {
                Console.WriteLine("Digite um telefone válido");
            }

            } else {

                Console.WriteLine("Digite um nome válido");
            }
        }
        //Verifica se o código do funcionário existe na lista de funcionário
        public int VerificarFuncionario ( int codigoFuncionario){
            int verificarCodigoFuncionario = 0 ;

                foreach(Funcionario codFuncionario in listaFuncionarios){

                    if(codFuncionario.NumeroDeIndenticacao == codigoFuncionario){

                        verificarCodigoFuncionario = codigoFuncionario;
                    }
                }

            return verificarCodigoFuncionario;
        }
        //Valida o email
        public bool ValidarEmail(string email){

            try
            {
                var enderecoEmail = new System.Net.Mail.MailAddress(email);
                return enderecoEmail.Address == email;

            }
            catch
            {
                return false;
            }
            
        }
        //Valida se a entrada de telefone são dígitos válidos
        public bool EDigito(string inputTelefone){

            foreach(char c in inputTelefone){
                if (c < '0' || c > '9' )
                {
                    return false;
                }
            }
            return true;
        }
        //Valida se o telefone tem 11 digitos
        public bool ValidarSeETelefone(string telefone){

            return telefone.Length == 11 && EDigito(telefone);
        }
        //Remove o usuário da lista de usuário cadastrado
        public void RemoverUsuario(){
            //Tratamendo de exceção
            try{

            Console.WriteLine("Digite o código do usuário para remover");
            int usuarioRemover = Convert.ToInt32(Console.ReadLine());
                //Verifica se o funcionário está com algum livro emprestado
                bool codigoUsuario = livrosEmprestados.Any(Emprestimo => Emprestimo.CodigoDoUsuario == usuarioRemover);
                // Não pode seguir com a remoção do usuário se ele estiver com um livro
                if(codigoUsuario){

                    Console.WriteLine("Usuário não pode ser removido, pois está com um livro");

                } else {
                    //Verifica se o susário existe
                    bool verificarUsuarioExiste = listaDeUsuarios.Any(Usuario => Usuario.NumeroDeIndenticacao == usuarioRemover);
                    //Remove o funcionário
                    if(verificarUsuarioExiste){

                        listaDeUsuarios.RemoveAll(Usuario => Usuario.NumeroDeIndenticacao == usuarioRemover);
                        Console.WriteLine("Usuário foi removido");

                    } else {

                        Console.WriteLine("Usuário não está cadastrado");
                    }
                }

            } catch (FormatException ex)  {

                Console.WriteLine("Insira um formato válido de código. Erro" + ex );

            } catch (OverflowException ex ){

                Console.WriteLine("Erro de overflow: " + ex.Message);
            }
        }
        // Lista os funcionários cadastrados
        public void ListarFuncionario(){
            //Apresenta a quantidade de funcionários cadastrados
            int contador = 0;

                Console.WriteLine("Funcionários cadastrados na plataforma:");
                // Percorre a lista de funcionário
                foreach(Funcionario funcionario in listaFuncionarios){

                Console.WriteLine($" {contador + 1} Nome do usuário: {funcionario.NomeCompleto}"); 
                Console.WriteLine($"Código do Usuário: {funcionario.NumeroDeIndenticacao}.");
                Console.WriteLine($"Telefone: {funcionario.Telefone} ");
                Console.WriteLine($"Email: {funcionario.Email}");
                contador ++;

                }
                if(contador == 0) {

                Console.WriteLine("Não há funcionários cadastrados");
                }
        }
        public void RemoverFuncionario(){
            //tratamendo de exceção
            try{
                Console.WriteLine("Digite o código do funcionário que deseja remover");
                int funcionarioRemover = Convert.ToInt32(Console.ReadLine());
                // Verifica se o funcionário existe
                bool verificarFuncionarioExiste = listaFuncionarios.Any(Funcionario => Funcionario.NumeroDeIndenticacao == funcionarioRemover);

                if(verificarFuncionarioExiste){
                    //Remove o funcionário
                    listaFuncionarios.RemoveAll(Funcionario => Funcionario.NumeroDeIndenticacao == funcionarioRemover);
                    Console.WriteLine("Funcionário Removido");

                } else {
                    Console.WriteLine("O funcionário não está cadastrado");
                }
            } catch (FormatException ex){

                Console.WriteLine("Insira um formato válido de código. Erro" + ex );

            } catch (OverflowException ex){

                Console.WriteLine("Erro de overflow: " + ex.Message);

            }

        }
        //Devolve para biblioteca o livro que foi emprestado ao usuário
        public void EntregarLivro(){
            //Tratamendo de exceção
            try{
                Console.WriteLine("Escreva o código do livro que deseja devolver");
                int codigoParaDevolver = Convert.ToInt32(Console.ReadLine());
                //Verifica se o livro foi registrado como emprestado
                bool verificarDevolucao = livrosEmprestados.Any(Emprestimo => Emprestimo.CodigoDoLivro == codigoParaDevolver);

                if(verificarDevolucao){
                    //Se consta como emprestado, então é removido da lista de livros emprestados
                    livrosEmprestados.RemoveAll(Emprestimo => Emprestimo.CodigoDoLivro == codigoParaDevolver);
                    Console.WriteLine($"O livro {codigoParaDevolver}, foi devolvido");

                } else {
                    Console.WriteLine("Livro não foi emprestado");
                }

            }  catch (FormatException ex){

                Console.WriteLine("Insira um formato válido de código. Erro" + ex );

            } catch (OverflowException ex){

                Console.WriteLine("Erro de overflow: " + ex.Message);

            }

        }

    }
}