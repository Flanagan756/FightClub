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
using System.IO;

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
        List<PreMadeHero> preMadeHero = new List<PreMadeHero>();

        //Connects the PremadeHeros database
        Entities db = new Entities();




        public MainWindow()
        {
            InitializeComponent();

            /*Lamda Queries*/

            //Selects all Heros from PremadeHero Table
            var heroListQuery = from h in db.PreMadeHeroes
                                select h;
            lbxPremadeHeroes.ItemsSource = heroListQuery.ToList();

            //Selects all premade Enemies from Table
            var enemyListQuery = from en in db.Enemies
                                 select en;
            lbxPremadeEnemies.ItemsSource = enemyListQuery.ToList();



            #region Create Characters
            //Create Enemies
            Character enemy1 = new Character("Dire Wolf", 19, 25, 16,
           "Large fearsome cousins of the wolf. Unlike their smaller cosuins, their larger size means that they can hunt alone.");


            //Create Heros
            Hero hero1 = new Hero("Ig The Barbarian", 14, 22, Classes.Barbarian, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.", "https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Ig.png");
            Hero hero2 = new Hero("MitaK", 17, 25, Classes.Paladin, 11, "MitaK is a famed conquere of the land and shows no mercy to his enemies", "https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Mitak.jpg");
            Hero hero3 = new Hero("Susan Songhart", 9, 11, Classes.Bard, 20, "A young nobel on the run from her family duties to discover all of the wonders the world has to offer.", "https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Susan+Songhart.jpg");
            Hero hero4 = new Hero("Defalut Hero", 15, 18, Classes.Figther, 17);
            Hero hero5 = new Hero("Radagast the Wise", 9, 14, Classes.Wizard, 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut", "https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Radagast+the+Wise.png");
            Hero hero6 = new Hero("Kyra Pythonblood", 12, 15, Classes.Cleric, 17, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod ", "https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Kyra+Pythonblood.jpg");
            #endregion

            #region Add Characters to List
            //Add all the Enemies(Chartacter Class) to the combat list
            combat.Add(enemy1);

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
            //Reresh the screen
            lbxCombat.ItemsSource = null;
            lbxCombat.ItemsSource = combat;

            lbxDeath.ItemsSource = null;
            lbxDeath.ItemsSource = dead;

            //Clear Character text box
            txtbxCreateCharacterName.Text = "";
            txtbxCreateCharacterAC.Text = "";
            txtbxCreateCharacterHP.Text = "";
            txtbxCreateCharacterDex.Text = "";
            cmboxCreateHeroClass.SelectedItem = null;

            //Clear Hero text box
            txtbxCreateHeroName.Text = "";
            txtbxCreateHeroAC.Text = "";
            txtbxCreateHeroHP.Text = "";
            txtbxCreateHeroDex.Text = "";
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
        private void CombatListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Character selectedCharacter = lbxCombat.SelectedItem as Character;

            Hero selectedHero = lbxCombat.SelectedItem as Hero;
            Hero selectedDeadHero = lbxDeath.SelectedItem as Hero;

            if (selectedCharacter != null) //Checks to see if the selected charcter isn't equal to null
            {
                //Display enemy infomation
                txtClass.Text = "Enemy";
                txtDescription.Text = selectedCharacter.Description;
                ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Enemy.png"));
                imgCharacter.Source = new BitmapImage(new Uri(selectedCharacter.CharacterImage));

            }
            if (selectedHero != null) //Checks to see if the selected character isn't null and is of the subclass Hero
            {
                if (selectedHero.CharacterImage != null)
                {
                    //Displays hero image
                    imgCharacter.Source = new BitmapImage(new Uri(selectedHero.CharacterImage));
                }
                else
                {
                    //Display Default Hero Image if no image is provided
                    imgCharacter.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Characters/Default.png"));
                }
                //Display the selected Hero's class property and the discription in the discription text box
                txtClass.Text = selectedHero.PlayerClass.ToString();
                txtDescription.Text = selectedHero.Description;

                //Dispalys the hero's class icon depending on the hero's class which is stored on a AWS 
                switch (selectedHero.PlayerClass)
                {
                    case Classes.Barbarian:
                        ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Icons/DnDLogos/Barbarian.png"));
                        break;
                    case Classes.Bard:
                        ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Icons/DnDLogos/Bard.png"));
                        break;
                    case Classes.Cleric:
                        ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Icons/DnDLogos/Cleric.png"));
                        break;
                    case Classes.Druid:
                        ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Icons/DnDLogos/Druid.png"));
                        break;
                    case Classes.Figther:
                        ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Icons/DnDLogos/Fighter.png"));
                        break;
                    case Classes.Monk:
                        ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Icons/DnDLogos/Monk.png"));
                        break;
                    case Classes.Paladin:
                        ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Icons/DnDLogos/Paladin.png"));
                        break;
                    case Classes.Ranger:
                        ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Icons/DnDLogos/Ranger.png"));
                        break;
                    case Classes.Rouge:
                        ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Icons/DnDLogos/Rogue.png"));
                        break;
                    case Classes.Sorcerer:
                        ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Icons/DnDLogos/Sorcerer.png"));
                        break;
                    case Classes.Warlock:
                        ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Icons/DnDLogos/Warlock.png"));
                        break;
                    case Classes.Wizard:
                        ImgClass.Source = new BitmapImage(new Uri("https://dndcharacters.s3-eu-west-1.amazonaws.com/Icons/DnDLogos/Wizard.png"));
                        break;
                    default:
                        break;
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
        #region Character Creation
        private void createCharacter_Click(object sender, RoutedEventArgs e)
        {
            //Check that all of the fields are filled
            if ((txtbxCreateCharacterName.Text != "") && (txtbxCreateCharacterAC.Text != "") && (txtbxCreateCharacterHP.Text != "") && (txtbxCreateCharacterDex.Text != ""))
            {
                Character createdCharacter = new Character(txtbxCreateCharacterName.Text, int.Parse(txtbxCreateCharacterAC.Text), int.Parse(txtbxCreateCharacterHP.Text), int.Parse(txtbxCreateCharacterDex.Text));
                combat.Add(createdCharacter);
                //Sort the new list
                combat.Sort();
                combat.Reverse();
                RefreshScreen();
            }
            else
            {
                //Display error if any fields are empty
                MessageBox.Show("Field empty.", "Error");
            }
          
        }
        private void btnCreateHero_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((txtbxCreateHeroName.Text != "") && (txtbxCreateHeroAC.Text != "") && (txtbxCreateHeroHP.Text != "") && (txtbxCreateHeroDex.Text != "") && (cmboxCreateHeroClass.SelectedItem != null))
                {
                    //Creates and adds the created hero to the listbox and displays their class image
                    switch (cmboxCreateHeroClass.Text)
                    {
                        case "Barbarian":
                            Hero createdBarbarian = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Barbarian, int.Parse(txtbxCreateHeroDex.Text));
                            combat.Add(createdBarbarian);
                            RefreshScreen();
                            break;
                        case "Bard":
                            Hero createdBard = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Bard, int.Parse(txtbxCreateHeroDex.Text));
                            combat.Add(createdBard);
                            RefreshScreen();
                            break;
                        case "Cleric":
                            Hero createdCleric = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Cleric, int.Parse(txtbxCreateHeroDex.Text));
                            combat.Add(createdCleric);
                            RefreshScreen();
                            break;
                        case "Druid":
                            Hero createdDruid = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Druid, int.Parse(txtbxCreateHeroDex.Text));
                            combat.Add(createdDruid);
                            RefreshScreen();
                            break;
                        case "Fighter":
                            Hero createdFighter = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Figther, int.Parse(txtbxCreateHeroDex.Text));
                            combat.Add(createdFighter);
                            RefreshScreen();
                            break;
                        case "Monk":
                            Hero createdMonk = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Monk, int.Parse(txtbxCreateHeroDex.Text));
                            combat.Add(createdMonk);
                            RefreshScreen();
                            break;
                        case "Paladin":
                            Hero createdPaladin = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Paladin, int.Parse(txtbxCreateHeroDex.Text));
                            combat.Add(createdPaladin);
                            RefreshScreen();
                            break;
                        case "Ranger":
                            Hero createdRanger = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Ranger, int.Parse(txtbxCreateHeroDex.Text));
                            combat.Add(createdRanger);
                            RefreshScreen();
                            break;
                        case "Rouge":
                            Hero createdRouge = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Rouge, int.Parse(txtbxCreateHeroDex.Text));
                            combat.Add(createdRouge);
                            RefreshScreen();
                            break;
                        case "Sorcerer":
                            Hero createdSorcerer = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Sorcerer, int.Parse(txtbxCreateHeroDex.Text));
                            combat.Add(createdSorcerer);
                            RefreshScreen();
                            break;
                        case "Warlock":
                            Hero createdWarlock = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Warlock, int.Parse(txtbxCreateHeroDex.Text));
                            combat.Add(createdWarlock);
                            RefreshScreen();
                            break;
                        case "Wizard":
                            Hero createdWizard = new Hero(txtbxCreateHeroName.Text, int.Parse(txtbxCreateHeroAC.Text), int.Parse(txtbxCreateHeroHP.Text), Classes.Wizard, int.Parse(txtbxCreateHeroDex.Text));
                            combat.Add(createdWizard);
                            RefreshScreen();
                            break;

                    }
                    //Sort and Reresh the Combat List Box
                    combat.Sort();
                    combat.Reverse();
                    RefreshScreen();
                }
                else
                {
                    MessageBox.Show("Empty Field", "Error");
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Invalid number", "Error");
            }      
            catch(Exception)
            {
                MessageBox.Show("An error has occured", "Error");
                throw;
            }
        }
        #endregion
        private void lbxPremadeHeros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            PreMadeHero selectedPreMadeHero = lbxPremadeHeroes.SelectedItem as PreMadeHero;



            int id = selectedPreMadeHero.Id;

            string heroImg = selectedPreMadeHero.HeroImage;
            string description = selectedPreMadeHero.Description;

            int selectedWeaponId = selectedPreMadeHero.Weapon_Id;
            var selectedSpellId = selectedPreMadeHero.Spell_Id;

            var weaponsQuery = from ph in db.PreMadeHeroes
                               join w in db.Weapons on ph.Weapon_Id equals w.Id
                               where ph.Weapon_Id == selectedWeaponId
                               select w.Name;

            var spellsQuery = from ph in db.PreMadeHeroes
                              join s in db.Spells on ph.Spell_Id equals s.Id
                              where ph.Spell_Id == selectedSpellId
                              select s.Name;



            imgPremadeHero.Source = new BitmapImage(new Uri(heroImg));
            txtblPremadeHeroDescription.Text = description;
            lbxPremadeHeroWeapons.ItemsSource = weaponsQuery.ToList().Distinct();
            lbxPremadeHeroSpells.ItemsSource = spellsQuery.ToList().Distinct();




        }
  
        #region PremadeHeroes

        private void addPremadeHero_Click(object sender, RoutedEventArgs e)
        {
            //Add the Premade Hero
            PreMadeHero selectedHero = lbxPremadeHeroes.SelectedItem as PreMadeHero;

            if (selectedHero != null)
            {
                //Adds teh hero and diplays their class image
                switch (selectedHero.Class_Id)
                {
                    case 1:
                        Hero PremadeBarbarian = new Hero(selectedHero.Name, int.Parse(selectedHero.AC), int.Parse(selectedHero.HP), Classes.Barbarian, int.Parse(selectedHero.Dex), selectedHero.Description, selectedHero.HeroImage);
                        combat.Add(PremadeBarbarian);
                        break;
                    case 2:
                        Hero PremadeBard = new Hero(selectedHero.Name, int.Parse(selectedHero.AC), int.Parse(selectedHero.HP), Classes.Bard, int.Parse(selectedHero.Dex), selectedHero.Description, selectedHero.HeroImage);
                        combat.Add(PremadeBard);
                        break;
                    case 3:
                        Hero PremadeCleric = new Hero(selectedHero.Name, int.Parse(selectedHero.AC), int.Parse(selectedHero.HP), Classes.Cleric, int.Parse(selectedHero.Dex), selectedHero.Description, selectedHero.HeroImage);
                        combat.Add(PremadeCleric);
                        break;
                    case 5:
                        Hero PremadeDruid = new Hero(selectedHero.Name, int.Parse(selectedHero.AC), int.Parse(selectedHero.HP), Classes.Druid, int.Parse(selectedHero.Dex), selectedHero.Description, selectedHero.HeroImage);
                        combat.Add(PremadeDruid);
                        break;
                    case 6:
                        Hero PremadeFighter = new Hero(selectedHero.Name, int.Parse(selectedHero.AC), int.Parse(selectedHero.HP), Classes.Figther, int.Parse(selectedHero.Dex), selectedHero.Description, selectedHero.HeroImage);
                        combat.Add(PremadeFighter);
                        break;
                    case 7:
                        Hero PremadeMonk = new Hero(selectedHero.Name, int.Parse(selectedHero.AC), int.Parse(selectedHero.HP), Classes.Monk, int.Parse(selectedHero.Dex), selectedHero.Description, selectedHero.HeroImage);
                        combat.Add(PremadeMonk);
                        break;
                    case 8:
                        Hero PremadePaladin = new Hero(selectedHero.Name, int.Parse(selectedHero.AC), int.Parse(selectedHero.HP), Classes.Paladin, int.Parse(selectedHero.Dex), selectedHero.Description, selectedHero.HeroImage);
                        combat.Add(PremadePaladin);
                        break;
                    case 9:
                        Hero PremadeRanger = new Hero(selectedHero.Name, int.Parse(selectedHero.AC), int.Parse(selectedHero.HP), Classes.Ranger, int.Parse(selectedHero.Dex), selectedHero.Description, selectedHero.HeroImage);
                        combat.Add(PremadeRanger);
                        break;
                    case 10:
                        Hero PremadeRouge = new Hero(selectedHero.Name, int.Parse(selectedHero.AC), int.Parse(selectedHero.HP), Classes.Rouge, int.Parse(selectedHero.Dex), selectedHero.Description, selectedHero.HeroImage);
                        combat.Add(PremadeRouge);
                        break;
                    case 11:
                        Hero PremadeSorcerer = new Hero(selectedHero.Name, int.Parse(selectedHero.AC), int.Parse(selectedHero.HP), Classes.Sorcerer, int.Parse(selectedHero.Dex), selectedHero.Description, selectedHero.HeroImage);
                        combat.Add(PremadeSorcerer);
                        break;
                    case 12:
                        Hero PremadeWarlock = new Hero(selectedHero.Name, int.Parse(selectedHero.AC), int.Parse(selectedHero.HP), Classes.Warlock, int.Parse(selectedHero.Dex), selectedHero.Description, selectedHero.HeroImage);
                        combat.Add(PremadeWarlock);
                        break;
                    case 13:
                        Hero PremadeWizard = new Hero(selectedHero.Name, int.Parse(selectedHero.AC), int.Parse(selectedHero.HP), Classes.Wizard, int.Parse(selectedHero.Dex), selectedHero.Description, selectedHero.HeroImage);
                        combat.Add(PremadeWizard);
                        break;

                }
            }
            //Sort Combat listbox and refresh
            combat.Sort();
            combat.Reverse();
            RefreshScreen();
        }
        #endregion
        #region PremadeEnemies
        private void lbxPremadeEnemies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Select enemy from the Enemy Table
            Enemy selectedEnemy = lbxPremadeEnemies.SelectedItem as Enemy;

            /*Varibles*/
            int id = selectedEnemy.Id;
            string monsterImg = selectedEnemy.EnemyImage;
            string description = selectedEnemy.Description;
            int selectedWeaponId = selectedEnemy.Weapon_Id;
            var selectedSpellId = selectedEnemy.Spell_Id;

            /*Join tables Queries*/
            var weaponsQuery = from en in db.Enemies
                               join w in db.Weapons on en.Weapon_Id equals w.Id
                               where en.Weapon_Id == selectedWeaponId
                               select w.Name;

            var spellsQuery = from en in db.Enemies
                              join s in db.Spells on en.Spell_Id equals s.Id
                              where en.Spell_Id == selectedSpellId
                              select s.Name;


            //Display the infomation from the queires
            imgPremadeEnemy.Source = new BitmapImage(new Uri(monsterImg));
            txtblPremadeEnemyDescription.Text = description;
            lbxPremadeEnemyWeapons.ItemsSource = weaponsQuery.ToList().Distinct();
            lbxPremadeEnemySpells.ItemsSource = spellsQuery.ToList().Distinct();
        }

        private void addPremadeEnemy_Click(object sender, RoutedEventArgs e)
        {
            Enemy selectedEnemy = lbxPremadeEnemies.SelectedItem as Enemy;

            if (selectedEnemy != null)
            {
                //Create a character usinging the data from the Enemy table
                Character premadeEnemy = new Character(selectedEnemy.Name, int.Parse(selectedEnemy.AC), int.Parse(selectedEnemy.HP), int.Parse(selectedEnemy.Dex), selectedEnemy.Description, selectedEnemy.EnemyImage);
                combat.Add(premadeEnemy);
            }
            //Sort the combat list and refresh
            combat.Sort();
            combat.Reverse();
            RefreshScreen();
        }
    }
    #endregion
}

