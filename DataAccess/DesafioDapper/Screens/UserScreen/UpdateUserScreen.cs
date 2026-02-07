using System;
using DesafioDapper.Models;
using DesafioDapper.Repositories;

namespace DesafioDapper.Screens.UserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando um usuário");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Update(new User
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu anterior...");
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Update(user);
                Console.WriteLine("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}