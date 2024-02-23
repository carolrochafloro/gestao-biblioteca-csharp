using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Usuario
    {
        public int Id {  get; set; }
        public string NomeUsuario { get; private set; }
        public List<Livro> LivrosEmprestados { get; set; }

        // Construtor obriga informar o nome do usuário no momento do cadastro.
        public Usuario(string nomeUsuario)
        {
            NomeUsuario = nomeUsuario;
            LivrosEmprestados = new List<Livro>();
        }

        // Método para adicionar livro emprestado
        public void AdicionarLivroEmprestado(Livro livro)
        {
            LivrosEmprestados.Add(livro);
        }

        // Método para remover livro emprestado
        public void RemoverLivroEmprestado(Livro livro)
        {
            LivrosEmprestados.Remove(livro);
        }

        // Método para obter a lista de livros emprestados
        public List<Livro> ObterLivrosEmprestados()
        {
            return LivrosEmprestados;
        }
    }
}