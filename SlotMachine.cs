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
            //GetBal() - put in method to read the login user balance
            // bal - read the balance
            int bet;
            int winnings;
            int numberOfReels = 3;

            bool playAgain;

            string? input;
            string[] result = new string[numberOfReels];
            // symbols - add more later?
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
                    //winnings = 20;
                    //int newBalanceWin = balance + winnings - bet;
                    //balance = balance + winnings - bet;
                    
                    //Methods.Deposit(balance + 100);
                    //WriteLine($"You won 100 and your balance now is {balance}");

                }
                else
                {
                    WriteLine("Oh no! You lost!");
                    //balance = balance - bet;
                    //WriteLine($"You lost {bet} and your balance now is {balance}");
                    //Methods.Deposit(balance + 100);
                }

                // Send a message to user when he has no balance left and kick him out of the game - not working
                //if (balance <= 0)
                //{
                //    WriteLine("You are a pennyless chap, get out!");
                //    return;
                //}

                WriteLine("Do you want to play again? y / n");
                string? userInput = ReadLine();
                if (userInput == "Y" || userInput == "y")
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                    balance = new Deposit();
                    WriteLine($"Welcome back! Your balance is now: {balance}");

                    // go out of game with balance saved
                    // Deposit()
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
