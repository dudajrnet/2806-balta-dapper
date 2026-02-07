using System;
using DesafioDapper.Models;
using DesafioDapper.Repositories;

namespace DesafioDapper.Screens.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de usuários");
            Console.WriteLine("-----------------");
            List();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu anterior...");
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<User>(Database.Connection);
            var users = repository.GetAll();
            foreach (var user in users)
                Console.WriteLine($"{user.Id} - {user.Name} => {user.Bio}");
        }
    }
}