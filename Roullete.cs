using System;
using System.Collections.Generic;
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
        int balance = 1000;
        

        WriteLine($"Your balance is: {balance}");

        while (true)
        {

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
                    StraightBet();
                    break;
                case 2:
                    ColorBet();
                    break;
                case 3:
                    OddEvenBet();
                    break;
                case 4:
                    LowHighBet();
                    break;
                default:
                    WriteLine("Error invalid choice");
                    break;
            }



            WriteLine("Spinning roulette table...");
            Thread.Sleep(5000);

            int randomNum = RandomNum();
            WriteLine($"{RandomNum()}");
        }
    }

    public static int RandomNum()
    {
        Random random = new Random();

        return random.Next(0, 37);

    }

    public static void StraightBet()
    {
        WriteLine("Pick a single number between 0 and 36");
        int num = Convert.ToInt32(ReadLine());

        if(num == RandomNum())
        {
            WriteLine("Congratulations you won!!");
            balance += bet * 36;
        }
        else
        {
            WriteLine("Sorry you lost...");
            balance -= bet; 
        }
    }

    public static void ColorBet()
    {
        WriteLine("Pick between Red or Black by typing");
        string color = ReadLine();
    }

    public static void OddEvenBet()
    {
        WriteLine("Pick either even numbers or odd numbers");
        string OddEven = ReadLine();
    }

    public static void LowHighBet()
    {
        WriteLine("Type low for 0-18 \nType high for 19-36");
        string HighLow = ReadLine();
    }



}

