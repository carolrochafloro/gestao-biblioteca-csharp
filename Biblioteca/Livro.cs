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

        public bool Emprestado = false;

        // Propriedade de navegação para os empréstimos associados a este livro
        public List<Emprestimos> Emprestimos { get; set; }

        // Construtor sem parâmetros necessário para o Entity Framework
        public Livro()
        {
        }

        // Construtor obriga a inserção de todos os atributos ao cadastrar um novo livro
        public Livro(string autor, string titulo, int paginas)
        {
            Autor = autor;
            Titulo = titulo;
            Paginas = paginas;
            Emprestimos = new List<Emprestimos>();
        }

        // Método para verificar se o livro está emprestado
        public bool EstaEmprestado()
        {
            return Emprestado;
        }
    }
}
