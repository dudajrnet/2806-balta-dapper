using System;

namespace DesafioDapper.Screens.TagScreens
{
    public static class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de tags");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("0 - Voltar ao menu principal");
            Console.WriteLine("1 - Listar tags");
            Console.WriteLine("2 - Cadastrar tags");
            Console.WriteLine("3 - Atualizar tag");
            Console.WriteLine("4 - Excluir tag");
            Console.WriteLine();
            Console.WriteLine();
            short option = 0;            
            
            try
            {
                option = short.Parse(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Valor inválido, tente novamente.");
                Console.WriteLine("--------------------------------");
                Console.ReadKey();
                Program.Load();
            }            
            
            switch (option)
            {
                case 0:
                    Program.Load();                    
                    break;
                case 1:
                    ListTagScreen.Load();                    
                    break;
                case 2:
                    CreateTagScreen.Load();
                    break;
                case 3:
                    UpdateTagScreen.Load();
                    break;
                case 4:
                    DeleteTagScreen.Load();
                    break;
                default:                     
                    Program.Load(); 
                    break;
            }
        }
    }
}