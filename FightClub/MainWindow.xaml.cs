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
        List<Hero> dead = new List<Hero>();
        List<Character> selectedCharacter = new List<Character>();

   

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
            Hero hero1 = new Hero("Ig The Barbarian", 14, 22, Classes.Barbarian, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.");
            Hero hero2 = new Hero("MitaK", 17, 25, Classes.Paladin, 11, "MitaK is a famed conquere of the land and shows no mercy to his enemies");
            Hero hero3 = new Hero("Susan Songhart", 9, 11, Classes.Bard, 20, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.");
            Hero hero4 = new Hero("Mary Ironfist", 15, 18, Classes.Monk, 17);
            Hero hero5 = new Hero("Ragagast the Wise", 9, 14, Classes.Wizard, 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut");
            Hero hero6 = new Hero("Favra Trukamre", 12, 15, Classes.Ranger, 17, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod ");
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
            combat.Add(hero5);
            combat.Add(hero6);

            //Sorts all Characters based of Dex
            combat.Sort();
            combat.Reverse();

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
        //Referesh Screen for updating data
        private void RefreshScreen()
        {
            //Rereshes the screen
            lbxCombat.ItemsSource = null;
            lbxCombat.ItemsSource = combat;

            lbxDeath.ItemsSource = null;
            lbxDeath.ItemsSource = dead;
        }
        //Moves Hero from combat list to dead list
        private void KillHero(Hero selectedHero)
        {
            combat.Remove(selectedHero);
            dead.Add(selectedHero);
        }
        //Moves Hero from dead list to combat list
        private void ReviveHero(Hero selectedDeadHero)
        {
            dead.Remove(selectedDeadHero);
            combat.Add(selectedDeadHero);
            selectedDeadHero.HP = 1;
        }
        //Remove Character from combat list
        private void KillCharacter(Character selectedCharacter)
        {
            combat.Remove(selectedCharacter);
          
        }
        //Removes all text and images from character infomation
        private void ResetCharacterInfomation()
        {
            txtClass.Text = null;
            txtDescription.Text = null;
            ImgClass.Source = null;

        }
        #region Dice Roll Method
        //Delays to simulate a live dice roll
        private async void DiceRoll4()
        {
            for (int i = 0; i < 15; i++)
            {
                txtblDiceResult.Text = RandomNumber(1, 5).ToString();
                await Task.Delay(50);
            }
        }
        private async void DiceRoll6()
        {
            for (int i = 0; i < 15; i++)
            {
                txtblDiceResult.Text = RandomNumber(1, 7).ToString();
                await Task.Delay(50);
            }
        }
        private async void DiceRoll8()
        {
            for (int i = 0; i < 15; i++)
            {
                txtblDiceResult.Text = RandomNumber(1, 9).ToString();
                await Task.Delay(50);
            }
        }
        private async void DiceRoll10()
        {
            for (int i = 0; i < 15; i++)
            {
                txtblDiceResult.Text = RandomNumber(1, 11).ToString();
                await Task.Delay(50);
            }
        }
        private async void DiceRoll12()
        {
            for (int i = 0; i < 15; i++)
            {
                txtblDiceResult.Text = RandomNumber(1, 13).ToString();
                await Task.Delay(50);
            }
        }
        private async void DiceRoll20()
        {
            for (int i = 0; i < 15; i++)
            {
                txtblDiceResult.Text = RandomNumber(1, 21).ToString();
                await Task.Delay(50);
            }
        }
        private async void DiceRoll100()
        {
            for (int i = 0; i < 15; i++)
            {
                txtblDiceResult.Text = RandomNumber(1, 101).ToString();
                await Task.Delay(50);
            }
        }
        #endregion
        #endregion

        #region Combat_Tab

        /*Display Classes in listboxes*/
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character selectedCharacter = lbxCombat.SelectedItem as Character;
            Hero selectedHero = lbxCombat.SelectedItem as Hero;
            Hero selectedDeadHero = lbxDeath.SelectedItem as Hero;

            if (selectedCharacter != null) //Checks to see if the selected charcter isn't equal to null
            {
                //Display Class as enemy and the Discription in the discription text box
                txtClass.Text = "Enemy";
                txtDescription.Text = selectedCharacter.Description;
                ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Enemy.png"));
                
            }
            if (selectedHero != null) //Checks to see if the selected character isn't null and is of the subclass Hero
            {
                
                //Display the selected Hero's class property and the discription in the discription text box
                txtClass.Text = selectedHero.PlayerClass.ToString();
                txtDescription.Text = selectedHero.Description;
                //Dispalys image within the ImgClass depending on the hero's class which is stored on a AWS S3
                if (selectedHero.PlayerClass == Classes.Barbarian )
                {
                    ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Barbarian.png"));
                }
                if (selectedHero.PlayerClass == Classes.Bard)
                {
                    ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Bard.png"));
                }
                if (selectedHero.PlayerClass == Classes.Cleric)
                {
                    ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Cleric.png"));
                }
                if (selectedHero.PlayerClass == Classes.Druid)
                {
                    ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Druid.png"));
                }
                if (selectedHero.PlayerClass == Classes.Figther)
                {
                    ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Fighter.png"));
                }
                if (selectedHero.PlayerClass == Classes.Monk)
                {
                    ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Monk.png"));
                }
                if (selectedHero.PlayerClass == Classes.Paladin)
                {
                    ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Paladin.png"));
                }
                if (selectedHero.PlayerClass == Classes.Ranger)
                {
                    ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Ranger.png"));
                }
                if (selectedHero.PlayerClass == Classes.Rouge)
                {
                    ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Rouge.png"));
                }
                if (selectedHero.PlayerClass == Classes.Sorcerer)
                {
                    ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Sorcerer.png"));
                }
                if (selectedHero.PlayerClass == Classes.Warlock)
                {
                    ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Warlock.png"));
                }
                if (selectedHero.PlayerClass == Classes.Wizard)
                {
                    ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Wizard.png"));
                }

            }

        }

        /*Buttons*/

        // - HP
        private void btnDamage_Click(object sender, RoutedEventArgs e)
        {
            Character selectedCharacter = lbxCombat.SelectedItem as Character;
            Hero selectedHero = lbxCombat.SelectedItem as Hero;

            //Null Character Check
            if (selectedCharacter != null)
            {
                int damage = int.Parse(txtbxDamage.Text);
                selectedCharacter.HP = (selectedCharacter.HP - damage); //HP - damagae

                //Checks if character dies and moves them to dead listbox
                if (selectedCharacter.HP <= 0)
                {
                    KillCharacter(selectedCharacter);
                    ResetCharacterInfomation();
                }
                RefreshScreen();
            }
            //Null Hero Check
            if (selectedHero != null)
            {
                if (selectedHero.HP <= 0)
                {
                    KillHero(selectedHero);
                    ResetCharacterInfomation();
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
               int heal = int.Parse(txtbxHeal.Text);

                selectedCharacter.HP = (selectedCharacter.HP + heal); //HP + heal

                RefreshScreen();

            }

        }
        //Revive dead Hero
        private void btnRevive_Click(object sender, RoutedEventArgs e)
        {
            Hero selectedDeadHero = lbxDeath.SelectedItem as Hero;

            if (selectedDeadHero != null)
            {
               
                ReviveHero(selectedDeadHero);
              
                //Resorts the new combat listbox
                combat.Sort();
                combat.Reverse();

            }
            RefreshScreen();
        }
        // Roll Dice
        #region Dice Roll

        private void btnDiceRoll_Click(object sender, RoutedEventArgs e)
        {
            if (cmboxDice.Text == "D4")
            {
                DiceRoll4();
            }
            if (cmboxDice.Text == "D6")
            {
                DiceRoll6();
            }
            if (cmboxDice.Text == "D8")
            {
                DiceRoll8();
            }
            if (cmboxDice.Text == "D10")
            {
                DiceRoll10();
            }
            if (cmboxDice.Text == "D12")
            {
                DiceRoll12();
            }
            if (cmboxDice.Text == "D20")
            {
                DiceRoll20();
            }
            if (cmboxDice.Text == "D100")
            {
                DiceRoll100();
            }

        }





        #endregion

        #endregion

        private void btnCreateHero_Click(object sender, RoutedEventArgs e)
        {
           
            if ((txtbxCreateHeroName != null)&&(txtbxCreateHeroAC != null) && (txtbxCreateHeroHP != null) && (cmboxCreateHeroClass.Text == "Barbarian")&&(txtbxCreateHeroDex != null))
            {
         
                Hero createdHero = new Hero(txtbxCreateHeroName.Text,int.Parse(txtbxCreateHeroAC.Text),int.Parse(txtbxCreateHeroHP.Text),Classes.Barbarian,int.Parse(txtbxCreateHeroDex.Text));
                combat.Add(createdHero);
                RefreshScreen();
            }
            if ((txtbxCreateHeroName != null) && (txtbxCreateHeroAC != null) && (txtbxCreateHeroHP != null) && (cmboxCreateHeroClass.Text == "Bard") && (txtbxCreateHeroDex != null))
            {

                Hero createdHero = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Bard, int.Parse(txtbxCreateHeroDex.Text));
                combat.Add(createdHero);
                RefreshScreen();
            }
            if ((txtbxCreateHeroName != null) && (txtbxCreateHeroAC != null) && (txtbxCreateHeroHP != null) && (cmboxCreateHeroClass.Text == "Druid") && (txtbxCreateHeroDex != null))
            {

                Hero createdHero = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Druid, int.Parse(txtbxCreateHeroDex.Text));
                combat.Add(createdHero);
                RefreshScreen();
            }
            if ((txtbxCreateHeroName != null) && (txtbxCreateHeroAC != null) && (txtbxCreateHeroHP != null) && (cmboxCreateHeroClass.Text == "Fighetr") && (txtbxCreateHeroDex != null))
            {

                Hero createdHero = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Figther, int.Parse(txtbxCreateHeroDex.Text));
                combat.Add(createdHero);
                RefreshScreen();
            }
            if ((txtbxCreateHeroName != null) && (txtbxCreateHeroAC != null) && (txtbxCreateHeroHP != null) && (cmboxCreateHeroClass.Text == "Paladin") && (txtbxCreateHeroDex != null))
            {

                Hero createdHero = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Paladin, int.Parse(txtbxCreateHeroDex.Text));
                combat.Add(createdHero);
                RefreshScreen();
            }
            else
            {
                Hero createdHero = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Paladin, int.Parse(txtbxCreateHeroDex.Text));
                combat.Add(createdHero);
                RefreshScreen();
            }







        }
    }
}

