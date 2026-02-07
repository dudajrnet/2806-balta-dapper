using System;

namespace DesafioDapper.Screens.UserScreens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Usuários");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("0 - Voltar ao menu principal");
            Console.WriteLine("1 - Listar usuários");
            Console.WriteLine("2 - Cadastrar usuários");
            Console.WriteLine("3 - Atualizar usuário");
            Console.WriteLine("4 - Excluir usuário");
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
                    ListUserScreen.Load();
                    break;
                case 2:
                    CreateUserScreen.Load();
                    break;
                case 3:
                    UpdateUserScreen.Load();
                    break;
                case 4:
                    DeleteUserScreen.Load();
                    break;
                default: 
                    Load(); 
                    break;
            }
        }
    }
}