using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casina_GruppUppg

{// See https://aka.ms/new-console-template for more information
    using System;
    using static System.Console;

    class CrapsGame
    {
        static void Main()
        {
            Random random = new Random();
            int point = 0;   // Här lagrar vi "point," som används för att avgöra om spelaren vinner på efterföljande kast.
            bool hasWon = false;  // En variabel för att hålla reda på om spelaren har vunnit.

            WriteLine("Välkommen till Craps-spelet!\n");

            while (true)  // Huvudspelloopen som gör att spelet fortsätter tills spelaren väljer att sluta.
            {
                WriteLine("Tryck på Enter för att kasta tärningarna...");
                ReadLine();

                int dice1 = random.Next(1, 7);  // Slumpmässigt kast av tärning 1 (1-6).
                int dice2 = random.Next(1, 7);  // Slumpmässigt kast av tärning 2 (1-6).
                int sum = dice1 + dice2;  // Beräknar summan av de två tärningskasten.

                WriteLine($"Du kastade {dice1} och {dice2} - Summa: {sum}");

                if (point == 0)
                {
                    if (sum == 7 || sum == 11)
                    {
                        WriteLine("Du har vunnit!");
                        hasWon = true;  // Om summan är 7 eller 11, har spelaren vunnit.
                    }
                    else if (sum == 2 || sum == 3 || sum == 12)
                    {
                        WriteLine("Du har förlorat!");
                        hasWon = false;  // Om summan är 2, 3 eller 12, har spelaren förlorat.
                    }
                    else
                    {
                        point = sum;  // Om summan inte är 7, 11, 2 eller 3, sätter vi "point" till summan.
                        WriteLine($"Poäng satt till {point}");
                    }
                }
                else
                {
                    if (sum == point)
                    {
                        WriteLine("Du har vunnit!");
                        hasWon = true;  // Om summan är samma som "point," har spelaren vunnit.
                    }
                    else if (sum == 7)
                    {
                        WriteLine("Du har förlorat!");
                        hasWon = false;  // Om summan är 7, har spelaren förlorat.
                    }
                }

                if (hasWon)
                {
                    WriteLine("Grattis! Vill du spela igen? (Ja/Nej)");
                    string playAgain = ReadLine();
                    if (playAgain.ToLower() != "ja") // för att konvertera inmatningen i variabeln playAgain till små bokstäver.
                        break;  // Om spelaren har vunnit och inte vill spela igen, bryter vi loopen.
                    else
                    {
                        point = 0;  // Återställer "point" och "hasWon" om spelaren vill spela igen.
                        hasWon = false;
                    }
                }
                else
                {
                    WriteLine("Försök igen. Tryck på Enter för att kasta tärningarna...");
                    ReadLine();
                }
            }
        }
    }
    internal class Craps
    {
    }
}
