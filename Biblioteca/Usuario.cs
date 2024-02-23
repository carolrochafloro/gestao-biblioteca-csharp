using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Usuario
    {
        public int Id {  get; set; }
        public string NomeUsuario { get; private set; }

        public Usuario()
        {
        }

        public Usuario(string nome)
        {
            NomeUsuario = nome;
        }

        public List<Usuario> ListarUsuarios()
        {
            using (var context = new BibliotecaContext())
            {
                var item = context.Usuarios.ToList();
                return item;
            }

        }

        public string CadastrarUsuario(string nome)
        {
            using (var context = new BibliotecaContext())
            {
                Usuario novoUsuario = new Usuario(nome);
                context.Usuarios.Add(novoUsuario);
                context.SaveChanges();

                return "Usuário cadastrado com sucesso.";
            }
        }

    }
}