using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSim2._0
{
    
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public abstract class Actor
    {
        //make variables for attack and chance
        public int attack = 0;
        public int chance = 0;
        //make random for attacks and chance
        public Random rng = new Random();
        //set Name, HP and Is alive as properties to use for actors
        public string Name { get; set; }
        public int HP { get; set; }
        public bool IsAlive
        {
            get
            {
                //if health more than 0 return true else return false
                return this.HP > 0;
            }
        }
        //make Attack method
        public virtual int Attack(Actor actor);
        //make constructor 
        public Actor(string name, int hp) 
        {
            this.Name = name;
            this.HP = hp;
        }

    }
    public class Enemy : Actor
    {
        //method for enemy attack
        public override int Attack(Actor actor)
        {
            attack = rng.Next(15, 26);
            chance = rng.Next(1, 11);
            if (chance > 8)
            {
                actor.HP -= attack;
                Console.WriteLine("{0} has hit {1} for {2} HP!",this.Name, actor.Name, attack);
                return attack;
            }
            Console.WriteLine("You dodge {0}'s attack",this.Name);
            return 0;
        }
        //build enemy constuctor that implements base 
        public Enemy(string enemy, int hp) : base(enemy,hp)
        {
            
        }
    }
    public class Player : Actor
    {
        enum AttackType
        {
            Sword = 1,
            Magic,
            Heal,
            fail
        }
        public override int Attack(Actor actor)
        {
            //set chooseattack to a variable to compare
            AttackType choosenAttack = ChooseAttack();
            switch (choosenAttack)
            {
                case AttackType.Sword:
                    attack = rng.Next(25,36);
                    chance = rng.Next(1,11);
                    if (chance <= 7)
                    {
                        actor.HP -= attack;
                        Console.WriteLine("{0} has hit {1} for {2} HP!", this.Name, actor.Name, attack);
                        return attack;   
                    }
                Console.WriteLine("You dodge {0}'s attack",this.Name);
                return 0;
                case AttackType.Magic:
                    attack = rng.Next(10, 16);
                    actor.HP -= attack;
                    Console.WriteLine("{0} has hit {1} for {2} HP!", this.Name, actor.Name, attack);
                    return attack; 
                case AttackType.Heal:
                    attack = rng.Next(10, 21);
                    this.HP += attack;
                    Console.WriteLine("{0} has healed for {1} HP");
                    return attack;
                case AttackType.fail:
                    attack = rng.Next(5, 11);
                    this.HP -= attack;
                    Console.WriteLine("{0} tripped over a rock and took {1} damage...Nice Job!");
                    return attack;

                    
                    
            }
            return 0;
        }
        private AttackType ChooseAttack()
        {
            //make isNumber for consolereadline and input
            int isNumber = 0;
            Console.Write("Select your weapon");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput,out isNumber))
            {
                switch (isNumber)
                {
                    case 1:
                       return AttackType.Sword;
                    case 2:
                       return AttackType.Magic;
                    case 3:
                       return AttackType.Heal;
                }
            }
                Console.WriteLine("Invalid Input Jerk");
                return AttackType.fail;
        }
        public Player(string player, int hp) : base(player, hp)
        {

        }
    }
    public class Game
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }
        public void DisplayCombatInfo
        {
            Console.WriteLine("{0} Health remaining: {1}",, );
        }
        
        public Game()
        {
            this.Player = new Player("Colton",100);
            this.Enemy = new Enemy("Enemy", 200);
        }
    }
}
