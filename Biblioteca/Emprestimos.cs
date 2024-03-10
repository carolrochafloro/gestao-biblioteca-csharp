using Microsoft.EntityFrameworkCore;
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

    public string DevolverLivro(int idEmprestimo)
    {
        using (var context = new BibliotecaContext())
        {
            var emprestimo = context.Emprestimos.Find(idEmprestimo);

            emprestimo.Ativo = false;
            emprestimo.DataDevolucao = DateTime.Today;
            ;
            context.Emprestimos.Update(emprestimo);
            context.SaveChanges();

            return "Livro devolvido.";
        }

    }

    public List<dynamic> ListarEmprestimos(int? idUsuario = null)
    {
        using (var context = new BibliotecaContext())
        {
            var emprestimos = context.Emprestimos.AsEnumerable();
            var usuarios = context.Usuarios.AsEnumerable();
            var livros = context.Livros.AsEnumerable();

            var query = from emprestimo in emprestimos
                        join usuario in usuarios on emprestimo.UsuarioId equals usuario.Id
                        join livro in livros on emprestimo.LivroId equals livro.Id
                        select new
                        {
                            NomeUsuario = usuario.NomeUsuario,
                            UsuarioId = emprestimo.UsuarioId,
                            LivroTitulo = livro.Titulo,
                            IdEmprestimo = emprestimo.Id,
                            DataEmprestimo = emprestimo.DataEmprestimo,
                            DataDevolucao = emprestimo.DataDevolucao,
                            Ativo = emprestimo.Ativo
                        };

            if (idUsuario != null)
            {
                query = query.Where(e => e.UsuarioId == idUsuario);
            }

            return query.ToList<dynamic>();
        }
    }
}



