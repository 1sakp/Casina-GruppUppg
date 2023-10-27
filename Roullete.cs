using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

public class RouletteClass
{
    public static void Roullete()
    {
        WriteLine("Welcome to our special Roulette game! \nHere you play under the house rules and they might differ from what you are used to");
        WriteLine("Do you want to play?\n1.Yes 2.No");
        string tecken = ReadLine();

       

        if (tecken == "1")
        {
            WriteLine("Let the fun begin!");
            PlayRoulette();
        }
        else if (tecken == "2")
        {
            WriteLine("Okay, goodbye!");
            return;
        }

    }

    public static void PlayRoulette()
    {
        int?[] blackNum = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36 };
        int?[] whiteNum = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 };
        int?[] greenNum = { 0 };
        string? color1 = "Black";
        string? color2 = "White";
        int balance = Methods.GetBal();

        while (true)
        {
            WriteLine($"Your balance is: {balance}");

            WriteLine("How much do you want to bet? ");
            int bet = Convert.ToInt32(ReadLine());

            if (bet > balance)
            {
                WriteLine("You cannot bet more than your balance");
                return;
            }

            WriteLine("Lastly what do you want to bet on? \n0. Quit \n1. Pick a single number between 0-36 \n2. Pick between Red and Black \n3. Pick between odd or even numbers \n4. Pick between low 0-18 or high 19-36");
            int choice = Convert.ToInt32(ReadLine());

            if (choice == 0)
            {
                WriteLine("Okay goodbye!");
                return;
            }

            switch (choice)
            {
                case 1:
                    StraightBet(balance, bet);
                    break;
                case 2:
                    ColorBet(balance, bet);
                    break;
                case 3:
                    OddEvenBet(balance, bet);
                    break;
                case 4:
                    LowHighBet(balance, bet);
                    break;
                default:
                    WriteLine("Error invalid choice");
                    break;
            }

        }
    }

    public static int RandomNum()
    {
        Random random = new Random();

        return random.Next(0, 37);

    }

    public static void StraightBet(int balance, int bet)
    {
        WriteLine("Pick a single number between 0 and 36");
        int num = Convert.ToInt32(ReadLine());

        WriteLine("Spinning roulette table...");
        Thread.Sleep(1000);

        int randomNum = RandomNum();
        WriteLine($"{RandomNum()}");

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
        }
    }

    public static void ColorBet(int balance, int bet)
    {
        WriteLine("Pick between Red or Black by typing");
        string color = ReadLine().ToLower();

        WriteLine("Spinning roulette table...");
        Thread.Sleep(1000);

        string winColor = GetRandomColor(); 
        Console.WriteLine($"{winColor}");

        if (color == winColor)
        {
            WriteLine("Congratulations You won!!");
            balance += 2 * bet;
        }
        else
        {
            WriteLine($"Sorry you lost");
            balance -= bet;
            
        }
    }

    private static string GetRandomColor()
    {
        Random random = new Random();
        return (random.Next(2) == 0) ? "red" : "black"; 
    }

    public static void OddEvenBet(int balance, int bet)
    {
        WriteLine("Pick either even numbers or odd numbers");
        string oddEven = ReadLine().ToLower();

        WriteLine("Spinning roulette table...");
        Thread.Sleep(1000);

        int randomNum = RandomNum();
        WriteLine($"{RandomNum()}");

        int winNum = RandomNum();

        bool isWinningOddEven = (winNum % 2 == 1 && oddEven == "odd") ||
                                (winNum % 2 == 0 && oddEven == "even");

        if (isWinningOddEven)
        {
            WriteLine("Congratulations You won!!");
            balance += bet * 2;
        }
        else
        {
            WriteLine("Sorry you lost...");
            balance -= bet;
        }
    }

    public static void LowHighBet(int balance, int bet)
    {
        WriteLine("Type low for 0-18 \nType high for 19-36");
        string range = ReadLine().ToLower();

        WriteLine("Spinning roulette table...");
        Thread.Sleep(1000);

        int randomNum = RandomNum();
        WriteLine($"{RandomNum()}");

        int winNum = RandomNum();

        WriteLine($"The winning number is: {randomNum}");

        bool isWinningRange = (winNum >= 0 && winNum <= 18 && range == "low") ||
                              (winNum >= 19 && winNum <= 36 && range == "high");

        if (isWinningRange)
        {
            WriteLine("Congratulations you won!!");
            balance += bet * 2;
        }
        else
        {
            WriteLine("Sorry you lost...");
            balance -= bet;
        }
    }



}

