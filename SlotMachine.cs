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

                //Parse string input from user to int
                input = ReadLine();
                while (!int.TryParse(input, out bet))
                {
                    WriteLine("Oh no! Something went horribly wrong!");
                    input = ReadLine();
                    // forever loop, needs fixing!
                }
                int.TryParse(input, out bet);
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
                // sleep for 2 sek to build suspension
                //Thread.Sleep(2000);
                WriteLine(string.Join(" | ", result));

                int wins = WinInSomeCases(result);

                if (wins > 0)
                {
                    WriteLine("Congratulations! You won!");
                    //winnings = 20; dkjdfisdjfilsdjf
                    //int newBalanceWin = balance + winnings - bet;
                    //balance = balance + winnings - bet;
                    balance += 100 - bet;
                    Methods.Deposit(balance);
                    WriteLine($"You won 100 and your balance now is {balance}");

                }
                else
                {
                    WriteLine("Oh no! You lost!");
                    balance -= 50 - bet;
                    Methods.Deposit(balance);
                    WriteLine($"You lost 50 and your balance now is {balance}");
                }

                WriteLine("Do you want to play again? y / n");
                string? userInput = ReadLine();
                if (userInput == "Y" || userInput == "y")
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                    // go back to main menu to chose another game or quit
                }
            } while (playAgain == true && balance > 0);

            static int WinInSomeCases(string[] result)
            {
                string[][] winningCombinations = {
                new string[] { "!", "!", "!" },
                new string[] { "$", "$", "$" },
                new string[] { "&", "&", "&" },
            };
                // doesn't read the winning here, fix or take out of the function
                int[] winnings = { 10, 50, 100 };

                for (int i = 0; i < winningCombinations.Length; i++)
                {
                    if (result[0] == winningCombinations[i][0] &&
                        result[1] == winningCombinations[i][1] &&
                        result[2] == winningCombinations[i][2])
                    {
                        return winnings[i];
                    }
                }
                // If the player lost, return
                return 0;
            }
        }
    }
}
