using Guia_da_Tarefa;

class Program
{
    static void Main(string[] args)
    {
        Singleton menu = Singleton.getInstance();

        string opcaoMenuPrincipal = menu.ShowMenu("MENU_PRINCIPAL", null);

        while (opcaoMenuPrincipal != "0") 
        {
            switch (opcaoMenuPrincipal)
            {
                case "1": 
                    {
                        TemplateMethod secretariaTemplateMethod = new Secretaria(); 
                        menu.ShowMenu("MENU_SECRETARIA", secretariaTemplateMethod);
                        break;
                    }
                case "2": 
                    {
                        TemplateMethod bibliotecaTemplateMethod = new Bibliotecas(); 
                        menu.ShowMenu("MENU_BIBLIOTECA", bibliotecaTemplateMethod);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                    }
            }

            
            opcaoMenuPrincipal = menu.ShowMenu("MENU_PRINCIPAL", null);
        }
    }
}