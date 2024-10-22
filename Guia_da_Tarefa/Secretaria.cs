using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Guia_da_Tarefa
{
    public class Secretaria : TemplateMethod
    {
        public TemplateMethod x;

        private Repositorio repositorio = new Repositorio();

        private string CriarAluno()
        {
            Aluno a = new Aluno();
            Console.WriteLine("+------------------------- ALUNO  --------------+");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("        Forneça os dados do Aluno:              ¦");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("+-----------------------------------------------+");

            Console.WriteLine("RGM: ");
            a.SetRGM(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Nome: ");
            a.SetNome(Console.ReadLine().ToString());

            Console.WriteLine("Curso: ");
            a.SetCurso(Console.ReadLine().ToString());

            Console.WriteLine("Semestre: ");
            a.SetSemestre(Console.ReadLine().ToString());

            // Correção: Usar os métodos getters para acessar os valores
            string sql = $"INSERT INTO Alunos (RGM, Nome, Curso, Semestre) VALUES ('{a.GetRGM()}', '{a.GetNome()}', '{a.GetCurso()}', '{a.GetSemestre()}');";
            return sql;
        }

        private string AtualizarAluno()
        {
            Aluno a = new Aluno();
            Console.WriteLine("+------------------------- ALUNO  --------------+");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("    Forneça os dados atualizados do Aluno:      ¦");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("+-----------------------------------------------+");

            Console.WriteLine("RGM: ");
            a.SetRGM(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Nome: ");
            a.SetNome(Console.ReadLine().ToString());

            Console.WriteLine("Curso: ");
            a.SetCurso(Console.ReadLine().ToString());

            Console.WriteLine("Semestre: ");
            a.SetSemestre(Console.ReadLine().ToString());

            // Correção: Colocar curso entre aspas simples
            string sql = $"UPDATE Alunos SET Nome = '{a.GetNome()}', Curso = '{a.GetCurso()}', Semestre = '{a.GetSemestre()}' WHERE RGM = {a.GetRGM()};";
            return sql;
        }

        private string DeletarAluno()
        {
            Aluno a = new Aluno();
            Console.WriteLine("+------------------------- ALUNO  --------------+");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("    Forneça o RGM do Aluno para deletar:         ¦");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("+-----------------------------------------------+");

            Console.WriteLine("RGM: ");
            a.SetRGM(Convert.ToInt32(Console.ReadLine()));

            // Correção: Remover o * e usar WHERE com igualdade
            string sql = $"DELETE FROM Alunos WHERE RGM = {a.GetRGM()};";
            return sql;
        }

        private string ConsultarAluno()
        {
            Aluno a = new Aluno();
            Console.WriteLine("+------------------------- ALUNO  --------------+");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("    Forneça o Nome do Aluno para consultar:      ¦");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("+-----------------------------------------------+");

            Console.WriteLine("Nome: ");
            a.SetNome(Console.ReadLine().ToString());

            // Correção: Retornar a query correta
            string sql = $"SELECT * FROM Alunos WHERE Nome LIKE '%{a.GetNome()}%';";
            return sql;
        }

        protected override string executarAcao(string op)
        {
            op = Singleton.getInstance().ShowMenu("MENU_SECRETARIA", x);

            switch (op)
            {
                case "1":
                    {
                        Secretaria s = new Secretaria();
                        string sql = s.CriarAluno();
                        repositorio.executeScript(sql);
                        Console.Clear();
                        return "Aluno criado com sucesso";
                    }
                case "2":
                    {
                        Secretaria s = new Secretaria();
                        string sql = s.AtualizarAluno();
                        repositorio.executeScript(sql);
                        Console.Clear();
                        return "Aluno atualizado com sucesso";
                    }
                case "3":
                    {
                        Secretaria s = new Secretaria();
                        string sql = s.DeletarAluno();
                        repositorio.executeScript(sql);
                        Console.Clear();
                        return "Aluno deletado com sucesso";
                    }
                case "4":
                    {
                        Secretaria s = new Secretaria();
                        string sql = s.ConsultarAluno();
                        repositorio.executeQuery(sql);
                        Console.Clear();
                        return "Aluno consultado com sucesso";
                    }
                default:
                    {
                        Console.WriteLine("Digitou uma opção inválida!!");
                        Console.Clear();
                        return "Opção inválida";
                    }
            }
        }


    }
}
