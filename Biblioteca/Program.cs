using Microsoft.EntityFrameworkCore;

namespace Biblioteca;

// Projeto de console app de gerenciamento de uma biblioteca utilizando SQLite
// para prática de conceitos de recursividade e orientação a objetos.
internal class Program
{
    static void Main(string[] args)

    {

        using (var dbContext = new BibliotecaContext())
        {
            dbContext.Database.EnsureCreated();
        }

        UserInterface ui = new UserInterface(new BibliotecaContext());
        ui.ExibirMenu();

    }
}
