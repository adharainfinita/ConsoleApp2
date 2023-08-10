

public class Character
{
    public Character(string name, string rol, string weapon, int armor, int level)
    {
        Name = name;
        Weapon = weapon;
        Rol = rol;
        Armor = armor;
        Power = GetPower(weapon, rol); //Función para definir el poder del personaje
        Health = GetHealth(level, armor, rol); // Valor inicial de salud
        Lifes = 3; // Cantidad inicial de vidas 
        AreAlive = true; // Establecer inicialmente como vivo
    }

    // Propiedades automáticas
    public string Name { get; set; }
    public int Health { get; set; }
    public string Rol { get; set; }
    public string Weapon { get; set; }
    public int Power { get; set; }
    public int Armor { get; set; }
    public int Lifes { get; set; }
    public bool AreAlive { get; set; }

    public void TakeDamage(int damage)
    {
        //Si la armadura es mayor al daño recibido, se le resta el daño a la armadura. Si la daña completamente
        // Se establece en 0 para no tener números negativos
        if (Armor > damage)
        {
            Armor -= damage;
            if (Armor < 0)
            {
                Armor = 0;
            }
        }
        else
        {
            //Sino al valor final del daño recibido se le restará el valor de la armadura, y allí aplicará a la vida
            damage -= Armor;
            Health -= damage;

            //Si la vida llega a cero, pierde una vida. 
            if (Health <= 0)
            {
                Health = 0;
                Lifes--;
                if (Lifes <= 0)
                {
                    AreAlive = false;
                }
                else
                {
                    Health = 100;
                }
            }
        }
    }
    private int GetHealth(int level, int armor, string rol)
    {
        int health = 50;

        //Un rol tiene más vida que otro
        switch (rol)
        {
            case "Warrior":
                health = +10;
                break;

            case "Mage":
                health = +5;
                break;

            case "Rogue":
                health += 1;
                break;
        }
        //La armadura y el nivel aumentan la vida
        return (health + armor) * level;
    }

    private int GetPower(string weapon, string rol)
    {
        int power = 10;

        //Cada rol tiene un arma preferida, que aumentará su poder

        switch (weapon)
        {
            case "sword":
                power += 10;
                if (rol == "Warrior") power += 10;
                break;

            case "magic wand":
                power += 5;
                if (rol == "Mage") power += 15;
                break;

            case "daggers":
                power += 3;
                if (rol == "Rogue") power += 17;
                break;

            case "nothing":
                power += 4;
                break;
        }
        return power;
    }


    public int Attack(Random accert, int power)
    {
        int successPercentage = accert.Next(0, 100);
        
        Console.WriteLine("Atack succesful: %" + successPercentage);
        
        //Si el porcentaje de éxito es mayor a 95, se genera un golpe crítico. Mayor a 70, un buen golpe. 
        if (successPercentage >= 95) power = (int)(power * (3 * successPercentage / 100.0));
        if (successPercentage >= 70) power = (int)(power * (2 * successPercentage / 100.0));
        if (successPercentage <70 &&  successPercentage > 0)
        {
            power = (int)(power * (1 + successPercentage / 100.0));
        }
        return power;
    }

    public int Deffend(Random accert, int armor)
    {

        //Acción que aumenta la armadura con una probabilidad de éxito.
        int successPercentage = accert.Next(10, 100);

        if (armor == 0)
        {
            armor = 15;
        }
        else
        {
            armor = (int)(armor * (1 + successPercentage / 100.0));
        }

        Console.WriteLine("Armor elevated: %" + successPercentage);
        return armor;
    }

}
