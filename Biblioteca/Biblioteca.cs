using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static Biblioteca.Emprestimos;

namespace Biblioteca
{
    internal class Biblioteca
    {
        private readonly BibliotecaContext dbContext;

        public string Nome = "Biblioteca de teste";

        public Biblioteca(BibliotecaContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AdicionarLivro(Livro livro)
        {
            dbContext.Livros.Add(livro);
            dbContext.SaveChanges();
            Console.WriteLine($"O livro '{livro.Titulo}' foi adicionado à biblioteca.");
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            dbContext.Usuarios.Add(usuario);
            dbContext.SaveChanges();
            Console.WriteLine($"O usuário '{usuario.NomeUsuario}' foi cadastrado com sucesso.");
        }

        public void EmprestarLivro(Usuario usuario, Livro livro)
        {
            if (!livro.Emprestado)
            {
                livro.Emprestado = true;
                var emprestimo = new Emprestimos
                {
                    Usuario = usuario,
                    Livro = livro,
                    DataEmprestimo = DateTime.Now,
                    Ativo = true
                };
                dbContext.Emprestimos.Add(emprestimo);
                dbContext.SaveChanges();
                Console.WriteLine($"O livro '{livro.Titulo}' foi emprestado para {usuario.NomeUsuario}.");
            }
            else
            {
                Console.WriteLine($"O livro {livro.Titulo} já está emprestado.");
            }
        }

        public void DevolverLivro(Usuario usuario, Livro livro)
        {
            var emprestimo = dbContext.Emprestimos
                .FirstOrDefault(e => e.UsuarioId == usuario.Id && e.LivroId == livro.Id && e.Ativo);

            if (emprestimo != null)
            {
                livro.Emprestado = false;
                emprestimo.Ativo = false;
                emprestimo.DataDevolucao = DateTime.Now;
                dbContext.SaveChanges();
                Console.WriteLine($"O livro '{livro.Titulo}' foi devolvido por {usuario.NomeUsuario}.");
            }
            else
            {
                Console.WriteLine($"O livro {livro.Titulo} não está emprestado para este usuário.");
            }
        }
    }
}
