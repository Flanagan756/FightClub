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
    #region Character
    public class Character : IComparable<Character>
    {
        /*Properties*/
        public string Name { get; set; }
        public int AC { get; set; } /*Armor Class*/
        public int HP { get; set; } /*Hit Points*/
        public int Dex { get; set; } /*Dexterity*/
        public string Description { get; set; }

        public string CharacterImage { get; set; }

        /*Constructors*/

        //Default Constructor
        public Character()
        {

        }
        //Basic Character Build 
        public Character(string name, int ac, int hp, int dex)
        {
            Name = name;
            AC = ac;
            HP = hp;
            Dex = dex;
            Description = "No Description";
            CharacterImage = "https://dndcharacters.s3-eu-west-1.amazonaws.com/Monsters/DefaultMonster.jpg";
        }
        //Character Build with Description
        public Character(string name, int ac, int hp, int dex, string description)
        {
            Name = name;
            AC = ac;
            HP = hp;
            Dex = dex;
            Description = description;
            CharacterImage = "https://dndcharacters.s3-eu-west-1.amazonaws.com/Monsters/DefaultMonster.jpg";
        }
        //Character Build with Description and Image
        public Character(string name, int ac, int hp, int dex, string description, string characterimage)
        {
            Name = name;
            AC = ac;
            HP = hp;
            Dex = dex;
            Description = description;
            CharacterImage = characterimage;

        }

        /*Methods*/
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Name, AC, HP, Dex);
        }
        //Sorting based on Dex
        public int CompareTo(Character other)
        {
            int returnValue = this.Dex.CompareTo(other.Dex);

            return returnValue;


        }
    }
    #endregion
    #region Hero
    public class Hero : Character
    {
        /*Properties*/
        public Classes PlayerClass { get; set; }  
        public Classes ClassImage { get; set; }

        /*Constructors*/
        public Hero(string name, int ac, int hp, Classes playerClass, int dex)
        {
            Name = name;
            AC = ac;
            HP = hp;
            PlayerClass = playerClass;
            Dex = dex;
            Description = "No Description";
            CharacterImage = "https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Default.png";

        }
        public Hero(string name, int ac, int hp, Classes playerClass, int dex, string description)
        {
            Name = name;
            AC = ac;
            HP = hp;
            PlayerClass = playerClass;
            Dex = dex;
            Description = description;
            CharacterImage = "https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Default.png";

        }
        public Hero(string name, int ac, int hp, Classes playerClass, int dex, string description, string heroImage)
        {
            Name = name;
            AC = ac;
            HP = hp;
            PlayerClass = playerClass;
            Dex = dex;
            Description = description;
            CharacterImage = heroImage;
        }
  
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Name, AC, HP, Dex);
        }
    }
    #endregion
   
        


}
