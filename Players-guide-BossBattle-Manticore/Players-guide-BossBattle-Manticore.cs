using System.Runtime.CompilerServices;

namespace Players_guide_BossBattle_Manticore;

class Program
{
    static void Main(string[] args)
    {
        int AskForNumber(string text) // Method to ask for a player's number
        {
            Console.Write(text + " ");
            int number = Convert.ToInt32(Console.ReadLine());
            return number;
        }

        int AskForNumberInRange(string text, int min, int max) // Method to ask for Player 1's number
        {
            while(true)
            {
                int number = AskForNumber(text);
                if(number >= min && number <= max)
                    return number;
            }
        }

        int Damage(int i) // Method to figure out how much damage can be done during the current round if User 2 makes the right guess.
        {
            int damage = 0;
            if(i % 3 == 0 && i % 5 == 0)
            {
                damage = 10;
            }
            else if(i % 3 == 0)
            {
                damage = 3;
            }
            else if(i % 5 == 0)
            {
                damage = 3;
            }
            else
            {
                damage = 1;
            }

            return damage;
        }


        int number = AskForNumberInRange("Player 1, how far - between the range of 0 and 100 - do you want to station Manticore?", 0, 100);

        Console.Clear();

        Console.WriteLine("Player 2, it's your turn.");
        
        while(true)
        {
            int manticorePoints = 10;
            int cityPoints = 15;

            for(int i = 1; i <= 100; i++)
            {
            Console.Write("-----------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"STATUS:  Round: {i}  City: {cityPoints}/15  Manticore: {manticorePoints}/10" +
            $"\nThe cannon is expected to deal " + Damage(i) + " damage this round.");

            int guess = AskForNumber("Enter the desired cannon range: "); 
            
            if(guess > number) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("That round OVERSHOT the target.");
                cityPoints -= 1;
                Console.ResetColor();
            }
            else if (guess < number) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("That round FELL SHORT of the target.");
                cityPoints -= 1;
                Console.ResetColor();
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That round was a DIRECT HIT!");
                manticorePoints -= Damage(i);
                Console.ResetColor();
            }

            if(cityPoints <= 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("The city of Consolas has been annihilated. You lose.");
                Console.WriteLine();
                return;
            }
            else if(manticorePoints <= 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
                Console.WriteLine();
                return;
            }
        }
        
        }
    }
}
