using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub
{
    /*Enums*/
    public enum Classes
    {
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Figther,
        Monk,
        Paladin,
        Ranger,
        Rouge,
        Sorcerer,
        Warlock,
        Wizard

    }
    public class Character
    {
        //Properties
        public string Name { get; set; }
        public int AC { get; set; } /*Armor Class*/
        public int HP { get; set; } /*Hit Points*/
        public int Dex { get; set; } /*Dexterity*/

        //Constructor
        public Character()
        {

        }
          
        public Character(string name, int ac, int hp, int dex)
        {
            Name = name;
            AC = ac;
            HP = hp;
            Dex = dex;
        }
        //Methods
        public override string ToString()
        {
            return$"{Name} {AC} {HP} {Dex}";
        }
    }
    public class Hero : Character
    {
        //Properties
        public Classes PlayerClass { get; set; }

        //Constructor
        public Hero(string name, int ac, int hp, Classes playerClass, int dex)
        {
            Name = name;
            AC = ac;
            HP = hp;
            PlayerClass = playerClass;
            Dex = dex;
        }
        public override string ToString()
        {
            return$"{Name} {AC} {HP} {Dex} {PlayerClass}";
        }
    }

}
