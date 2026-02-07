using System;
using DesafioDapper.Models;
using DesafioDapper.Repositories;

namespace DesafioDapper.Screens.TagScreens
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma tag");
            Console.WriteLine("-------------");
            Console.Write("Qual o id da Tag que deseja exluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu anterior...");
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Tag exluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível exluir a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}