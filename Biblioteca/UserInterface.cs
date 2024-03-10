using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca
{
    internal class UserInterface
    {
        private readonly BibliotecaContext dbContext;

        public UserInterface(BibliotecaContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /* Declaração de variáveis e instâncias */

        Livro livro = new Livro();
        Usuario usuario = new Usuario();
        Emprestimos emprestimo = new Emprestimos();

        public enum PrimeiroMenu
        {
            Usuarios = 1,
            Livros = 2,
            Emprestimos = 3,
            Sair = 0
        }

        /* Exibição do menu ------------------------------------------------------------- */
        public void ExibirMenu()
        {
            int escolha;
            int segundaEscolha;

            /* Menu principal --------------------------------------------------------------- */
            do
            {
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("\t[1] Usuários");
                Console.WriteLine("\t[2] Livros");
                Console.WriteLine("\t[3] Empréstimos");
                Console.WriteLine("\t[0] Sair");

                escolha = int.Parse(Console.ReadLine());

                if (!Enum.IsDefined(typeof(PrimeiroMenu), escolha))
                {
                    Console.WriteLine("Escolha uma opção válida.");
                }

                switch ((PrimeiroMenu)escolha)
                {

                    /* Usuários ---------------------------------------------------------------- */
                    case PrimeiroMenu.Usuarios:

                        do
                        {
                            Console.WriteLine("\t1 - Cadastrar usuário");
                            Console.WriteLine("\t2 - Listar usuários");
                            Console.WriteLine("\t3 - Listar emprestimos por usuário");
                            segundaEscolha = int.Parse(Console.ReadLine());

                            switch (segundaEscolha)
                            {
                                case 1:
                                    Console.WriteLine("Digite o nome do usuário:");
                                    string nomeUsuario = Console.ReadLine();
                                    string novoUsuario = usuario.CadastrarUsuario(nomeUsuario);

                                    Console.WriteLine(novoUsuario);
                                    Console.ReadLine();
                                    break;

                                case 2:
                                    var listarResultadoUsuario = usuario.ListarUsuarios();

                                    foreach (var item in listarResultadoUsuario)
                                    {
                                        Console.WriteLine($"Id: {item.Id} \n Nome: {item.NomeUsuario}");
                                    }

                                    Console.ReadLine();
                                    break;

                                case 3:
                                    Console.WriteLine("Digite o id do usuário");
                                    int idUsuario = int.Parse(Console.ReadLine());

                                    var emprestimosPorUsuario = emprestimo.ListarEmprestimos(idUsuario);

                                    foreach (var item in emprestimosPorUsuario)
                                    {
                                        Console.WriteLine($"Id: {item.IdEmprestimo} - Livro: {item.LivroTitulo}");
                                        Console.WriteLine($"Empréstimo: {item.DataEmprestimo} - Devolução: {item.DataDevolucao}");
                                    }
                                    Console.ReadLine();
                                    break;

                            }

                            break;


                        } while (segundaEscolha != 0);

                        break;

                    /* Livros ----------------------------------------------------------------------------------- */

                    case PrimeiroMenu.Livros:
                        do
                        {
                            Console.WriteLine("\t1 - Cadastrar livro");
                            Console.WriteLine("\t2 - Listar livros");

                            segundaEscolha = int.Parse(Console.ReadLine());

                            switch (segundaEscolha)
                            {
                                case 1:

                                    Console.WriteLine("Digite o título do livro:");
                                    string nomeLivro = Console.ReadLine();

                                    Console.WriteLine("Digite o autor do livro:");
                                    string autorLivro = Console.ReadLine();

                                    Console.WriteLine("Digite o número de páginas");
                                    int paginas = int.Parse(Console.ReadLine());

                                    string novoLivro = livro.CadastrarLivro(nomeLivro, autorLivro, paginas);

                                    Console.WriteLine(novoLivro);


                                    Console.ReadLine();
                                    break;

                                case 2:

                                    var resultadoLivro = livro.ListarLivros();
                                    foreach (var item in resultadoLivro)
                                    {
                                        Console.WriteLine($"Dados do livro: Id: {item.Id}, Título: {item.Titulo}, Autor: {item.Autor}\nEmprestado: {item.Emprestado}");
                                    }

                                    Console.ReadLine();
                                    break;

                            }

                            break;

                        } while (segundaEscolha != 0);

                        break;

                    /* Empréstimos --------------------------------------------------------------------------------------- */

                    case PrimeiroMenu.Emprestimos:
                        do
                        {
                            Console.WriteLine("\t1 - Emprestar livro");
                            Console.WriteLine("\t2 - Devolver livro");
                            Console.WriteLine("\t3 - Listar todos os empréstimos");

                            segundaEscolha = int.Parse(Console.ReadLine());

                            switch (segundaEscolha)
                            {
                                case 1:

                                    Console.WriteLine("Selecione o id do livro:");
                                    var resultadoLivros = livro.ListarLivros();
                                    foreach (var item in resultadoLivros)
                                    {
                                        Console.WriteLine($"Dados do livro: Id: {item.Id}, Título: {item.ToString}, Autor: {item.Autor}. \nEmprestado: {item.Emprestado}");
                                    }
                                    int idLivro = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Selecione o id do usuário:");
                                    var resultadoUsuarios = usuario.ListarUsuarios();
                                    foreach (var item in resultadoUsuarios)
                                    {
                                        Console.WriteLine($"Id: {item.Id} \n Nome: {item.NomeUsuario}");
                                    }
                                    int idUsuario = int.Parse(Console.ReadLine());

                                    var emprestimoFeito = emprestimo.NovoEmprestimo(idUsuario, idLivro);
                                    Console.WriteLine(emprestimoFeito);

                                    Console.ReadLine();
                                    break;

                                case 2:

                                    Console.WriteLine("Selecione o id do usuário");
                                    var resultadoUsuario = usuario.ListarUsuarios();
                                    foreach (var item in resultadoUsuario)
                                    {
                                        Console.WriteLine($"Id: {item.Id} \n Nome: {item.NomeUsuario}");
                                    }
                                    idUsuario = int.Parse(Console.ReadLine());

                                    var emprestimosUsuario = emprestimo.ListarEmprestimos(idUsuario);
                                    Console.WriteLine("Selecione o id do registro de empréstimo:");
                                    foreach (var item in emprestimosUsuario)
                                    {
                                        Console.WriteLine($"Id: {item.Id} \n Data: {item.DataEmprestimo}");
                                    }
                                    int idEmprestimo = int.Parse(Console.ReadLine());

                                    var livroDevolvido = emprestimo.DevolverLivro(idEmprestimo);

                                    Console.WriteLine(livroDevolvido);

                                    Console.ReadLine();
                                    break;

                                case 3:

                                    var resultadoemprestimo = emprestimo.ListarEmprestimos();

                                    foreach (var item in resultadoemprestimo)
                                    {
                                        Console.WriteLine($"{item.IdEmprestimo}, {item.NomeUsuario}, {item.LivroTitulo}");
                                    }

                                    Console.ReadLine();
                                    break;
                            }


                        } while (segundaEscolha != 0);


                        Console.ReadLine();
                        break;
                }

            } while ((PrimeiroMenu)escolha != PrimeiroMenu.Sair);


        }
    }
}


