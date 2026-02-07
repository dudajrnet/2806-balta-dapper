
using System;
using DesafioDapper.Models;
using DesafioDapper.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
       private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            //CreateUser(connection);
            //ReadUsers(connection);            
            //ReadUser();
            //UpadateUser();
            //DeleteUser();
            //ReadRoles(connection);
            //ReadUserWithRoles(connection);
            connection.Close();
            
        }
        public static void ReadUsers(SqlConnection connection)
        {            
            var userRepository = new Repository<User>(connection);

            var users = userRepository.GetAll();

            foreach(var user in users)
            {
                Console.WriteLine(user.Name);
            }          
        }
        public static void ReadUser()
        {
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);
                Console.WriteLine(user.Name);
            }
        }
        public static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Name = "Rafaela Mendes",
                Email = "rafaela@teste.com",
                PasswordHash = "123456",
                Bio = "Desenvolvedora .NET",
                Image = "https://github.com/rafaelamendes.png",
                Slug = "rafaela-teste"                
            };
                    
            var userRepository = new Repository<User>(connection);
            
            userRepository.Create(user);
            
            Console.WriteLine($"Usuário inserido com sucesso!");
            
        }
        public static void UpadateUser()
        {                        
            var user = new User()
            {
                Id = 4,
                Name = "Robson Cavalcanti deu certo",
                Email = "robson@deucerto.com",
                PasswordHash = "123456",
                Bio = "Desenvolvedor .NET",
                Image = "https://github.com/robsoncavalcanti.png",
                Slug = "robson-deu-certo"                        
            };
            
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {                
                connection.Update<User>(user);
                Console.WriteLine($"Usuário atualizado com sucesso!");
            }
        }
        public static void DeleteUser()
        {
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(7);
                connection.Delete<User>(user);                
                Console.WriteLine($"Usuário deletado com sucesso!");
            }
        }   
        public static void ReadRoles(SqlConnection connection)
        {            
            var roleRepository = new Repository<Role>(connection);

            var roles = roleRepository.GetAll();

            foreach(var role in roles)
            {
                Console.WriteLine(role.Name);
            }          
        }
        public static void ReadUserWithRoles(SqlConnection connection)
        {
            var userRepository = new UserRepository(connection);

            var users = userRepository.ReadWithRoles();

            foreach(var user in users)
            {
                Console.WriteLine(user.Name);
                foreach(var role in user.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            } 
        }
    }
}
