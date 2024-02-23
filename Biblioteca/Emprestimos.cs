using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca;
internal class Emprestimos
{

    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int LivroId { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime? DataDevolucao { get; set; }

    public Usuario Usuario { get; set; }
    public Livro Livro { get; set; }

    public Emprestimos()
    {
    }


    public string NovoEmprestimo(int idUsuario, int idLivro)
    {
        using (var context = new BibliotecaContext())
        {
            var livro = context.Livros.Find(idLivro);

            if (livro == null)
            {
                return "Livro não encontrado.";
            }

            if (livro.Emprestado == true)
            {
                return "Livro já emprestado.";
            }

            var emprestimo = new Emprestimos
            {
                UsuarioId = idUsuario,
                LivroId = idLivro,
                DataEmprestimo = DateTime.Today,
                Ativo = true,
            };

            livro.Emprestado = true;
            context.Livros.Update(livro);
            context.Emprestimos.Add(emprestimo);
            context.SaveChanges();
            return "Empréstimo realizado com sucesso.";

        }
    }

    public List<Emprestimos> ListarEmprestimos()
    {
        using (var context = new BibliotecaContext())
        {
            var item = context.Emprestimos.ToList();
            return item;
        }
    }
}

