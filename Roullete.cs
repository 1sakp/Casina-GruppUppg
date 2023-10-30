using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

public class RouletteClass
{
    //Start metod med klass
    public static void Roullete()
    {
        WriteLine("Let the fun begin!!");

        //Balansen hämtas från annan metod
        int balance = Methods.GetBal();

        //Startar en loop för att betta där den skriver ut ens balans samt frågar hur mycket man vill betta
        while (true)
        {
            balance = Methods.GetBal();
            WriteLine($"Your balance is: {balance}");

            WriteLine("How much do you want to bet? ");
            int bet = Convert.ToInt32(ReadLine());

            //Har en kontroll så man inte kan betta 0, mindre än 0, eller mer än sin balans 
            while (bet > balance || bet == 0 || bet < 0)
            {
                if (bet > balance)
                {
                    WriteLine("You cannot bet more than your balance. Enter a valid bet: ");
                }
                else
                {
                    WriteLine("You cannot bet zero. Enter another bet: ");
                }

                bet = Convert.ToInt32(Console.ReadLine());
            }

            //Man har 5 olika val, varav det första är för att lämna och man blir tillbaka skickad till start skärmen
            //De andra alternativen skickar en till en separat metod där man gör sina bet. Samt en kontroll.
            WriteLine("What do you want to bet on? \n0. Quit \n1. Pick a single number between 0-36 \n2. Pick between Red and Black \n3. Pick between odd or even numbers \n4. Pick between low 0-18 or high 19-36");
            int choice = Convert.ToInt32(ReadLine());

            if (choice == 0)
            {              
                Console.Clear();
                LoginClass.Redirect();
            }

            switch (choice)
            {
                case 1:
                    StraightBet(Methods.GetBal(), bet);
                    break;
                case 2:
                    ColorBet(Methods.GetBal(), bet);
                    break;
                case 3:
                    OddEvenBet(Methods.GetBal(), bet);
                    break;
                case 4:
                    LowHighBet(Methods.GetBal(), bet);
                    break;
                default:
                    WriteLine("Error invalid choice. Press enter to continue");
                    ReadLine();
                    Clear();
                    Roullete();
                    break;
            }

        }
    }
    //En metod för att generera ett random nummer som sen kallas i följande metoder för att veta om man vinner eller ej
    public static int RandomNum()
    {
        Random random = new Random();

        return random.Next(0, 37);
    }
    //Första metoden för enskilda nummer, en try catch ifall man skriver något utanför 0-36. Samt en uträkning för att vinst alternativt förlust.
    public static void StraightBet(int balance, int bet)
    {
        try
        {
            WriteLine("Pick a single number between 0 and 36");
            int num = Convert.ToInt32(ReadLine());

            if (num < 0 || num > 36)
            {
                throw new ArgumentException("Invalid number. Please pick a number between 0-36.");
            }
            

            WriteLine("Spinning roulette table...");
            Thread.Sleep(1000);

            int randomNum = RandomNum();
            WriteLine($"{randomNum}");

            if (num == randomNum)
            {
                WriteLine("Congratulations you won!!");
                balance += bet * 36;
                Methods.Deposit(balance);
            }
            else
            {
                WriteLine("Sorry you lost...");
                balance -= bet;
                Methods.Deposit(balance);
            }

            playOn();
        }

        catch (ArgumentException ex)
        {
            Console.Clear();
            WriteLine($"Error: {ex.Message}");

        }
        catch (Exception ex)
        {
            Console.Clear();
            WriteLine($"An unexpected error occurred: {ex.Message}");

        }
    }
    //Andra metoden är för färg bet. Ser hyfsat likadant ut som straightbet men har en funktion och en randomizer för vilken färg det är som vinner
    public static void ColorBet(int balance, int bet)
    {
        try
        {
            WriteLine("Pick between Red or Black by typing");
            string color = ReadLine().ToLower();

            if (color != "black" && color != "red")
            {
                throw new ArgumentException("Invalid color. Please pick either Black or Red.");
            }

            WriteLine("Spinning roulette table...");
            Thread.Sleep(1000);

            string winColor = GetRandomColor();
            WriteLine($"{winColor}");

            if (color == winColor)
            {
                WriteLine("Congratulations you won!!");
                balance += bet * 2;
                Methods.Deposit(balance);
            }
            else
            {
                WriteLine("Sorry you lost");
                balance -= bet;
                Methods.Deposit(balance);
            }

            playOn();
        }

        catch (ArgumentException ex)
        {
            Console.Clear();
            WriteLine($"Error: {ex.Message}");
     
        }
        catch (Exception ex)
        {
            Console.Clear();
            WriteLine($"An unexpected error occurred: {ex.Message}");
            
        }
        
    }
    //Här är metoden som ger en random färg, finns säkert något annat sätt att göra det på men detta verkade som det lättaste. Den kallas sedan i funktionen över
    private static string GetRandomColor()
    {
        Random random = new Random();
        return (random.Next(2) == 0) ? "red" : "black"; 
    }
    //Här är en metod när man vill beta på jämna eller ojämna tal. Fick även här skaffa en funktion för vinnande nummer som räknar ut om det är jämnt eller ojämnt
    //Denna metoden har också sveriges jobbigaste IF-sats för att få in alla möjliga händelser. Man kan tro att den skulle vara lika lätt som colorbet, men det var den inte
    public static void OddEvenBet(int balance, int bet)
    {
        try
        {
            WriteLine("Pick either even numbers or odd numbers");
            string oddEven = ReadLine().ToLower();

            if (oddEven != "odd" && oddEven != "even")
            {
                throw new ArgumentException("Invalid pick. Please pick either Odd or Even.");
            }

            WriteLine("Spinning roulette table...");
            Thread.Sleep(1000);

            int winNum = RandomNum();
            WriteLine($"{winNum}");


            int[] evenNumbers = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36 };
            int[] oddNumbers = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 };

