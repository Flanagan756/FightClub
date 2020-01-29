using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FightClub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Character> combat = new List<Character>();
        public MainWindow()
        {
            InitializeComponent();

            //Create Enemies
            Character enemy1 = new Character("Red Dragon", 19, 256, 16);
            Character enemy2 = new Character("Skeleton1", 13, 13, 18);
            Character enemy3 = new Character("Skeleton2", 13, 13, 9);

            //Create Heros
            Hero hero1 = new Hero("Yosef Bolof",14,22,Classes.Barbarian,2);
            Hero hero2 = new Hero("MitaK", 17, 25, Classes.Paladin, 11);
            Hero hero3 = new Hero("Sticks the Undead", 9, 11, Classes.Bard, 20);
            Hero hero4 = new Hero("Leon Swampson", 15, 18, Classes.Druid, 17);

            //Add all Characters to the combat List
            combat.Add(enemy1);
            combat.Add(enemy2);
            combat.Add(enemy3);

            combat.Add(hero1);
            combat.Add(hero2);
            combat.Add(hero3);
            combat.Add(hero4);

            //Display the combat list in the combat listbox
            lbxCombat.ItemsSource = combat;




        }
    }
}
