using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca;
internal class Usuario
{
    public string NomeUsuario { get; set; }
    public List<Livro> LivrosEmprestados { get; set; }

    // Construtor obriga informar o nome do usuário no momento do cadastro.
    public Usuario(string nomeUsuario)
    {
        NomeUsuario = nomeUsuario;
        LivrosEmprestados = new List<Livro>();

    }


}
