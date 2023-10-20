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
        WriteLine("Do you want to play?\n 1.Yes 2.No");
        string tecken = ReadLine();

       

        if (tecken == "1")
        {
            WriteLine("Let the fun begin");
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

        WriteLine("Your balance is: ");
        ReadLine();
        WriteLine("How much do you want to bet? ");
        ReadLine();
        WriteLine("Lastly what do you want to bet on? ");
        ReadLine();

        WriteLine("Spinning roulette table...");
        Thread.Sleep(10000);

        int randomNum = Random();
        
        WriteLine($"{randomNum}");

    }

    public static void Random()
    {
        Random random = new Random();

        return random.Next(0, 37);

    }



}

