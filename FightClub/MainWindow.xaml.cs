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
        //Lists
        List<Character> combat = new List<Character>();
        List<Character> selectedCharacter = new List<Character>();

        //Varibles
        int damage;
        public MainWindow()
        {
            InitializeComponent();

            //Create Enemies
            Character enemy1 = new Character("Red Dragon", 19, 256, 16, 
           "Red dragons, were covetous, evil creatures, interested only in their own well-being, vanity and the extension of their treasure hoards. They were supremely confident of their own abilities and were prone to making snap decisions without any forethought");
            Character enemy2 = new Character("Skeleton1", 13, 13, 18, "Skeletons were undead animated corpses similar to zombies, but completely devoid of flesh and did not feed on the living. They could be made from virtually any solid creature, and as such their size and power varied widely. In addition to the basic humanoid skeleton, there were also skeletons created from wolves, trolls, ettins and even giants.");
            Character enemy3 = new Character("Skeleton2", 13, 13, 9, "Skeletons were undead animated corpses similar to zombies, but completely devoid of flesh and did not feed on the living. They could be made from virtually any solid creature, and as such their size and power varied widely. In addition to the basic humanoid skeleton, there were also skeletons created from wolves, trolls, ettins and even giants.");

            //Create Heros
            Hero hero1 = new Hero("Yosef Bolof",14,22,Classes.Barbarian,2, "Yosef lived in seclusion – either in a sheltered community such as a monastery, or entirely alone – for a formative part of his life.In Yoself's time apart from the clamor of society, you found quiet, solitude, and perhaps some of the answers he was looking for.") ;
            Hero hero2 = new Hero("MitaK", 17, 25, Classes.Paladin, 11, "MitaK is a famed conquere of the land and shows no mercy to his enemies");
            Hero hero3 = new Hero("Sticks the Undead", 9, 11, Classes.Bard, 20, "A Undead Musician cursed to travel the land to finished some unfinished business so his soul can move on");
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
        private void RefreshScreen()
        {
            //Rereshes the screen
            lbxCombat.ItemsSource = null;
            lbxCombat.ItemsSource = combat;

        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character selectedCharacter = lbxCombat.SelectedItem as Character;


            if (selectedCharacter != null)
            {
                //Display activity in text box
                txtDescription.Text = selectedCharacter.Description;
            }
            
        }

        private void btnDamage_Click(object sender, RoutedEventArgs e)
        {
            Character selectedCharacter = lbxCombat.SelectedItem as Character;
            //Null Check
            if (selectedCharacter != null)
            {
                damage = int.Parse(txtbxDamage.Text);

                selectedCharacter.HP = (selectedCharacter.HP - damage);
                RefreshScreen();

            }

        }
    }
}
