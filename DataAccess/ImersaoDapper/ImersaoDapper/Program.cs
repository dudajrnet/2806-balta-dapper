using System;
using ImersaoDapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

using System.Net.Sockets;
using System.ComponentModel;
using System.Globalization;
using System.Net.WebSockets;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Transactions;


namespace ImersaoDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;User Id=sa;Password=1q2w3e4r@#$";

            using (var connection = new SqlConnection(connectionString))
            {                
                //GetCategory(connection);
                //CreateCategory(connection);
                //CreateManyCategories(connection);
                //UpdateCategory(connection);
                //DeleteCategory(connection);
                //ListCategories(connection);
                //ExecuteProcedure(connection);
                //ExecuteReadProcedure(connection);
                //ExecuteEscalar(connection);
                //ReadView(connection);
                //OneToOne(connection);
                //OneToMany(connection);
                //QueryMultiple(connection);
                //SelectIn(connection);
                //SelectLike(connection, "C#"); 
                //Transaction(connection); 
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
        static void CreateManyCategories(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "Categoria Nova";
            category2.Url = "categoria-nova";
            category2.Description = "Categoria Nova de Teste";
            category2.Order = 9;
            category2.Summary = "Categoria Nova";
            category2.Featured = false;

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
            
            var rowsAffected = connection.Execute(insertSql, new[]
            {
                new
                {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Description,
                    category.Order,
                    category.Summary,
                    category.Featured
                },
                new
                {
                    category2.Id,
                    category2.Title,
                    category2.Url,
                    category2.Description,
                    category2.Order,
                    category2.Summary,
                    category2.Featured
                }
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
        static void ExecuteProcedure(SqlConnection connection)
        {
            var sql = "[spDeleteStudent]";
            var parameters = new { StudentId = new Guid("f79ec048-3e07-4e00-a52c-757c8c57651a")};
            var rowsAffected = connection.Execute(
                                             sql, 
                                             parameters, 
                                             commandType: CommandType.StoredProcedure
                                                  );
            Console.WriteLine($"{rowsAffected} registro(s) deletado(s)!");
        }
        static void ExecuteReadProcedure(SqlConnection connection)
        {
            var sql = "[spGetCoursesByCategory]";
            
            var parameters = new { CategoryId = new Guid("09ce0b7b-cfca-497b-92c0-3290ad9d5142")};
            
            var courses = connection.Query(
                                             sql, 
                                             parameters, 
                                             commandType: CommandType.StoredProcedure
                                                  );
            
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Title}");    
            }
        }
        static void ExecuteEscalar(SqlConnection connection)
        {
            var category = new Category();            
            category.Title = "Amazon AWS - Escalar";
            category.Url = "amazon-escalar";
            category.Description = "Categoria destinada a serviços AWS - Escalar";
            category.Order = 10;
            category.Summary = "AWS Cloud Escalar";
            category.Featured = false;

            var insertSql = @"INSERT INTO [category] 
                            OUTPUT INSERTED.[Id]
                            VALUES(
                                  NEWID(),
                                  @Title,
                                  @Url,
                                  @Description,
                                  @Order,
                                  @Summary,
                                  @Featured
                                  )";
            
            var id = connection.ExecuteScalar(insertSql, new
            {                
                category.Title,
                category.Url,
                category.Description,
                category.Order,
                category.Summary,
                category.Featured
            }
            );
            Console.WriteLine($"Categoria inserida com o Id: {id}");            
        }
        static void ReadView(SqlConnection connection)
        {
            var sql = "SELECT * FROM [vwCourses]";
            
            var courses = connection.Query(sql);

            foreach(var course in courses)
            {
                Console.WriteLine($"{course.Id} - {course.Title}");
            }
        }
        static void OneToOne(SqlConnection connection)
        {
            var sql = @"SELECT * FROM [careeritem]
                        INNER JOIN [course]
                        ON [careeritem].[courseId] = [course].[Id]";
            
            var items = connection.Query<CareerItem, Course, CareerItem>(
                sql,
                (careerItem, course) =>
                {
                  careerItem.Course = course;
                  return careerItem;
                }, splitOn: "Id"
            );

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Title} - {item.Course.Title}");
            }
        }   
        static void OneToMany(SqlConnection connection)
        {
            var sql = @"
                SELECT 
                    [Career].[Id],
                    [Career].[Title],
                    [CareerItem].[CareerId],
                    [CareerItem].[Title]
                FROM 
                    [Career] 
                INNER JOIN 
                    [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
                ORDER BY
                    [Career].[Title]";

            var careers = new List<Career>();

            var items = connection.Query<Career, CareerItem, Career>(
                sql,
                (career, item) =>
                {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    
                    if (car == null)
                    {
                        car = career;
                        car.Items.Add(item);
                        careers.Add(car);
                    }
                    else
                    {
                        car.Items.Add(item);
                    }

                    return career;
                    
                }, splitOn: "CareerId");

            foreach (var career in careers)
            {
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.Items)
                {
                    Console.WriteLine($" - {item.Title}");
                }
            }
        }
        static void QueryMultiple(SqlConnection connection)
        {
            var query = "SELECT * FROM [category]; SELECT * FROM [course]";

            using(var multi = connection.QueryMultiple(query))
            {
                var categories = multi.Read<Category>();
                
                var courses = multi.Read<Course>();

                foreach (var category in categories)
                {
                    Console.WriteLine(category.Title);
                }

                foreach (var course in courses)
                {
                    Console.WriteLine(course.Title);
                }
            }
        }     
        static void SelectIn(SqlConnection connection)
        {
            var query = "SELECT * FROM [career] WHERE [Id] IN @Id";

            var items = connection.Query<Career>(query, new 
            {
                Id =new []
                    {
                        "01ae8a85-b4e8-4194-a0f1-1c6190af54cb",
                        "e6730d1c-6870-4df3-ae68-438624e04c72"
                    }
              }              
            );
            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }
        }
        static void SelectLike(SqlConnection connection, string term)
        {
            var query = "SELECT * FROM [course] WHERE [Title] LIKE @exp";

            var items = connection.Query<Course>(query, new 
                {
                    exp = $"%{term}%"
                }
            );

            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }
        }
        static void Transaction(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Nao Salvar";
            category.Url = "nao-salvar";
            category.Description = "Nao deve ser salva";
            category.Order = 11;
            category.Summary = "Nao Salvar";
            category.Featured = true;

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
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                var rowsAffected = connection.Execute(insertSql, new
                    {
                        category.Id,
                        category.Title,
                        category.Url,
                        category.Description,
                        category.Order,
                        category.Summary,
                        category.Featured
                    }, transaction
                ); 

                //transaction.Commit();
                transaction.Rollback();  

                Console.WriteLine($"{rowsAffected} registro(s) inserido(s)!");            
            }
        }
    }
}
