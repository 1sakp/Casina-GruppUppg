﻿using System;
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
            int balance = Methods.GetBal(); // get the saved balance from the user login
            int bet;
            int numberOfReels = 3;

            bool playAgain;

            string? input;
            string[] result = new string[numberOfReels];
            string[] symbols = { "!", "$", "&" };
            Random rand = new();

            WriteLine("You found a Slot Machine!\n");

            do
            {
                WriteLine($"You have: {balance} kr in balance\n");
                WriteLine("Place your bet: ");
                input = ReadLine();

                // Check if user did not put int for input || is overbetting his balance || betting less than 0 or 0
                while (!int.TryParse(input, out bet) || bet > balance || bet < 0 || bet == 0)
                {
                    if (!int.TryParse(input, out bet))
                    {
                        WriteLine("Oh no! You need to write a number: ");
                        input = ReadLine();
                    }
                    else if (bet > balance)
                    {
                        WriteLine("Oh no! You don't have that kind of money, enter a bet under your balance: ");
                        input = ReadLine();
                    }
                    else
                    {
                        WriteLine("Oh no! You cannot bet below 0, bet over 0 please: ");
                        input = ReadLine();
                    }
                }
                int.TryParse(input, out bet); //Parse string input from user to int
                WriteLine($"You bet: {bet}");

                WriteLine("Ready to play? Press enter to spin...");
                ReadLine();

                for (int i = 0; i < numberOfReels; i++)
                {
                    if (rand.Next(100) < 25) // 25% chance of winning
                    {
                        result[i] = "!"; // outcome: !!!
                    }
                    else if (rand.Next(100) < 25) // 25% chance of winning
                    {
                        result[i] = "$"; // outcome: $$$
                    }
                    else if (rand.Next(100) < 25) // 25% chance of winning
                    {
                        result[i] = "&"; // outcome: &&&
                    }
                    else
                    {
                        result[i] = symbols[rand.Next(symbols.Length)]; // no winning combo
                    }
                }

                WriteLine("The wheel is spinning...");
                Thread.Sleep(1000); // sleep for 1 sek to build suspension
                WriteLine(string.Join(" | ", result)); // make the display more readable with | inbetween the symbols

                bool wins = WinInSomeCases(result); // call the WinInSomeCases function to check if it's a match for winning combo

                if (wins)
                {
                    WriteLine("Congratulations! You won!");
                    balance += bet;
                    Methods.Deposit(balance);
                    WriteLine($"You won {bet} and your balance now is {balance}"); // balance + bet = the new balance

                }
                else
                {
                    WriteLine("Oh no! You lost!");
                    balance -= bet;
                    Methods.Deposit(balance);
                    WriteLine($"You lost {bet} and your balance now is {balance} \n"); // balance - bet = the new balance

                    if (balance < 0 || balance == 0)
                    {
                        Methods.NoCash(); // call the NoCash() method when user has no more cash to deposit more money
                    }
                }

                WriteLine("Do you want to play again? y / n");
                string? userInput = ReadLine();
                if (userInput == "Y" || userInput == "y")
                {
                    playAgain = true; // the user plays again
                }
                else
                {
                    playAgain = false;
                    LoginClass.Redirect(); // the user is directed back to main menu to chose another game
                    return;
                }
            } while (playAgain == true && balance > 0); // play again and user needs also have some balance over 0
        }

        public static bool WinInSomeCases(string[] result)
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
