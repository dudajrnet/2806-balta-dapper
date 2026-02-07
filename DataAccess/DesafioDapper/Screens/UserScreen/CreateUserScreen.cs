using System;
using DesafioDapper.Models;
using DesafioDapper.Repositories;

namespace DesafioDapper.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Usuário");
            Console.WriteLine("-------------");
            
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            
            Console.Write("Email: ");
            var email = Console.ReadLine();
            
            Console.Write("Biografia: ");
            var bio = Console.ReadLine();
            
            Console.Write("Imagem: ");
            var image = Console.ReadLine();

            Console.Write("Senha: ");
            var password = Console.ReadLine();

            Create(new User
            {
                Name = name,
                Slug = slug,
                Email = email,
                Bio = bio,
                Image = image,
                PasswordHash = password                
            });
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu anterior...");
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}