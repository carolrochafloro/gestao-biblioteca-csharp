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

        Livro livro = new Livro();
        Usuario usuario = new Usuario();
        Emprestimos emprestimo = new Emprestimos();

        public enum Opcoes
        {
            CadastrarUsuario = 1,
            CadastrarLivro = 2,
            EmprestarLivro = 3,
            DevolverLivro = 4,
            ListarUsuarios = 5,
            ListarLivros = 6,
            ListarEmprestimos = 7,
            Sair = 0,
        }

        public void ExibirMenu()
        {
            int escolha;

            do
            {
                Console.WriteLine($"Seja bem vindo à Biblioteca!\n");
                Console.WriteLine("Escolha uma opção:\n");
                Console.WriteLine("\t1 - Cadastrar usuário");
                Console.WriteLine("\t2 - Cadastrar livro");
                Console.WriteLine("\t3 - Emprestar livro");
                Console.WriteLine("\t4 - Devolver livro");
                Console.WriteLine("\t5 - Listar usuários");
                Console.WriteLine("\t6 - Listar livros");
                Console.WriteLine("\t7 - Listar Empréstimos");
                Console.WriteLine("\t0 - Sair");

                escolha = LerDados();

                if (!Enum.IsDefined(typeof(Opcoes), escolha))
                {
                    Console.WriteLine("Escolha uma opção válida.");
                }

                switch ((Opcoes)escolha)
                {
                    case Opcoes.CadastrarUsuario:

                        Console.WriteLine("Digite o nome do usuário:");
                        string nomeUsuario = Console.ReadLine();
                        string novoUsuario = usuario.CadastrarUsuario(nomeUsuario);

                        Console.WriteLine(novoUsuario);
                        Console.ReadLine();
                        break;

                    case Opcoes.CadastrarLivro:
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
                    case Opcoes.EmprestarLivro:

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
                    case Opcoes.DevolverLivro:

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

                    case Opcoes.ListarUsuarios:

                        resultadoUsuario = usuario.ListarUsuarios();

                        foreach (var item in resultadoUsuario)
                        {
                            Console.WriteLine($"Id: {item.Id} \n Nome: {item.NomeUsuario}");
                        }

                        Console.ReadLine();
                        break;

                    case Opcoes.ListarLivros:

                        var resultadoLivro = livro.ListarLivros();
                        foreach (var item in resultadoLivro)
                        {
                            Console.WriteLine($"Dados do livro: Título: {item.Titulo}, Autor: {item.Autor}, Páginas: {item.Paginas}. \nEmprestado: {item.Emprestado}");
                        }

                        Console.ReadLine();
                        break;
                    case Opcoes.ListarEmprestimos:
                        var resultadoemprestimo = emprestimo.ListarEmprestimos();

                        foreach (var item in resultadoemprestimo)
                        {
                            Console.WriteLine($"{item.IdEmprestimo}, {item.NomeUsuario}, {item.LivroTitulo}");
                        }

                        Console.ReadLine();
                        break;
                    case Opcoes.Sair:

                        break;
                }

            } while ((Opcoes)escolha != Opcoes.Sair);
        }

        private int LerDados()
        {
            int resultado;
            while (!int.TryParse(Console.ReadLine(), out resultado))
            {
                Console.WriteLine("Entrada inválida. Por favor, escolha uma das opções acima.");
            }

            return resultado;
        }

       

        

    }
}
