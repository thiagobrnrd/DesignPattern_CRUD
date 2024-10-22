using MySql.Data.MySqlClient;
using System.Data;

public class Repositorio : IDisposable
{
    private MySqlConnection con;
    private bool disposed = false;

    public Repositorio()
    {
        con = new MySqlConnection("Server=localhost;Port=3306;Database=universidadedb;Uid=root;");
        try
        {
            con.Open();
            Console.WriteLine($"Conexão com o MySQL bem-sucedida! Versão do servidor: {con.ServerVersion}");
        }
        catch (MySqlException e)
        {
            Console.WriteLine($"Erro ao conectar ao banco de dados: {e.Message}");
            con.Dispose();
            throw;
        }
    }

    // Método para executar scripts SQL
    public void executeScript(string sql)
    {
        if (string.IsNullOrWhiteSpace(sql))
        {
            Console.WriteLine("O script SQL está vazio.");
            return;
        }

        if (con.State == ConnectionState.Open)
        {
            try
            {
                using var cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Script executado com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao executar script: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("A conexão não está aberta.");
        }
    }

    // Método para executar queries SQL
    public void executeQuery(string sql)
    {
        if (string.IsNullOrWhiteSpace(sql))
        {
            Console.WriteLine("A query SQL está vazia.");
            return;
        }

        if (con.State == ConnectionState.Open)
        {
            try
            {
                using var cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Query executada com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao executar query: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("A conexão não está aberta.");
        }
    }

    // Implementação correta do Dispose Pattern
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Liberar recursos gerenciados
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }

            // Liberar recursos não gerenciados (se houver)

            disposed = true;
        }
    }

    // Método Dispose
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);  // Suprime a chamada do destrutor (finalizer)
    }

    ~Repositorio()
    {
        Dispose(false);  // Destrutor chamando Dispose para liberar recursos não gerenciados
    }
}
