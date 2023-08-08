using System;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {

        public static Character GetNewEnemy(int level)
        {
            string[] subjects = { "Orc", "Witch", "Wizzard", "Bear", "King" };
            string[] adjectives = { "Metal", "Fire", "Poison", "Water", "Darkness", "Veganism", "Death" };
            string[] roles = { "Mague", "Rogue", "Warrior" };

            Random number = new Random();
            string name = "The " + subjects[number.Next(0, subjects.Length)] + " " + adjectives[number.Next(0, adjectives.Length)];
            string rol = roles[number.Next(0, roles.Length)];

            return new Character(name, rol, "nothing", 3 * level, level);

        }
        /**  private static bool SetTurn(int playerHealth, int enemyHealth)
          {
              if (playerHealth > enemyHealth) return true;
              else return false;
          }**/
        static void Main()
        {
            Console.WriteLine("Write your first name: \t");
            string firstName = Console.ReadLine()!;
            Console.WriteLine("Hi, " + firstName + "! \n♥♥♥♥♥");

            DateTime time = DateTime.Now;
            Console.WriteLine("\nInitialized on " + time);

            Console.WriteLine("\nNow, What's your last Name?: \t");
            string lastName = Console.ReadLine()!;
            Console.WriteLine("How old are you?: \t");
            string age = Console.ReadLine()!;
            Console.Write("Do you know programming?");
            Console.WriteLine(" Type Yes/No");
            string develop = Console.ReadLine()!;

            Console.WriteLine($"\nYour information:");
            Console.WriteLine($"\tFirst Name: {firstName}\n\tLast Name: {lastName}\n\tAge: {age}\n\tDevelop: {(develop == "Yes" || develop == "yes")}");


            Console.WriteLine("Please, select your character");

            Character rabina = new Character("Rabina", "Mage", "magic wand", 25, 1);
            Character dogi = new Character("Dogi", "Rogue", "daggers", 10, 1);
            Character domini = new Character("Domini", "Warrior", "sword", 35, 1);

            Console.WriteLine("1." + domini.Name);
            Console.WriteLine("2." + dogi.Name);
            Console.WriteLine("3." + rabina.Name);

            int playerSelect = 0;
            try
            {
                playerSelect = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
            }

            Character player;
            if (playerSelect == 1)
            {
                Console.WriteLine("\nDomini has been selected\n");
                player = domini;
            }
            else if (playerSelect == 2)
            {
                Console.WriteLine("\nDogi has been selected\n");
                player = dogi;
            }
            else if (playerSelect == 3)
            {
                Console.WriteLine("\nRabina has been selected\n");
                player = rabina;
            }
            else
            {
                Console.WriteLine("Invalid selection. Defaulting to Domini.");
                player = domini;
            }

            Console.WriteLine("\nShort guide of the game:");
            Console.WriteLine("\nFor each level, the enemies spawn randomly. \n The range of strength and lives increment. \n How many rounds will you survive?\n");

            Console.WriteLine("\n--------------Level 1--------------------\n");

            Character enemyLvl1 = GetNewEnemy(1);
            Console.WriteLine($"New enemy: {enemyLvl1.Name}, Role: {enemyLvl1.Rol}, Health: {enemyLvl1.Health}");

            Console.WriteLine("Your journey begins!\n");

            while (player.AreAlive)
            {
   
            
                Console.WriteLine("Your turn\n");
                Console.WriteLine(@" 
                               1. Atack.
                               2. Deffend.");
                int action = int.Parse(Console.ReadLine());
                Random accert = new Random();

                 if (action == 1)
                {
                    Console.WriteLine("--attack--\n");
                   int damage = player.Attack(accert, player);
                    enemyLvl1.TakeDamage(damage);
                    Console.WriteLine("New live of enemy: " + enemyLvl1.Health + " | " + "Lifes: " + enemyLvl1.Lifes);
                }
                else if (action == 2)
                {
                    int newArmor = player.Deffend(accert, player);
                    Console.WriteLine("New Armor: " + newArmor);

                }
            if(enemyLvl1.AreAlive)
            {
                Console.WriteLine("Turn of enemy\n");
                Random number = new Random();
               int autoAction = number.Next(1, 2);
                //Random accert1 = new Random();//

                if (autoAction == 1) 
                {
                    Console.WriteLine("--enemy attack--\n");
                    int damage = enemyLvl1.Attack(accert, enemyLvl1);
                    player.TakeDamage(damage);
                    Console.WriteLine("New live of you: " + player.Health + " | " + "Lifes: " + player.Lifes);

                }
                else if (autoAction == 2) 
                {
                        Console.WriteLine("--enemy deffend--\n");
                    int newArmor = enemyLvl1.Deffend(accert, enemyLvl1);
                    Console.WriteLine("New Armor: " + newArmor);
                }

            }
               Character enemyLvl2 = GetNewEnemy(2);
                Console.WriteLine($"You defeated {enemyLvl1.Name}! A new enemy has appeared.");
                Console.WriteLine($"New enemy: {enemyLvl2.Name}, Role: {enemyLvl2.Rol}, Health: {enemyLvl2.Health}");

            }
            Console.WriteLine("Game over. You have been defeated.");
        }
    }
}
