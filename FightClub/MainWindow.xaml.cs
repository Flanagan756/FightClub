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
using System.Threading;

namespace FightClub
{
    /***Author: Harry Flanagan***/

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*Lists*/
        List<Character> combat = new List<Character>();
        List<string> dead = new List<string>();
        List<Character> selectedCharacter = new List<Character>();

        /*Varibles*/
        int damage;
        int heal;

        public MainWindow()
        {
            InitializeComponent();

            #region Create Characters
            //Create Enemies
            Character enemy1 = new Character("Red Dragon", 19, 256, 16,
           "Red dragons, were covetous, evil creatures, interested only in their own well-being, vanity and the extension of their treasure hoards. They were supremely confident of their own abilities and were prone to making snap decisions without any forethought");
            Character enemy2 = new Character("Skeleton1", 13, 13, 18, "Skeletons were undead animated corpses similar to zombies, but completely devoid of flesh and did not feed on the living. They could be made from virtually any solid creature, and as such their size and power varied widely. In addition to the basic humanoid skeleton, there were also skeletons created from wolves, trolls, ettins and even giants.");
            Character enemy3 = new Character("Skeleton2", 13, 13, 9, "Skeletons were undead animated corpses similar to zombies, but completely devoid of flesh and did not feed on the living. They could be made from virtually any solid creature, and as such their size and power varied widely. In addition to the basic humanoid skeleton, there were also skeletons created from wolves, trolls, ettins and even giants.");

            //Create Heros
            Hero hero1 = new Hero("Yosef Bolof", 14, 22, Classes.Barbarian, 2, "Yosef lived in seclusion – either in a sheltered community such as a monastery, or entirely alone – for a formative part of his life.In Yoself's time apart from the clamor of society, you found quiet, solitude, and perhaps some of the answers he was looking for.");
            Hero hero2 = new Hero("MitaK", 17, 25, Classes.Paladin, 11, "MitaK is a famed conquere of the land and shows no mercy to his enemies");
            Hero hero3 = new Hero("Sticks the Undead", 9, 11, Classes.Bard, 20, "A Undead Musician cursed to travel the land to finished some unfinished business so his soul can move on");
            Hero hero4 = new Hero("Leon Swampson", 15, 18, Classes.Druid, 17);
            #endregion

            #region Add Characters to List
            //Add all the Enemies(Chartacter Class) to the combat list
            combat.Add(enemy1);
            combat.Add(enemy2);
            combat.Add(enemy3);

            //Add all the heros (Character Subclass) to the combat list
            combat.Add(hero1);
            combat.Add(hero2);
            combat.Add(hero3);
            combat.Add(hero4);

            //Display all of the characters in the listboxes
            lbxCombat.ItemsSource = combat;
            lbxDeath.ItemsSource = dead;
            #endregion
        }

        #region Methods
        //Random Number Generator for dice
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        //Referesh Screen for upadting data
        private void RefreshScreen()
        {
            //Rereshes the screen
            lbxCombat.ItemsSource = null;
            lbxCombat.ItemsSource = combat;

            lbxDeath.ItemsSource = null;
            lbxDeath.ItemsSource = dead;

        }
        #endregion

        #region Combat_Tab

        /*Display Classes in listboxes*/
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character selectedCharacter = lbxCombat.SelectedItem as Character;
            Hero selectedHero = lbxCombat.SelectedItem as Hero;

            if (selectedCharacter != null) //Checks to see if the selected charcter isn't equal to null
            {
                //Display Class as enemy and the Discription in the discription text box
                txtClass.Text = "Enemy";
                txtDescription.Text = selectedCharacter.Description;
            }
            if (selectedHero != null) //Checks to see if the selected character isn't null and is of the subclass Hero
            {
                //Display the selected Hero's class property and the discription in the discription text box
                txtClass.Text = selectedHero.PlayerClass.ToString();
                txtDescription.Text = selectedHero.Description;
            }

        }
        /*Edit HP of Characters*/

        // - HP
        private void btnDamage_Click(object sender, RoutedEventArgs e)
        {
            Character selectedCharacter = lbxCombat.SelectedItem as Character;
            //Null Check
            if (selectedCharacter != null)
            {
                damage = int.Parse(txtbxDamage.Text);

                selectedCharacter.HP = (selectedCharacter.HP - damage); //HP - damagae

                //Checks if character dies and moves them to dead listbox
                if (selectedCharacter.HP <= 0)
                {
                    combat.Remove(selectedCharacter);
                    dead.Add(selectedCharacter.Name);

                }
                RefreshScreen();
            }
        }
        // + HP
        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            Character selectedCharacter = lbxCombat.SelectedItem as Character;
            //Null Check
            if (selectedCharacter != null)
            {
                heal = int.Parse(txtbxHeal.Text);

                selectedCharacter.HP = (selectedCharacter.HP + heal); //HP + heal

                RefreshScreen();

            }

        }
        #endregion
        #region Dice_Roller
        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {
            if (D4.IsChecked == true)
            {
                txtD4.Text = RandomNumber(1, 5).ToString();       
            }
            if (D6.IsChecked == true)
            {
                txtD6.Text = RandomNumber(1, 7).ToString();
            }
            if (D8.IsChecked == true)
            {
                txtD8.Text = RandomNumber(1, 9).ToString();
            }
            if (D10.IsChecked == true)
            {
                txtD10.Text = RandomNumber(1, 11).ToString();
            }
            if (D12.IsChecked == true)
            {
                txtD12.Text = RandomNumber(1, 13).ToString();
            }
            if (D20.IsChecked == true)
            {
                txtD20.Text = RandomNumber(1, 21).ToString();
            }
            if (D100.IsChecked == true)
            {
                txtD100.Text = RandomNumber(1, 101).ToString();
            }
        }
        #endregion


    }
}
