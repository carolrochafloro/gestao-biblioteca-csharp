using System;
using System.Collections.Generic;
using static Biblioteca.Emprestimos;

namespace Biblioteca
{
    internal class Livro
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public int Paginas { get; set; }
        public bool? Emprestado {  get; set; }



        public Livro()
        {
            Emprestado = false;
        }

        public Livro(string autor, string titulo, int paginas)
        {

            Autor = autor;
            Titulo = titulo;
            Paginas = paginas;
            Emprestado = false;

        }

        public List<Livro> ListarLivros()
        {
            using (var context = new BibliotecaContext())
            {

                var item = context.Livros.ToList();
                return item;

            }
        }

        public string CadastrarLivro(string autor, string titulo, int paginas)
        {
            using (var context = new BibliotecaContext())
            {

                Livro novoLivro = new Livro(autor, titulo, paginas);
                context.Livros.Add(novoLivro);
                context.SaveChanges();

                return "Livro cadastrado com sucesso.";

            }
        }

    }
}
