using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca;
internal class Biblioteca
{
    public string Nome = "Biblioteca de teste";
    public List<Livro> LivrosDisponiveis { get; set; }
    public List<Usuario> Usuarios { get; set; }

    // Construtor inicializando as listas de livros e usuários.
    public Biblioteca()
    {
        LivrosDisponiveis = new List<Livro>(); 
        Usuarios = new List<Usuario>();
    }

    // Adicionar novo livro
    public void AdicionarLivro(Livro livro)
    {
        LivrosDisponiveis.Add(livro); 
        Console.WriteLine($"O livro '{livro.Titulo}' foi adicionado à biblioteca.");

    }

    // Adicionar novo usuário
    public void AdicionarUsuario(Usuario usuario)
    {
        Usuarios.Add(usuario); 
        Console.WriteLine($"O usuário '{usuario.NomeUsuario}' foi cadastrado com sucesso.");

    }

    // Listar livros

    public List<Livro> ObterLivrosDisponiveis()
    {
        return LivrosDisponiveis;
    }

    // Listar usuários
    public List<Usuario> ObterUsuarios()
    {
        return Usuarios;
    }

    // Método para emprestar livro com verificação 
    public void EmprestarLivro(Usuario usuario, Livro livro)
    {
        if (!livro.Emprestado)
        {
            livro.Emprestado = true;
            usuario.LivrosEmprestados.Add(livro); 
            Console.WriteLine($"O livro '{livro.Titulo}' foi emprestado para {usuario.NomeUsuario}.");

        } else
        {
            Console.WriteLine($"O livro {livro.Titulo} já está emprestado.");
        }
        
    }

    // Devolver livro
    public void DevolverLivro(Usuario usuario, Livro livro)
    {
        if (livro.Emprestado)
        {
            livro.Emprestado = false;
            usuario.LivrosEmprestados.Remove(livro);
            Console.WriteLine($"O livro '{livro.Titulo}' foi devolvido por {usuario.NomeUsuario}.");

        }
        else
        {
            Console.WriteLine($"O livro {livro.Titulo} não está emprestado para este usuário.");
        }

    }

}
