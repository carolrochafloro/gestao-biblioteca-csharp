using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca;
internal class UserInterface
{

    public Biblioteca biblioteca = new Biblioteca();

    public void ExibirMenu()
    {
        int escolha = 1;
        do
        {
            Console.WriteLine($"Seja bem vindo à {biblioteca.Nome}");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("\n 1 - Cadastrar usuário");
            Console.WriteLine("\n 2 - Cadastrar livro");
            Console.WriteLine("\n 3 - Emprestar livro");
            Console.WriteLine("\n 4 - Devolver livro");
            Console.WriteLine("\n 5 - Listar usuários");
            Console.WriteLine("\n 6 - Listar livros");
            Console.WriteLine("\n 0 - Sair");

            escolha = LerDados();

            if (escolha != 1 && escolha != 2 && escolha != 3 && escolha != 4 && escolha != 5 && escolha != 6 && escolha != 0)
            {
                Console.WriteLine("Escolha uma opção válida.");
            }

            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Digite o nome do usuário");
                    string nomeUsuario = Console.ReadLine();
                    Usuario user = new Usuario(nomeUsuario);
                    biblioteca.AdicionarUsuario(user);
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Digite os dados do livro:");
                    Console.WriteLine("Autor:");
                    string autor = Console.ReadLine();
                    Console.WriteLine("Título:");
                    string titulo = Console.ReadLine();
                    Console.WriteLine("Páginas:");
                    int paginas = int.Parse(Console.ReadLine());
                    Livro livro = new Livro(autor, titulo, paginas);
                    biblioteca.AdicionarLivro(livro);
                    Console.ReadLine();
                    break;
                case 3:

                    Console.WriteLine("Lista de Livros Disponíveis:");
                    ListarLivros(biblioteca.ObterLivrosDisponiveis());

                    Console.WriteLine("Escolha o número do livro que deseja emprestar:");
                    int indiceLivro = LerDados();

                    Console.WriteLine("Lista de Usuários:");
                    ListarUsuarios(biblioteca.ObterUsuarios());

                    Console.WriteLine("Escolha o número do usuário para quem deseja emprestar o livro:");
                    int indiceUsuario = LerDados();

                    Livro livroEscolhido = biblioteca.ObterLivrosDisponiveis()[indiceLivro];
                    Usuario usuarioEscolhido = biblioteca.ObterUsuarios()[indiceUsuario];

                    biblioteca.EmprestarLivro(usuarioEscolhido, livroEscolhido);
                    Console.ReadLine();
                    break;

                case 4:
                    Console.WriteLine("Lista de Livros Disponíveis:");
                    ListarLivros(biblioteca.ObterLivrosDisponiveis());

                    Console.WriteLine("Escolha o número do livro que deseja emprestar:");
                    indiceLivro = LerDados();

                    Console.WriteLine("Lista de Usuários:");
                    ListarUsuarios(biblioteca.ObterUsuarios());

                    Console.WriteLine("Escolha o número do usuário para quem deseja emprestar o livro:");
                    indiceUsuario = LerDados();

                    livroEscolhido = biblioteca.ObterLivrosDisponiveis()[indiceLivro];
                    usuarioEscolhido = biblioteca.ObterUsuarios()[indiceUsuario];

                    biblioteca.DevolverLivro(usuarioEscolhido, livroEscolhido);
                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Lista de Usuários:");
                    foreach (var usuario in biblioteca.Usuarios)
                    {
                        Console.WriteLine($"Nome do Usuário: {usuario.NomeUsuario}");
                        foreach (var item in usuario.LivrosEmprestados)
                        {
                            Console.WriteLine($"Livros emprestados: {item.Titulo}");
                        }

                    }
                    Console.ReadLine();
                    break;
                case 6:
                    Console.WriteLine("Lista de livros:");
                    foreach (var livros in biblioteca.LivrosDisponiveis)
                    {
                        Console.WriteLine($"Dados do livro: Título: \n{livros.Titulo}.\n Autor: {livros.Autor}.\n Páginas: {livros.Paginas}");
                    }
                    Console.ReadLine();
                    break;
                case 0:
                    Console.WriteLine("Encerrando o programa.");
                    break;
            }
        } while (escolha != 0);

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

    private void ListarLivros(List<Livro> livros)
    {
        for (int i = 0; i < livros.Count; i++)
        {
            Console.WriteLine($"{i} - Título: {livros[i].Titulo}, Autor: {livros[i].Autor}");
        }
    }

    private void ListarUsuarios(List<Usuario> usuarios)
    {
        for (int i = 0; i < usuarios.Count; i++)
        {
            Console.WriteLine($"{i} - Nome do Usuário: {usuarios[i].NomeUsuario}");
        }
    }
}

