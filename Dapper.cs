using BaltaDataAccess.Model;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess
{
    public class Dapper
    {
        public static void ExecuteDapper()
        {
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Summary = "AWS Cloud";
            category.Order = 8;
            category.Description = "Categoria destinada a serviços AWS";
            category.Featured = false;
            //SQL Injection (Não concatenar string com a variável. Não podemos colocar category.Id no campo Id, devemos usar parâmetros utilizando o @)
            var insertSql = "INSERT INTO [Category] VALUES(@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";
            //Evitar de fazer muito processamento na connexão para não sobrecarregar
            using(var connection = new SqlConnection(connectionString))
            {
                //Parâmetros anônimos
                //Execute retorna a quantidade de linhas que foram afetadas
                var rows = connection.Execute(insertSql, new {
                    category.Id, 
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                });
                Console.WriteLine($"{rows} linhas inseridas");

                var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

                foreach(var item in categories)
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }
    }
}