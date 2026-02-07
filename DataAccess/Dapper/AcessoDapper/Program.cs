using System;
using AcessoDapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AcessoDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;User Id=sa;Password=1q2w3e4r@#$";

            using (var connection = new SqlConnection(connectionString))
            {
                //ListCategories(connection);
                //GetCategory(connection);
                //CreateCategory(connection);
                //UpdateCategory(connection);
                //DeleteCategory(connection);
            }
        }
        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [category]");

            foreach(var category in categories)
            {
                Console.WriteLine($"{category.Id} - {category.Title}");
            }
        }
        static void GetCategory(SqlConnection connection)
        {
            var category = connection
                            .QueryFirstOrDefault<Category>(
                                "SELECT [Id], [Title] FROM [category] WHERE [Id] = @Id",
                                new
                                {
                                    Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4")
                                }
                            ); 
            Console.WriteLine($"{category.Id} - {category.Title}");       
        }
        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"INSERT INTO [category] 
                            VALUES(
                                  @Id,
                                  @Title,
                                  @Url,
                                  @Description,
                                  @Order,
                                  @Summary,
                                  @Featured
                                  )";
            
            var rowsAffected = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Description,
                category.Order,
                category.Summary,
                category.Featured
            }
            );

            Console.WriteLine($"{rowsAffected} registro(s) inserido(s)!");            
        }
        static void UpdateCategory(SqlConnection connection)
        {
            var updateSql = @"UPDATE [category] SET [Title] = @Title WHERE [Id] = @Id";

            var rowsAffected = connection.Execute(updateSql, new {                
                                               Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                                               Title = "Frontend 2026"                
                                               }
                                               );
            Console.WriteLine($"{rowsAffected} registro(s) atualizado(s)!");
        }
        static void DeleteCategory(SqlConnection connection)
        {
            var deleteSql = @"DELETE FROM [category] WHERE [Id] = @Id";

            var rowsAffected =connection.Execute(deleteSql, new{                
                                                                 Id = new Guid("68a41fdf-ddce-45cb-86ac-05ff8b45cdca")
                                                               }
                                                 );
            Console.WriteLine($"{rowsAffected} registro(s) deletado(s)!");
        }
    }
}
