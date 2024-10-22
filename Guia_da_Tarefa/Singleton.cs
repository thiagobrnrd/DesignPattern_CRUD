using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_da_Tarefa
{
    public sealed class Singleton
    {
        private Singleton() { }

        private static Singleton _Instance;

        public static Singleton getInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Singleton();
            }

            return _Instance;
        }

        public string ShowMenu(string key, TemplateMethod x)
        {
            string retorno = null;
            switch (key)
            {
                case "MENU_PRINCIPAL":
                    {
                        Console.WriteLine("╔════════════════ MENU DE OPÇÕES ═══════════════╗");
                        Console.WriteLine("║ 1 SECRETARIA                                  ║");
                        Console.WriteLine("║ 2 BIBLIOTECA                                  ║");
                        Console.WriteLine("║═══════════════════════════════════════════════║");
                        Console.WriteLine("║ 0 SAIR                                        ║");
                        Console.WriteLine("╚═══════════════════════════════════════════════╝");
                        Console.WriteLine(" ");
                        Console.Write("DIGITE UMA OPÇÃO : ");

                        retorno = Console.ReadLine();
                        break;
                    }
                case "MENU_SECRETARIA":
                    {
                        Console.WriteLine("╔════════════════ MENU DE OPÇÕES ═══════════════╗");
                        Console.WriteLine("║ 1 INCLUIR - ALUNO                             ║");
                        Console.WriteLine("║ 2 ATUALIZAR - ALUNO                           ║");
                        Console.WriteLine("║ 3 REMOVER - ALUNO                             ║");
                        Console.WriteLine("║ 4 CONSULTAR - ALUNO                           ║");
                        Console.WriteLine("║═══════════════════════════════════════════════║");
                        Console.WriteLine("║ 0 SAIR                                        ║");
                        Console.WriteLine("╚═══════════════════════════════════════════════╝");
                        Console.WriteLine(" ");
                        Console.Write("DIGITE UMA OPÇÃO : ");

                        retorno = Console.ReadLine();
                        if (x != null) x.run(retorno); 
                        break;
                    }
                case "MENU_BIBLIOTECA":
                    {
                        Console.WriteLine("╔════════════════ MENU DE OPÇÕES ═══════════════╗");
                        Console.WriteLine("║ 1 INCLUIR - LIVRO                             ║");
                        Console.WriteLine("║ 2 ATUALIZAR - LIVRO                           ║");
                        Console.WriteLine("║ 3 REMOVER - LIVRO                             ║");
                        Console.WriteLine("║ 4 CONSULTAR - LIVRO                           ║");
                        Console.WriteLine("║═══════════════════════════════════════════════║");
                        Console.WriteLine("║ 0 SAIR                                        ║");
                        Console.WriteLine("╚═══════════════════════════════════════════════╝");
                        Console.WriteLine(" ");
                        Console.Write("DIGITE UMA OPÇÃO : ");

                        retorno = Console.ReadLine();
                        if (x != null) x.run(retorno); 
                        break;
                    }
                case "SAIR":
                    {
                        break;
                    }
            }
            return retorno;
        }
    }
}


