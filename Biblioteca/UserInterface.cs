using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca
{
    internal class UserInterface
    {
        private readonly BibliotecaContext dbContext;
        public Biblioteca biblioteca;

        public UserInterface(BibliotecaContext dbContext)
        {
            this.dbContext = dbContext;
            this.biblioteca = new Biblioteca(dbContext);

        }

        public enum Opcoes
        {
            CadastrarUsuario = 1,
            CadastrarLivro = 2,
            EmprestarLivro = 3,
            DevolverLivro = 4,
            ListarUsuarios = 5,
            ListarLivros = 6,
            Sair = 0,
        }

        public void ExibirMenu()
        {
            int escolha;

            do
            {
                Console.WriteLine($"Seja bem vindo à {biblioteca.Nome}");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Cadastrar usuário");
                Console.WriteLine("2 - Cadastrar livro");
                Console.WriteLine("3 - Emprestar livro");
                Console.WriteLine("4 - Devolver livro");
                Console.WriteLine("5 - Listar usuários");
                Console.WriteLine("6 - Listar livros");
                Console.WriteLine("0 - Sair");

                escolha = LerDados();

                if (!Enum.IsDefined(typeof(Opcoes), escolha))
                {
                    Console.WriteLine("Escolha uma opção válida.");
                }

                switch ((Opcoes)escolha)
                {
                    case Opcoes.CadastrarUsuario:
                        Console.WriteLine("Digite o nome do usuário");
                        string nomeUsuario = Console.ReadLine();
                        Usuario user = new Usuario(nomeUsuario);
                        dbContext.Usuarios.Add(user);
                        dbContext.SaveChanges();
                        Console.ReadLine();
                        break;
                    case Opcoes.CadastrarLivro:
                        Console.WriteLine("Digite os dados do livro:");
                        Console.WriteLine("Autor:");
                        string autor = Console.ReadLine();
                        Console.WriteLine("Título:");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("Páginas:");
                        int paginas = int.Parse(Console.ReadLine());
                        Livro livro = new Livro(autor, titulo, paginas);
                        dbContext.Livros.Add(livro);
                        dbContext.SaveChanges();
                        Console.ReadLine();
                        break;
                    case Opcoes.EmprestarLivro:
                        // ... restante do código
                        break;
                    case Opcoes.DevolverLivro:
                        // ... restante do código
                        break;
                    case Opcoes.ListarUsuarios:
                        Console.WriteLine("Lista de Usuários:");
                        foreach (var usuario in dbContext.Usuarios.Include(u => u.LivrosEmprestados))
                        {
                            Console.WriteLine($"Nome do Usuário: {usuario.NomeUsuario}");
                            foreach (var item in usuario.LivrosEmprestados)
                            {
                                Console.WriteLine($"Livros emprestados: {item.Titulo}");
                            }
                        }
                        Console.ReadLine();
                        break;
                    case Opcoes.ListarLivros:
                        Console.WriteLine("Lista de livros:");
                        foreach (var item in dbContext.Livros)
                        {
                            Console.WriteLine($"Dados do livro: Título: {item.Titulo}, Autor: {item.Autor}, Páginas: {item.Paginas}");
                        }
                        Console.ReadLine();
                        break;
                    case Opcoes.Sair:
                        Console.WriteLine("Encerrando o programa.");
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
