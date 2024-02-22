using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Security.Policy;

namespace Biblioteca;
internal class Livro
{

    public string Autor { get; set; }
    public string Titulo {  get; set; }
    public int Paginas { get; set; }

    public bool Emprestado = false;


    //Construtor obriga a inserção de todos os atributos ao cadastrar um novo livro e inicia o atributo "emprestado" como falso.

    public Livro(string autor, string titulo, int paginas)
    {
        Autor = autor;
        Titulo = titulo;
        Paginas = paginas;
        Emprestado = false;
    }

    //getter para informar se o livro está emprestado

    public bool EstaEmprestado()
    {
        return Emprestado;
    }
 
}



