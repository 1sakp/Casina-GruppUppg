using Casina_GruppUppg;
using System;
using System.Collections;
using System.IO;

public static class LoginClass
{
    public static void Login()
    {
        //Här väljer man om man ska logga in eller registrera sig
        Console.WriteLine("If you already have an account, Please write 'login'! To sign up write 'Sign up'!");
        string choise = Console.ReadLine();
        
        //loggar in
        if (choise.ToLower() == "login")
        {

            //Tar in inlogg info och tar bort 'blankspace'
            Console.WriteLine("To log-in please write, Username:");
            string username_actual = Console.ReadLine().Replace(" ", ""); ;
            Console.WriteLine("Pasword:");
            string password_actual = Console.ReadLine().Replace(" ", ""); ;

            //Gör en string array av alla rader d.v.s personer i txt documentet
            string[] users = File.ReadAllLines(Methods.FullPath());

            //Se om inlogg infon stämmer mot någon användare
            foreach (string user in users)
            {
                string[] splittemp = user.Split('!');
                string Username = splittemp[0];
                string Password = splittemp[1];
                string Balance = splittemp[2];

                //om infon är korrekt så loggas man in
                if (Username.ToLower() == username_actual.ToLower() && Password.ToLower() == password_actual.ToLower())
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {Username} You have been logged in!");


                    //https://stackoverflow.com/questions/10753160/how-exactly-to-use-array-where
                    //hittar var allt i array som inte är nuvarande användare och gör dem till en ny array, på så sätt
                    //tar dem bort nuvarande användaren.
                    users = users.Where(i => i != user).ToArray();
                    File.WriteAllLines(Methods.FullPath(), users); //Owerwrite hela filen utan den inloggade

                    //lägger tillbaka den nuvarande användaren fast i slutet i stället
                    string apend = Username + "!" + Password + "!" + Balance + "!in";
                    string[] lines = { apend }; //gör om infon till en sträng array
                    File.AppendAllLines(Methods.FullPath(), lines); //lägger till den inloggade

                    Redirect();
                }
            }

            //om infon är fel så kommer man tilbaka till loggin eller registrera sidan
            Console.Clear();
            Console.WriteLine("Wrong useranme or password... press enter to continue...");
            Console.ReadLine();
            Login();
        }

        //om man väljer att registrera blir man redirectad dit
        else if (choise.ToLower() == "sign up")
        {
            reg();
        }

        //om man skriver fel så kommer man tillbaka
        else
        {
            Login();
        }
    }

    //register
    static void reg()
    {
        //väljer lösenord och användarnamn
        Console.WriteLine("Choose a Username:   ");
        string Username = Console.ReadLine();
        Console.WriteLine("Choose a Pasword:   ");
        string Password = Console.ReadLine();

        //Skapar användare i txt filen
        string apend = Username + "!" + Password + "!" + "1000" + "!out";
        string[] lines = { apend }; //gör om infon till en sträng array
        File.AppendAllLines(Methods.FullPath(), lines); //lägger in arrayn i filen

        Console.Clear();

        //skickar tillbaka
        Console.WriteLine("You have been registerd!");
        Login();

        
    }
    public static void Redirect()
    {
        //om spelaren har 0 pengar då får hen lägga till mer
        if (Methods.GetBal() == 0)
        {
            Methods.NoCash();
        }

        // Här skriver användaren vilket spel hen vill spela
        Console.WriteLine("Welcome!!! Chose what you want to do!:\nDo you want to play Roulette: '1'\nDo you want to play Slots: '2'\nDo you want to play Slots: '3'\nDo you want to play Slots: '3");
        switch (Console.ReadLine())
        {
            case "1":
                Console.Clear();
                RouletteClass.Roullete();
                break;
            case "2":
                Console.Clear();
                RouletteClass.Roullete();
                break;
            case "3":
                Console.Clear();
                Crapsgame.Main();
                break;
            case "4":
                Console.Clear();
                SlotMachineClass.SlotMachine();
                break;
        }
    }
}

