public class Character
{
    public Character(string name, string rol, string weapon, int armor)
    {
        Name = name;
        Weapon = weapon;
        Rol = rol;
        Armor = armor;
        Power = GetPower(weapon, rol);
        Health = GetHealth(50, armor, rol); // Valor inicial de salud (por ejemplo)
        Lifes = 3; // Cantidad inicial de vidas (por ejemplo)
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

    public void TakeDamage(int damage) {

        Health -= damage;
        
        if(Health <= 0 ){
            Health = 0;
            Lifes --;
            if(Lifes <= 0){
                AreAlive = false;
            }
            else {
                Health = 100;
            }
        }
    }
    private int GetHealth(int health, int armor, string rol){

        switch(rol)
        {
            case "Warrior":
            health =+10;
            break;

            case "Mage":
            health =+ 5;
            break;

            case "Rogue":
            health +=1;
            break;
        }
    return health += armor;
    }
    
    private int GetPower(string weapon, string rol){
        int power = 10;
        switch(weapon){
            case "sword":
            power+=10;
            if(rol == "Warrior") power+=10;
            break;

            case "magic wand":
            power +=5;
            if(rol == "Mage") power+=15;
            break;

            case "daggers":
            power +=3;
            if(rol =="Rogue") power +=17;
            break;
        }
        return power;
    }
}
