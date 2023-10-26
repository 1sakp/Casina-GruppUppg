using Casina_GruppUppg;
using System;

public class LoginClass
{
    public static void Login()
    {
        //fullpath är hur man kommer till filerna
        string fullPath = (System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString() +"\\Info.txt");

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
            string[] users = File.ReadAllLines(fullPath);

            //Se om inlogg infon stämmer mot någon användare
            foreach (string user in users)
            {
                string[] splittemp = user.Split('!');
                string Username = splittemp[0];
                string Passwordword = splittemp[1];

                Console.WriteLine(splittemp[0] + splittemp[1]);

                //om infon är korrekt så loggas man in
                if (Username.ToLower() == username_actual.ToLower() && Passwordword.ToLower() == password_actual.ToLower())
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {Username} You have been logged in!");
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
        //fullpath är hur man kommer till filerna
        string fullPath = (System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString() + "\\Info.txt");

        //väljer lösenord och användarnamn
        Console.WriteLine("Choose a Username:   ");
        string Username = Console.ReadLine();
        Console.WriteLine("Choose a Pasword:   ");
        string Password = Console.ReadLine();

        //Skapar användare i txt filen
        string apend = Username + "!" + Password + "!" + "1000";
        string[] lines = { apend }; //gör om infon till en sträng array
        File.AppendAllLines(fullPath, lines); //lägger in arrayn i filen

        Console.Clear();

        //skickar tillbaka
        Console.WriteLine("You have been registerd!");
        Login();

        
    }
    static void Redirect()
    {
        // Här skriver användaren vilket spel hen vill spela
        Console.WriteLine("Welcome!!! Chose what you want to do!:\nDo you want to play Roulette: '1'\nDo you want to play Slots: '2'\nDo you want to play Slots: '3'\nDo you want to play Slots: '3");
        switch (Console.ReadLine())
        {
            case "1":
                RouletteClass.Roullete();
                break;
            case "2":
                RouletteClass.Roullete();
                break;
            case "3":
                Crapsgame.Main();
                break;
            case "4":
                SlotMachineClass.SlotMachine();
                break;


        }
    }
}

