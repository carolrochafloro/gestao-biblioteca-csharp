namespace Biblioteca;

// Projeto de console app de gerenciamento de uma biblioteca utilizando SQLite
// para prática de conceitos de recursividade e orientação a objetos.
internal class Program
{
    static void Main(string[] args)
    {
        UserInterface ui = new UserInterface();

        ui.ExibirMenu();
    }
}
