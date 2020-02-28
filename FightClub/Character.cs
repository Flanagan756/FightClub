﻿using System;
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
    public class Character
    {
        /*Properties*/
        public string Name { get; set; }
        public int AC { get; set; } /*Armor Class*/
        public int HP { get; set; } /*Hit Points*/
        public int Dex { get; set; } /*Dexterity*/

        public string Description { get; set; }

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
        }
        //Character Build with Description
        public Character(string name, int ac, int hp, int dex, string description)
        {
            Name = name;
            AC = ac;
            HP = hp;
            Dex = dex;
            Description = description;

        }
        /*Methods*/
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Name, AC, HP, Dex);
        }
    }
    #endregion
    #region Hero
    public class Hero : Character
    {
        /*Properties*/
        public Classes PlayerClass { get; set; }       

        /*Constructors*/
        public Hero(string name, int ac, int hp, Classes playerClass, int dex)
        {
            Name = name;
            AC = ac;
            HP = hp;
            PlayerClass = playerClass;
            Dex = dex;
            Description = "No Description";

        }
        public Hero(string name, int ac, int hp, Classes playerClass, int dex, string description)
        {
            Name = name;
            AC = ac;
            HP = hp;
            PlayerClass = playerClass;
            Dex = dex;
            Description = description;

        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Name, AC, HP, Dex);
        }
    }
    #endregion

}
