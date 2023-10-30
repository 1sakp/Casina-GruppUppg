using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casina_GruppUppg
{
    public class Crapsgame
    {
        static public void Main()
        {
            int balance = Methods.GetBal();
            Random random = new Random();
            int point = 0;   // Här lagrar vi "point," som används för att avgöra om spelaren vinner på efterföljande kast.
            bool hasWon = false;  // En variabel för att hålla reda på om spelaren har vunnit.

            WriteLine("Välkommen till Craps-spelet!");

            while (true)  // Huvudspelloopen som gör att spelet fortsätter tills spelaren väljer att sluta.
            {
                balance = Methods.GetBal();
                WriteLine($"Du har {balance}");

                    if (balance == 0 || balance < 0)
                    {
                        Methods.NoCash();
                    }
                    

                    WriteLine("Tryck på Enter för att kasta tärningarna...");
                ReadLine();

                int dice1 = random.Next(1, 7);  // Slumpmässigt kast av tärning 1 (1-6).
                int dice2 = random.Next(1, 7);  // Slumpmässigt kast av tärning 2 (1-6).
                int sum = dice1 + dice2;  // Beräknar summan av de två tärningskasten.

                WriteLine($"Du kastade {dice1} och {dice2} - Summa: {sum}");

                if (point == 0)// Första tärningskastet
                {
                    if (sum == 7 || sum == 11)
                    {
                        WriteLine("Du har vunnit!");
                        hasWon = true;  // Om summan är 7 eller 11, har spelaren vunnit.
                        balance += 100;
                        Methods.Deposit(balance); // Vinsten läggs till
                        WriteLine($"Du har {balance}");

                    }
                    else if (sum == 2 || sum == 3 || sum == 12)
                    {
                        WriteLine("Du har förlorat!");
                        hasWon = false;  // Om summan är 2, 3 eller 12, har spelaren förlorat.
                        balance -= 50;
                        Methods.Deposit(balance); // Förlusten dras av 
                        WriteLine($"Du har {balance}");

                    }
                    else
                    {
                        point = sum;  // Om summan inte är 7, 11, 2, 3 eller 12 sätter vi "point" till summan.
                        WriteLine($"Poäng satt till {point}"); 
                    }
                }
                else // andra tärningskastet
                {
                    if (sum == point)
                    {
                        WriteLine("Du har vunnit!");
                        hasWon = true;  // Om summan är samma som "point," har spelaren vunnit.
                        balance += 100;
                        Methods.Deposit(balance); // Vinsten läggs till
                        WriteLine($"Du har {balance}");

                    }
                    else if (sum == 7)
                    {
                        WriteLine("Du har förlorat!");
                        hasWon = false;  // Om summan är 7, har spelaren förlorat.
                        balance -= 50;
                        Methods.Deposit(balance); // Förlusten dras av
                        WriteLine($"Du har {balance}");
                        
                    }
                } 

                if (hasWon)
                {
                    WriteLine("Grattis! Vill du spela igen? (Ja/Nej)");
                    string playAgain = ReadLine().ToLower();// Konvertera inmatningen till små bokstäver.


                    if (playAgain.ToLower() == "ja")
                    {  // för att konvertera inmatningen i variabeln playAgain till små bokstäver.
                        Main();
                        break;  // Om spelaren har vunnit och inte vill spela igen, bryter vi loopen.
                    }
                    else if (playAgain.ToLower() == "nej")
                    {
                        WriteLine("Tack för att du spelade. Spelet avslutas.");
                       
                        break;
                    }

                    else
                    {
                        WriteLine("Ogiltig inmatning. Spelet avslutas.");
                        Main();
                        break;
                    }
                }
                else
                {
                    balance -= 50;
                    Methods.Deposit(balance);
                    WriteLine($"Du har {balance}");


                    WriteLine("otur! Vill du spela igen? (Ja/Nej)");
                    string playAgain = ReadLine();


                    if (playAgain.ToLower() == "ja")
                    {
                        point = 0;
                        hasWon = false;
                        Console.Clear();
                        Main();

                    }
                    if (playAgain.ToLower() == "nej")
                    {
                        WriteLine("Tack för att du spelade!");
                        LoginClass.Redirect();
                        break;
                    }
                    else
                    {
                        WriteLine("Ogiltig inmatning. Spelet avslutas.");
                        Main();
                        break;
                    }

                }
            }

        }
    }
}