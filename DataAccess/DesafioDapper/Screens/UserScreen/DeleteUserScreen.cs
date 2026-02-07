using System;
using DesafioDapper.Models;
using DesafioDapper.Repositories;

namespace DesafioDapper.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um usuário");
            Console.WriteLine("-------------");
            Console.Write("Qual o id do usuário que deseja excluir? ");
            var id = Console.ReadLine();
            Delete(int.Parse(id));
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu anterior...");
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Usuário excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}