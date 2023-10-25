using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class LoginClass
{
    public static void Login()
    {
        string fullPath = (System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString() +"\\Info.txt");
        Console.WriteLine("If you already have an account, Please write 'login'! To sign up write 'Sign up'!");
        string choise = Console.ReadLine();
        if (choise.ToLower() == "login")
        {
            Console.WriteLine("To log-in please write, Username:");
            string username_actual = Console.ReadLine().Replace(" ", ""); ;
            Console.WriteLine("Pasword:");
            string password_actual = Console.ReadLine().Replace(" ", ""); ;

            string[] users = File.ReadAllLines(fullPath);

            //check users
            foreach (string user in users)
            {
                string[] splittemp = user.Split('!');
                string Username = splittemp[0];
                string Passwordword = splittemp[1];

                Console.WriteLine(splittemp[0] + splittemp[1]);

                if (Username.ToLower() == username_actual.ToLower() && Passwordword.ToLower() == password_actual.ToLower())
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {Username} You have been logged in!");
                    Redirect();
                }
            }
            Console.Clear();
            Console.WriteLine("Wrong useranme or password... press enter to continue...");
            Console.ReadLine();
            Login();
        }
        else if (choise.ToLower() == "sign up");
        {
            reg();
        }
    }

    static void reg()
    {
        //register
        string fullPath = (System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString() + "\\Info.txt");

        bool loop = true;
        while (loop == true)
        {
            string choise = null;
            Console.WriteLine("Do you want to continue to sign up? Y/N");
            choise = Console.ReadLine();

            if (choise.ToLower() == "y")
            {
                Console.WriteLine("Choose a Username:   ");
                string Username = Console.ReadLine();
                Console.WriteLine("Choose a Pasword:   ");
                string Password = Console.ReadLine();

                string apend = Username + "!" + Password + "!" + "1000";
                string[] lines = { apend };

                File.AppendAllLines(fullPath, lines);

                Console.Clear();

                Console.WriteLine("You have been registerd!");
                Login();
            }
            else
            {
                Login();
            }
        }
    }
    static void Redirect()
    {
        Console.WriteLine("Welcome!!! Chose what you want to do!:\nDo you want to play Roulette: '1'\nDo you want to play Slots: '2'");
        switch (Console.ReadLine())
        {
            case "1":
                RouletteClass.Roullete();
                break;
            case "2":
                RouletteClass.Roullete();
                break;
                
        }
    }
}