            if (oddEven == "even")
            {
                if (evenNumbers.Contains(winNum))
                {
                    WriteLine("Congratulations You won!!");
                    balance += bet * 2;
                    Methods.Deposit(balance);
                }
                else
                {
                    WriteLine("Sorry you lost...");
                    balance -= bet;
                    Methods.Deposit(balance);
                }
            }
            else if (oddEven == "odd")
            {
                if (oddNumbers.Contains(winNum))
                {
                    WriteLine("Congratulations You won!!");
                    balance += bet * 2;
                    Methods.Deposit(balance);
                }
                else
                {
                    WriteLine("Sorry you lost...");
                    balance -= bet;
                    Methods.Deposit(balance);
                }
            }
            

            playOn();
        }
        catch (ArgumentException ex)
        {
            Console.Clear();
            WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.Clear();
            WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
    //Här är metoden för att beta på höga eller låga nummer där jag kör en funktion som räknar ut vilken "range" det är som vinner
    //Denna var förvånadsvärt lätt och har också try catch som alla tidigare
    public static void LowHighBet(int balance, int bet)
    {
        try
        {
            WriteLine("Type low for 0-18 \nType high for 19-36");
            string range = ReadLine().ToLower();

            if (range != "high" && range != "low")
            {
                throw new ArgumentException("Invalid pick. Please pick either High or Low.");
            }

            WriteLine("Spinning roulette table...");
            Thread.Sleep(1000);

            int winNum = RandomNum();
            WriteLine($"{winNum}");

            bool isWinningRange = (winNum >= 0 && winNum <= 18 && range == "low") ||
                                  (winNum >= 19 && winNum <= 36 && range == "high");

            if (isWinningRange)
            {
                WriteLine("Congratulations you won!!");
                balance += bet * 2;
                Methods.Deposit(balance);
            }
            else
            {
                WriteLine("Sorry you lost...");
                balance -= bet;
                Methods.Deposit(balance);
            }

            playOn();
        }
        catch (ArgumentException ex)
        {
            Console.Clear();
            WriteLine($"Error: {ex.Message}");

        }
        catch (Exception ex)
        {
            Console.Clear();
            WriteLine($"An unexpected error occurred: {ex.Message}");

        }
    }
    //Sist men inte minst ställer jag frågan ifall folk vill spela vidare på roulette eller om de vill välja något av de andra spelen vi erbjuder. Så denna kallas i alla tidigare metoder
    public static void playOn()
    {
        if (Methods.GetBal() == 0)
        {
            Methods.NoCash();
        }

        WriteLine("1. To play again \n2. To play another game");
        int playOn = Convert.ToInt32(ReadLine());

        if (playOn == 1)
        {
            Console.Clear();
            Roullete();
        }
        else if (playOn == 2)
        {
            Console.Clear();
            LoginClass.Redirect();

        }
    }



}

