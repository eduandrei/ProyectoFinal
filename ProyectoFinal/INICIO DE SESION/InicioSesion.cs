
using ProyectoFinal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Console.WriteLine("**********************************************");
Console.WriteLine("    Bienvenido a CoderHouse    ");
Console.WriteLine("----------------------------------------------------\n");


login();

namespace Proyecto_final.InicioDeSesion
{
    void Login()
    {
        int attemptCounter = 3;
        bool succesfulLogin = false;


        do
        {
            Console.WriteLine("");
            Console.WriteLine("**********************************************");
            Console.WriteLine($"Inicie sesion en los modulos CRUD (USted Tebdra {attemptCounter} attempts) \n");
            Console.WriteLine("Por favor ingrese su nombre: \n");
            string userName = Console.ReadLine();
            Console.WriteLine("Por favor ingrese su Contraseña: \n");
            string password = Console.ReadLine();

            UsuarioHandler objUserHandler = new UsuarioHandler();


            if (objUserHandler.GetUsersByUserName(userName, password))
            {
                bool showMenu = true;
                while (showMenu)
                {
                    showMenu = MainMenu();
                    succesfulLogin = true;
                }
            }
            else
            {
                attemptCounter--;
                if (attemptCounter == 0)
                {
                    break;
                }
            }
        }
        while (succesfulLogin is false);


    }
}