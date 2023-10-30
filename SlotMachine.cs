using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casina_GruppUppg
{
    public class SlotMachineClass
    {
        public static void SlotMachine()
        {
            int balance = Methods.GetBal();
            int bet;
            int numberOfReels = 3;

            bool playAgain;

            string? input;
            string[] result = new string[numberOfReels];
            string[] symbols = { "!", "$", "&" };
            Random rand = new();

            WriteLine("You found a Slot Machine!");

            do
            {
                WriteLine("Place your bet: ");
                input = ReadLine();
                while (!int.TryParse(input, out bet)) // if the user inputs something that cannot be parsed to an int
                {
                    WriteLine("Oh no! You need to write a number: "); // make the user input an int
                    input = ReadLine();
                }
                int.TryParse(input, out bet); //Parse string input from user to int
                WriteLine($"You bet: {bet}");

                WriteLine("Ready to play? Press enter to spin...");
                ReadLine();

                for (int i = 0; i < numberOfReels; i++)
                {
                    if (rand.Next(100) < 20) // 20% chance of winning
                    {
                        result[i] = "!";
                    }
                    else if (rand.Next(100) < 20) // 20% chance of winning
                    {
                        result[i] = "$";
                    }
                    else if (rand.Next(100) < 20) // 20% chance of winning
                    {
                        result[i] = "&";
                    }
                    else
                    {
                        result[i] = symbols[rand.Next(symbols.Length)];
                    }
                }

                WriteLine("The wheel is spinning...");
                Thread.Sleep(1000); // sleep for 1 sek to build suspension
                WriteLine(string.Join(" | ", result)); // make the display more readable with | inbetween the symbols

                bool wins = WinInSomeCases(result); // call the WinInSomeCases function to check if it's a match for winning combo

                if (wins)
                {
                    WriteLine("Congratulations! You won!");
                    balance += (bet * 2);
                    Methods.Deposit(balance);
                    WriteLine($"You won {bet * 2} and your balance now is {balance}"); // balance + (bet x 2) = new balance

                }
                else
                {
                    WriteLine("Oh no! You lost!");
                    balance -= (bet * 2);
                    Methods.Deposit(balance);
                    WriteLine($"You lost {bet * 2} and your balance now is {balance}"); // balance - (bet x 2) = new balance
                }

                WriteLine("Do you want to play again? y / n");
                string? userInput = ReadLine();
                if (userInput == "Y" || userInput == "y")
                {
                    playAgain = true; // the user plays again
                }
                else
                {
                    playAgain = false; // the user is directed back to main menu to chose another game or quit
                    Methods.Start(); // Change to Login.Redirect()
                    //Login.Redirect();
                    return;
                }
            } while (playAgain == true && balance > 0); // play again and user needs also have some balance left

            static bool WinInSomeCases(string[] result)
            {
                string[][] winningCombinations = {
                new string[] { "!", "!", "!" }, // winning combo = ! | ! | !
                new string[] { "$", "$", "$" }, // winning combo = $ | $ | $
                new string[] { "&", "&", "&" }, // winning combo = & | & | &
            };
                foreach (var combination in winningCombinations)
                {
                    bool isWinningCombination = true;
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (result[i] != combination[0])
                        {
                            isWinningCombination = false; // there wasn't a winning combo
                            break;
                        }
                    }
                    if (isWinningCombination)
                    {
                        return true; // there was a winning combo
                    }
                }
                return false; // no winning combo
            }
        }
    }
}
