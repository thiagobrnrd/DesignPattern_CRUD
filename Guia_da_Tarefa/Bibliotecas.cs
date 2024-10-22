using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_da_Tarefa
{
    public class Bibliotecas : TemplateMethod
    {
        public Bibliotecas() { }


        private Repositorio repositorio = new Repositorio();


        public TemplateMethod x;

        private string CriarLivro()
        {
            Livro l = new Livro();
            Console.WriteLine("+------------------------- LIVRO  --------------+");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("        Forneça os dados do Livro:              ¦");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("+-----------------------------------------------+");

            Console.WriteLine("ISBN: ");
            l.SetISBN(Console.ReadLine().ToString());

            Console.WriteLine("Título: ");
            l.SetTitulo(Console.ReadLine().ToString());

            Console.WriteLine("Autor: ");
            l.SetAutor(Console.ReadLine().ToString());

            Console.WriteLine("Ano: ");
            l.SetAno(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Gênero: ");
            l.SetGenero(Console.ReadLine().ToString());

            Console.WriteLine("Edição: ");
            l.SetEdicao(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Quantidade: ");
            l.SetQuantidade(Convert.ToInt32(Console.ReadLine()));

            // Correção: Utilizando os getters para acessar os valores
            string sql = $"INSERT INTO Livros (isbn, titulo, autor, ano, genero, edicao, quantidade) VALUES ('{l.GetISBN()}', '{l.GetTitulo()}', '{l.GetAutor()}', {l.GetAno()}, '{l.GetGenero()}', {l.GetEdicao()}, {l.GetQuantidade()});";
            return sql;
        }


        private string AtualizarLivro()
        {
            Livro l = new Livro();
            Console.WriteLine("+------------------------- LIVRO  --------------+");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("    Forneça os dados atualizados do Livro:      ¦");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("+-----------------------------------------------+");

            Console.WriteLine("ISBN: ");
            l.SetISBN(Console.ReadLine().ToString());

            Console.WriteLine("Título: ");
            l.SetTitulo(Console.ReadLine().ToString());

            Console.WriteLine("Autor: ");
            l.SetAutor(Console.ReadLine().ToString());

            Console.WriteLine("Ano: ");
            l.SetAno(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Gênero: ");
            l.SetGenero(Console.ReadLine().ToString());

            Console.WriteLine("Edição: ");
            l.SetEdicao(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Quantidade: ");
            l.SetQuantidade(Convert.ToInt32(Console.ReadLine()));

            // Correção: Utilizando os getters e ajustando a query
            string sql = $"UPDATE Livros SET titulo = '{l.GetTitulo()}', autor = '{l.GetAutor()}', ano = {l.GetAno()}, genero = '{l.GetGenero()}', edicao = {l.GetEdicao()}, quantidade = {l.GetQuantidade()} WHERE isbn = '{l.GetISBN()}';";
            return sql;
        }

        private string ConsultarLivro()
        {
            Livro l = new Livro();
            Console.WriteLine("+------------------------- LIVRO  --------------+");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("    Forneça o ISBN do Livro para consultar:     ¦");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("+-----------------------------------------------+");

            Console.WriteLine("ISBN: ");
            l.SetISBN(Console.ReadLine().ToString());

            // Correção: Usar o getter correto
            string sql = $"SELECT * FROM Livros WHERE isbn LIKE '%{l.GetISBN()}%';";
            return sql;
        }
        private string DeletarLivro()
        {
            Livro l = new Livro();
            Console.WriteLine("+------------------------- LIVRO  --------------+");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("    Forneça o ISBN do Livro para deletar:       ¦");
            Console.WriteLine("¦                                               ¦");
            Console.WriteLine("+-----------------------------------------------+");

            Console.WriteLine("ISBN: ");
            l.SetISBN(Console.ReadLine().ToString());

            // Correção: Remover o '*' e ajustar para deletar pelo ISBN
            string sql = $"DELETE FROM Livros WHERE isbn = '{l.GetISBN()}';";
            return sql;
        }

        protected override string executarAcao(string op)
        {
            op = Singleton.getInstance().ShowMenu("MENU_BIBLIOTECA", x);

            switch (op)
            {
                case "1":
                    {
                        string sql = CriarLivro();
                        repositorio.executeScript(sql);
                        Console.Clear();
                        return "Livro criado com sucesso";
                    }
                case "2":
                    {
                        string sql = AtualizarLivro();
                        repositorio.executeScript(sql);
                        Console.Clear();
                        return "Livro atualizado com sucesso";
                    }
                case "3":
                    {
                        string sql = DeletarLivro();
                        repositorio.executeScript(sql);
                        Console.Clear();
                        return "Livro deletado com sucesso";
                    }
                case "4":
                    {
                        string sql = ConsultarLivro();
                        repositorio.executeQuery(sql);
                        Console.Clear();
                        return "Livro consultado com sucesso";
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