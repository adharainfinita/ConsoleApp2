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
            string[] weapons = { "sword", "magic wand", "daggers", "nothing" };

            Random number = new Random();
            string name = "The " + subjects[number.Next(0, subjects.Length)] + " " + adjectives[number.Next(0, adjectives.Length)];
            string rol = roles[number.Next(0, roles.Length)];
            string weapon = weapons[number.Next(0, weapons.Length)];

            int armor = 50 + level * 10;

            return new Character(name, rol, weapon, armor, level);

        }
        public static Character GetCharacter(string name, int level)
        {
            string[] roles = { "Mague", "Rogue", "Warrior" };
            string[] weapons = { "sword", "magic wand", "daggers", "nothing" };

            Random number = new Random();
            string rol = roles[number.Next(0, roles.Length)];
            string weapon = weapons[number.Next(0, weapons.Length)];

            int armor = 30 + level * 10;

            return new Character(name, rol, weapon, armor, level);
        }
        static void Main()
        {
            Console.WriteLine("Write your name: \t");
            string firstName = Console.ReadLine()!;
            Console.WriteLine("Hi, " + firstName + "! \n♥♥♥♥♥");

            DateTime time = DateTime.Now;
            Console.WriteLine("\nInitialized on " + time);
          

            //Selección de personaje
            Console.WriteLine("Please, select your character");


            Character rabina = GetCharacter("Rabina", 1);
            Character dogi = GetCharacter("Dogi", 1);
            Character domini = GetCharacter("Domini", 1);

            Console.WriteLine("1." + domini.Name);
            Console.WriteLine("2." + dogi.Name);
            Console.WriteLine("3." + rabina.Name);

            int playerSelect = 0;

            //Si no introducimos un caracter válido (1, 2 0 3) el sistema nos seleccionará automáticamente 1
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

                //Vemos las estadísticas que tocó con ese pj.
                //Es aleatorio, por lo que puede tocarnos un buen o mal set.

                Console.WriteLine($@"...Stats...
                          Health: {player.Health}
                          Power: {player.Power}
                          Rol: {player.Rol}
                          Weapon: {player.Weapon}
                          Armor: {player.Armor}");
            }
            else if (playerSelect == 2)
            {
                Console.WriteLine("\nDogi has been selected\n");
                player = dogi;
                Console.WriteLine($@"...Stats...
                          Health: {player.Health}
                          Power: {player.Power}
                          Rol: {player.Rol}
                          Weapon: {player.Weapon}
                          Armor: {player.Armor}");
            }
            else if (playerSelect == 3)
            {
                Console.WriteLine("\nRabina has been selected\n");
                player = rabina;
                Console.WriteLine($@"...Stats...
                          Health: {player.Health}
                          Power: {player.Power}
                          Rol: {player.Rol}
                          Weapon: {player.Weapon}
                          Armor: {player.Armor}");
            }
            else
            {
                Console.WriteLine("Invalid selection. Defaulting to Domini.");
                player = domini;
            }

            Console.WriteLine("\nSHORT GUIDE OF THE GAME:");
            Console.WriteLine("\nFor each level, the enemies spawn randomly. " +
                "\n The range of HEALTH and POWER increment.\n Your character not. But if you get +95% in attack" +
                "the POWER incement." +
                "\n\t\t\tHow many rounds will you survive?\n\n");

            int level = 1;
            int turns = 1;

            Console.WriteLine("+++++Your journey begins!+++++\n");

            //Se genera un nuevo enemigo.
            Character enemyLvl1 = GetNewEnemy(level);
            Console.WriteLine($"\n--------------Level {level}--------------------\n");
            Console.WriteLine($"New enemy: {enemyLvl1.Name}, Role: {enemyLvl1.Rol}, Health: {enemyLvl1.Health}");

            //Este será el flujo del juego. Mientras tu personaje viva, continuará.
            while (player.AreAlive)
            {

                Console.WriteLine("\n\t\t<<< Turn n°" + turns + " >>>>\n");

                //Muestra las stats de ambos contrincantes
                Console.WriteLine($"Your state... Health: {player.Health} | Armor: {player.Armor} | Power: {player.Power}\n");
                Console.WriteLine($"Enemy state... Health: {enemyLvl1.Health} | Armor: {enemyLvl1.Armor} | Power: {enemyLvl1.Power}\n");

                Console.WriteLine("\nYour turn.\n");
                Console.WriteLine(@" 
                               1. Atack.
                               2. Deffend.
                               3. Complete guide");


                try
                {
                    int action = int.Parse(Console.ReadLine());

                    //Se obtiene un número aleatorio para definir el acierto de la tirada del pj
                    Random accert = new Random();


                    if (action == 1)
                    {
                        Console.WriteLine("--attack--\n");

                        
                        int damage = player.Attack(accert, player.Power);
                        enemyLvl1.TakeDamage(damage);
                        Console.WriteLine($"Damage: {damage}");
                        Console.WriteLine("New live of enemy: " + enemyLvl1.Health + " | " + "Lifes: " + enemyLvl1.Lifes);
                    }
                    else if (action == 2)
                    {
                        Console.WriteLine("--deffend--\n");
                        int newArmor = player.Deffend(accert, player.Armor);
                        player.Armor = newArmor;
                        Console.WriteLine("New Armor: " + newArmor);

                    }
                    else if(action == 3) {
                        Console.WriteLine("\tWelcome " + firstName);
                        Console.WriteLine("-SPA-");
                        Console.WriteLine("*El rol y el arma de tu personaje se generá de manera aleatoria. Esto brinda posibilidades\n buenas y malas, ya que cada rol tiene un arma preferida.");
                        Console.WriteLine("*Tu personaje no sube de nivel");
                        Console.WriteLine("*Si obtienes 70% de éxito 0 más tu ataque se duplica.");
                        Console.WriteLine("*Si obtienes 95% de éxito o más tu ataque se triplica.");
                        Console.WriteLine("*Al defender, también se genera un porcentaje de éxito. Este sirve para proteger tu vida");
                        Console.WriteLine("Si la armadura es mayor al daño recibido, ésta absorbe el daño. Si se agota-inclusivo en la misma acción");
                        Console.WriteLine("el resto lo recibirá la vida.");
                        Console.WriteLine("Al derrotar a un enemigo, tu poder aumenta levemente.\n\n");
                        Console.WriteLine("-ENG-");

                        Console.WriteLine("*Your character's role and weapon will be generated randomly. This gives good and bad\n possibilities, as each role has a preferred weapon.");
                        Console.WriteLine("*Your character doesn't level up");
                        Console.WriteLine("*If you get 70% success or more your attack is doubled.");
                        Console.WriteLine("*If you get 95% success or more your attack is tripled.");
                        Console.WriteLine("*When defending, a success rate is also generated. This is used to protect your life");
                        Console.WriteLine("If the armor is greater than the damage taken, it absorbs the damage. If it runs out-even in the same action");
                        Console.WriteLine("life will receive the rest.");
                        Console.WriteLine("When you defeat an enemy, your power is slightly increased.\n\n");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                //Acciones del enemigo
                if (enemyLvl1.AreAlive)
                {
                    Console.WriteLine("\nTurn of enemy.\n");

                    Random accert = new Random();
                    Random number = new Random();
                    int autoAction = number.Next(1, 3);

                    if (autoAction == 1)
                    {
                        Console.WriteLine("--enemy attack--\n");
                        int damage = enemyLvl1.Attack(accert, enemyLvl1.Power);
                        player.TakeDamage(damage);
                        Console.WriteLine($"Damage: {damage}");
                        Console.WriteLine("New live of you: " + player.Health + " | " + "Lifes: " + player.Lifes);

                    }
                    else if (autoAction == 2)
                    {
                        Console.WriteLine("--enemy deffend--\n");
                        int newArmor = enemyLvl1.Deffend(accert, enemyLvl1.Armor);
                        enemyLvl1.Armor = newArmor;
                        Console.WriteLine("New Armor: " + newArmor);
                    }

                }
                else
                {
                    Console.WriteLine($"You defeated {enemyLvl1.Name}! A new enemy has appeared.");
                    player.Power += 5;
                    level++;
                    Console.WriteLine($"\n--------------Level {level}--------------------\n");

                    enemyLvl1 = GetNewEnemy(level);
                    Console.WriteLine($"New enemy: {enemyLvl1.Name}, Role: {enemyLvl1.Rol} , Health: {enemyLvl1.Health}");
                }
                turns++;
            }
            Console.WriteLine("Game over. You have been defeated.");
        }
    }
}
