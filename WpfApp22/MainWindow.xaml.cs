using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace WpfApp22
{
    public partial class MainWindow : Window
    {
        Random random = new Random();
        Random ran = new Random();
        //Hlavní spuštění
        public MainWindow()
        {
            InitializeComponent();
            TimeWindow();
            StartGameHello();
        }
        Human human = new Human();
        Computer computer = new Computer();

        //Načtení hodnot na začátku hry- není dodělané
        public void StartGameHello()
        {
            //this.InfoHUman_lbl.Visibility = Visibility;
            this.StrenghtComputerLabel_lbl.Visibility = Visibility.Hidden;
            this.StrenghtComputer_lbl.Visibility = Visibility.Hidden;
            this.LevelComputerLabel_lbl.Visibility = Visibility.Hidden;
            this.LevelComputer_lbl.Visibility = Visibility.Hidden;
            this.InfoComputer_lbl.Content = "";
            this.Image_img.Source = null;
            this.LifeComputer_progress.Visibility = Visibility.Hidden;
            this.LifeComuter_lbl.Content = "";
            this.Attack_btn.Visibility = Visibility.Hidden;
            this.LifeComputer_progress.Visibility = Visibility.Hidden;
        }
        //Hodiny v okně
        public void TimeWindow()
        {
            DispatcherTimer time = new DispatcherTimer();
            time.Interval = TimeSpan.FromSeconds(1);
            time.Tick += TikTak;
            time.Start();
        }
        //Hodiny, kde se vypisují v okně
        private void TikTak(object sender, EventArgs e)
        {
            this.Time_lbl.Content = DateTime.Now.ToString("HH\\:mm\\:ss");
        }
        //Konec, když někdo vyhraje
        public bool EndGameCycle()
        {
            if (WinHuman() == true)
            {
                Attack_btn.Visibility = Visibility.Hidden;
             


                return true;
            }
            else if (WinComputer() == true)
            {
                Attack_btn.Visibility = Visibility.Hidden;
               


                return true;

            }
            return false;

        }
        //Ukončení aplikace
        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        Random treasure = new Random();
        //Zde je i náhodné zobrazení Pokladů
        public bool WinHuman()
        {
            int ab = treasure.Next(1,11);
            Uri trea = new Uri(@"C:\Users\hanak\source\repos\WpfApp22\WpfApp22\Images\Treasure.png");
            Uri treaA = new Uri(@"C:\Users\hanak\source\repos\WpfApp22\WpfApp22\Images\Treasure2.png");
            //Uri treasTwo = new Uri(@"C:\Users\hanak\source\repos\WpfApp22\WpfApp22\Images\Treasure.png");
            //Uri treasThree = new Uri(@"C:\Users\hanak\source\repos\WpfApp22\WpfApp22\Images\Treasure.png");


            if (computer.LifeComplet() <= 0 && (human.LifeComplet() > computer.LifeComplet()))
            {
                this.InfoWinHuman_lbl.Content = "Nepřítel mrtev ...";             
                this.Attack_btn.IsEnabled = false;
                this.Image_img.Source = null;
                this.InfoComputer_lbl.Content = string.Empty;

                switch (ab)
                {

                    case 1:
                        this.Treaseure1_img.Source = new BitmapImage(trea);
                        this.Treaseure4_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure3_img.Source = null;
                        break;
                    case 2:
                        this.Treaseure2_img.Source = new BitmapImage(trea);
                        this.Treaseure1_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        this.Treaseure3_img.Source = null;
                        break;
                    case 3:
                        this.Treaseure3_img.Source = new BitmapImage(trea);
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        break;
                    case 4:

                        if (FlowerBonus() != true)
                        {
                            this.Treaseure4_img.Source = new BitmapImage(treaA);
                            this.Treaseure1_img.Source = null;
                            this.Treaseure2_img.Source = null;
                            this.Treaseure3_img.Source = null;
                        }
                        else
                        {
                            this.Treaseure1_img.Source = null;
                            this.Treaseure2_img.Source = null;
                            this.Treaseure3_img.Source = null;
                        }
                        break;
                    case 5:
                        this.Treaseure3_img.Source = null;
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        break;
                    case 6:
                        this.Treaseure3_img.Source = null;
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        break;
                    case 7:
                        this.Treaseure3_img.Source = null;
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        break;
                    case 8:
                        this.Treaseure3_img.Source = null;
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        break;
                    case 9:
                        this.Treaseure3_img.Source = null;
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        break;
                    case 10:
                        this.Treaseure3_img.Source = null;
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        break;


                    default:                      
                        break;
                }
                return true;
            }
            else
            {
                return false;
            }

        }
        //Vítěz Computer
        public bool WinComputer()
        {
            if (human.LifeComplet() <= 0 && (computer.LifeComplet() > human.LifeComplet()))
            {
                this.InfoWinComputer_lbl.Content = "Jsi mrtev...";
                this.Attack_btn.IsEnabled = false;
                this.InfoHUman_lbl.Visibility = Visibility.Hidden;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Útok Human
        public void StartAttackHuman()
        {
            int a = random.Next(25, 150);
            this.computer.Life = computer.Life - (human.AttackComplet() + a);
        }
        //Útok Computer
        public void StartAttackComputer()
        {

            int b = ran.Next(1, 150);
            this.human.Life = human.Life - (computer.AttackComplet() + b);
        }
        //Začátelk útoku
        public void StartAttack()
        {
            StartAttackHuman();
            StartAttackComputer();
        }
        //Výpis aktuálních hodnot na obrazovku v aplikaci
        public void ActuallDataOnScreen()
        {
            this.LifeHuman_progress.Value = human.LifeComplet();
            this.LifeHuman_lbl.Content = human.LifeComplet().ToString();

            this.StrenghtHuman_lbl.Content = human.StrenghtComplet().ToString();
            this.LevelHuman_lbl.Content = human.LevelHuman.ToString();
            this.Experience_lbl.Content = human.Experience.ToString() + "/" + human.ExperienceNext.ToString();

            this.LifeComputer_progress.Value = computer.LifeComplet();
            this.LifeComuter_lbl.Content = computer.LifeComplet().ToString();

            this.Coins_lbl.Content = human.CoinsHuman.ToString();
        }
        //Level Up přidání hodnot, coinů, experiencí, bonusů
        public void LevelUp()
        {
            if (WinHuman())
            {
                NewGame_btn.Visibility = Visibility;
                computer.Strenght = computer.Strenght + 10;
                computer.LevelComputer += 1;
              
                Coiny();
                human.Experience += 120 + computer.LevelComputer * 3;
                if (human.Experience >= human.ExperienceNext && human.Experience < (human.ExperienceNext * 2))
                {
                    human.LevelHuman += 1;
                    human.Strenght = human.Strenght + 10;
                    human.ExperienceNext += human.ExperienceNext;
                    //BonusLevelWin();
                }
            }
            else if (WinComputer())
            {
                human.CoinsHuman -= 75;
                NewGame_btn.Visibility = Visibility;
            }

        }
        //Coiny sčítání při vyhraném souboji
        public int Coiny()
        {

            if (CoinyBonus() == true)
            {
                human.CoinsHuman += 75 + computer.LevelComputer * 2 + 100;
                return human.CoinsHuman;
            }
            else
            {
                human.CoinsHuman += 75 + computer.LevelComputer * 2;
                return human.CoinsHuman;
            }
           
        }
        //Zkušenosti
        public int ExperienceNextLevel()
        {


            human.ExperienceNext += human.ExperienceNext * 2;
            return human.ExperienceNext;
        }
        //Další hra po boji - výpis na obrazovku a úprava dat
        private void NewGame_btn_Click(object sender, RoutedEventArgs e)
        {

            this.InfoHUman_lbl.Visibility = Visibility;

            this.InfoWinComputer_lbl.Content = string.Empty;
            this.InfoWinHuman_lbl.Content = string.Empty;
            this.StrenghtComputerLabel_lbl.Visibility = Visibility;
            this.StrenghtComputer_lbl.Visibility = Visibility;
            this.LevelComputerLabel_lbl.Visibility = Visibility;
            this.LevelComputer_lbl.Visibility = Visibility;
            this.LifeComputer_progress.Visibility = Visibility;

            Attack_btn.Visibility = Visibility;


            this.LifeComputer_progress.Visibility = Visibility;
            this.LifeComuter_lbl.Content = "1000";

            human.Life = human.LifeMaxProgres;
            computer.Life = computer.LifeMaxProgres;


            this.LifeHuman_progress.Value = human.LifeMaxProgres;
            this.LifeHuman_lbl.Content = human.LifeMaxProgres.ToString();
            this.LifeHuman_progress.Value = human.LifeMaxProgres;
            this.LifeHuman_progress.Maximum = human.LifeMaxProgres;


            this.StrenghtHuman_lbl.Content = human.StrenghtComplet().ToString();
            this.LevelHuman_lbl.Content = human.LevelHuman.ToString();
            this.Coins_lbl.Content = human.CoinsHuman.ToString();
            this.Experience_lbl.Content = human.Experience.ToString() + "/" + human.ExperienceNext.ToString();


            this.LifeComputer_progress.Value = computer.LifeMaxProgres;
            this.LifeComuter_lbl.Content = computer.LifeMaxProgres.ToString();
            this.LifeComputer_progress.Value = computer.LifeMaxProgres;
            this.LifeComputer_progress.Maximum = computer.LifeMaxProgres;

            this.StrenghtComputer_lbl.Content = computer.StrenghtComplet().ToString();
            this.LevelComputer_lbl.Content = computer.LevelComputer.ToString();

            this.Treaseure1_img.Source = null;
            this.Treaseure2_img.Source = null;
            this.Treaseure3_img.Source = null;
            this.Treaseure4_img.Source = null;
            ChangeComputerImage();

            this.Attack_btn.IsEnabled = true;
            NewGame_btn.Visibility = Visibility.Hidden;
        }
        //Bonus Coiny za level 2
        public bool BonusLevelWin()
        {
            if (human.LevelHuman <= 3 && human.LevelHuman >= 2 && !(human.LevelHuman >= 3))
            {
                this.human.CoinsHuman = human.CoinsHuman + 300;
                this.Coins_lbl.Content = human.CoinsHuman.ToString();
                MessageBox.Show("Dosáhl jsi levelu 2, dostal jsi odměnu 300 Coinů");
                return true;
            }
            else
                return false;
        }
        //Koupit Sílu metoda
        private void BuyStrenght_btn_Click(object sender, RoutedEventArgs e)
        {

            if (this.human.CoinsHuman >= 30)
            {
                this.human.Strenght = human.Strenght + 30;
                this.StrenghtHuman_lbl.Content = human.StrenghtComplet().ToString();
                this.human.CoinsHuman = human.CoinsHuman - 30;
                this.Coins_lbl.Content = human.CoinsHuman.ToString();

            }
            else
            {
                return;
                //MessageBox.Show("Nemáš dostatek Conů");
            }

        }
        //Tlačítko útoku
        private void Attack_btn_Click(object sender, RoutedEventArgs e)
        {
           

            if (this.LifeComputer_progress.Visibility == Visibility.Hidden)
            {


                return;


            }
            else
            {
                if (this.ProgressFight_check.IsChecked == true)
                {
                    while (EndGameCycle() == false)
                    {
                        StartAttackComputer();
                        StartAttackHuman();
                    }
                }
                else
                {
                    StartAttackComputer();
                    StartAttackHuman();
                }
                WinHuman();
                WinComputer();
                LevelUp();



                ActuallDataOnScreen();
                

            }



        }
        //Vložení jména
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.NameInsert_txt.Text == null)
            {
                return;
            }
            else
            {
                this.InfoHUman_lbl.Content = this.NameInsert_txt.Text;
                this.NameInsert_txt.Visibility = Visibility.Hidden;
                this.InsertName_btn.Visibility = Visibility.Hidden;
            }
        }
        //Smazání text v texboxu
        private void NameInsert_txt_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.NameInsert_txt.Text = string.Empty;
            this.NameInsert_txt.Focus();
        }
        //Textbox nic - jen tak to to je
        private void NameInsert_txt_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.NameInsert_txt.Focus();


        }
        //Computer protivníka pokaždé jiný
        public void ChangeComputerImage()
        {
            Random ran = new Random();
            int a = ran.Next(1, 4);
            switch (a)
            {
                case 1:
                    ComputerOne();
                    break;
                case 2:
                    ComputerTwo();
                    break;
                case 3:
                    ComputerThree();
                    break;               
                default:
                    break;
            }


        }
        //Definice protivníka 1
        public bool ComputerOne()
        {

            Uri CompOne = new Uri(@"C:\Users\hanak\source\repos\WpfApp22\WpfApp22\Images\Soldier.png");
            this.Image_img.Source = new BitmapImage(CompOne);
            this.InfoComputer_lbl.Content = "Tlupa buzerantů";
            return true;
        }
        //Definice protivníka 2
        public bool ComputerTwo()
        {
            Uri CompTwo = new Uri(@"C:\Users\hanak\source\repos\WpfApp22\WpfApp22\Images\Tank.png");
            this.Image_img.Source = new BitmapImage(CompTwo);
            this.InfoComputer_lbl.Content = "Super Tank";
            return true;
        }
        //Definice protivníka 3
        public bool ComputerThree()
        {
            Uri CompThree = new Uri(@"C:\Users\hanak\source\repos\WpfApp22\WpfApp22\Images\Ufo.png");
            this.Image_img.Source = new BitmapImage(CompThree);
            this.InfoComputer_lbl.Content = "Ufo";
            return true;
        }
        //Poklad 1
        private void Treaseure1_img_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {


            Random ran = new Random();
            int a = ran.Next(1, 20);

            switch (a)
            {
                case 1:
                    TreasureStandard();
                    break;
                case 2:
                    TreasureStandard();
                    break;
                case 3:
                    TreasureStandard();
                    break;
                case 4:
                    TreasureStandard();
                    break;
                case 5:
                    TreasureStandard();
                    break;
                case 6:
                    TreasureStandard();
                    break;
                case 7:
                    TreasureStandard();
                    break;
                case 8:
                    TreasureStandard();
                    break;
                case 9:
                    TreasureItemsVariable();
                    break;
                case 10:
                    TreasureStandard();
                    break;
                case 11:
                    TreasureStandard();
                    break;
                case 12:
                    TreasureStandard();
                    break;
                case 13:
                    TreasureStandard();
                    break;
                case 14:
                    TreasureStandard();
                    break;
                case 15:
                    TreasureStandard();
                    break;
                case 16:
                    TreasureStandard();
                    break;
                case 17:
                    TreasureStandard();
                    break;
                case 18:
                    TreasureStandard();
                    break;
                case 19:
                    TreasureStandard();
                    break;
                default:
                    break;
            }



        }
        //Poklad 2
        private void Treaseure2_img_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Random ran = new Random();
            int a =  ran.Next(1, 20);

            switch (a)
            {
                case 1:
                    TreasureStandard();
                    break;
                case 2:
                    TreasureStandard();
                    break;
                case 3:
                    TreasureStandard();
                    break;
                case 4:
                    TreasureStandard();
                    break;
                case 5:
                    TreasureStandard();
                    break;
                case 6:
                    TreasureStandard();
                    break;
                case 7:
                    TreasureStandard();
                    break;
                case 8:
                    TreasureStandard();
                    break;
                case 9:
                    TreasureItemsVariable();
                    break;
                case 10:
                    TreasureStandard();
                    break;
                case 11:
                    TreasureStandard();
                    break;
                case 12:
                    TreasureStandard();
                    break;
                case 13:
                    TreasureStandard();
                    break;
                case 14:
                    TreasureStandard();
                    break;
                case 15:
                    TreasureStandard();
                    break;
                case 16:
                    TreasureStandard();
                    break;
                case 17:
                    TreasureStandard();
                    break;
                case 18:
                    TreasureStandard();
                    break;
                case 19:
                    TreasureStandard();
                    break;
                default:
                    break;
            }



          

            

        }
        //Poklad 3
        private void Treaseure3_img_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Random ran = new Random();
            int a = ran.Next(1, 20);

            switch (a)
            {
                case 1:
                    TreasureStandard();
                    break;
                case 2:
                    TreasureStandard();
                    break;
                case 3:
                    TreasureStandard();
                    break;
                case 4:
                    TreasureStandard();
                    break;
                case 5:
                    TreasureStandard();
                    break;
                case 6:
                    TreasureStandard();
                    break;
                case 7:
                    TreasureStandard();
                    break;
                case 8:
                    TreasureStandard();
                    break;
                case 9:
                    TreasureItemsVariable();
                    break;
                case 10:
                    TreasureStandard();
                    break;
                case 11:
                    TreasureStandard();
                    break;
                case 12:
                    TreasureStandard();
                    break;
                case 13:
                    TreasureStandard();
                    break;
                case 14:
                    TreasureStandard();
                    break;
                case 15:
                    TreasureStandard();
                    break;
                case 16:
                    TreasureStandard();
                    break;
                case 17:
                    TreasureStandard();
                    break;
                case 18:
                    TreasureStandard();
                    break;
                case 19:
                    TreasureStandard();
                    break;
                default:
                    break;
            }




          

        }
        //Poklad 4
        private void Treaseure4_img_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Random ran = new Random();
            int a = ran.Next(1, 20);

            switch (a)
            {
                case 1:
                    TreasureStandardBig();
                    break;
                case 2:
                    TreasureStandardBig();
                    
                    break;
                case 3:
                    TreasureStandardBig();
                    
                    break;
                case 4:
                    TreasureStandardBig();
                    
                    break;
                case 5:
                    TreasureStandardBig();
                    
                    break;
                case 6:
                    TreasureStandardBig();
                    
                    break;
                case 7:
                    TreasureStandardBig();
                    
                    break;
                case 8:
                    TreasureStandardBig();
                    
                    break;
                case 9:

                    if (this.Image4_img.Source == null)
                    {
                        Uri zdrojBonus = new Uri(@"C:\Users\hanak\source\repos\WpfApp22\WpfApp22\ImagesBonus\Kytka.png");
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure3_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        MessageBox.Show("    Tvůj loot je: \n   " +
                                        "    Kytka růstu peněz  \n   " +
                                        "    + 100 Coinů po každé vyhrané bitvě");
                        this.Image4_img.Source = new BitmapImage(zdrojBonus);
                    }
                    else
                    {
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure3_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        MessageBox.Show("Získáváš 5000 Coinů");
                        human.CoinsHuman = human.CoinsHuman + 5000;
                        this.Coins_lbl.Content = human.CoinsHuman.ToString();
                    }
                    break;
                case 10:
                    TreasureStandardBig();
                    
                    break;
                case 11:
                    TreasureStandardBig();
                    
                    break;
                case 12:
                    TreasureStandardBig();
                    
                    break;
                case 13:
                    TreasureStandardBig();
                    
                    break;
                case 14:
                    TreasureStandardBig();
                    
                    break;
                case 15:
                    TreasureStandardBig();
                    
                    break;
                case 16:
                    TreasureStandardBig();
                    
                    break;
                case 17:
                    TreasureStandardBig();
                    
                    break;
                case 18:
                    TreasureStandardBig();
                    
                    break;
                case 19:
                    TreasureStandardBig();
                    
                    break;
                default:
                    break;
            }



         
        }
        //Náhodné věci z pokladu
        public void TreasureItemsVariable()
        {
            Random ra = new Random();
            int b = ra.Next(1, 4);


            switch (b)
            {

                case 1:
                    if (this.Image1_img.Source == null)
                    {
                        Uri zdrojBonus1 = new Uri(@"C:\Users\hanak\source\repos\WpfApp22\WpfApp22\ImagesBonus\BonusKalhotky.png");
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure3_img.Source = null;
                        this.Treaseure4_img.Source = null;

                        MessageBox.Show("    Tvůj loot je: \n   " +
                                        "    Coiny + 945   \n   " +
                                        "    Kalhotky Bohů + 129 Síla");
                        this.human.CoinsHuman = human.CoinsHuman + 945;
                        this.Coins_lbl.Content = human.CoinsHuman.ToString();
                        this.human.BonusStrenght = human.BonusStrenght + 129;
                        this.StrenghtHuman_lbl.Content = human.StrenghtComplet().ToString();
                        this.Image1_img.Source = new BitmapImage(zdrojBonus1);

                    }
                    else
                    {
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure3_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        MessageBox.Show("Získáváš 5000 Coinů");
                        human.CoinsHuman = human.CoinsHuman + 5000;
                        this.Coins_lbl.Content = human.CoinsHuman.ToString();
                    }
                    break;
                case 2:
                    if (this.Image2_img.Source == null)
                    {

                        Uri zdrojBonus2 = new Uri(@"C:\Users\hanak\source\repos\WpfApp22\WpfApp22\ImagesBonus\Ponozky.png");
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure3_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        MessageBox.Show("    Tvůj loot je: \n   " +
                                        "    Coiny + 12000   \n   " +
                                        "    Fusakle Adélky - do dalších levelu potřebuješ  získat o 100 Zkušeností méně ");
                        this.human.CoinsHuman = human.CoinsHuman + 12000;

                        this.human.ExperienceNext = human.ExperienceNext - 100;
                        this.Coins_lbl.Content = human.CoinsHuman.ToString();
                        this.Image2_img.Source = new BitmapImage(zdrojBonus2);
                    }
                    else
                    {
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure3_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        MessageBox.Show("Získáváš 5000 Coinů");
                        human.CoinsHuman = human.CoinsHuman + 5000;
                        this.Coins_lbl.Content = human.CoinsHuman.ToString();
                    }
                    break;
                case 3:
                    if (this.Image3_img.Source == null)
                    {
                        Uri zdrojBonus3 = new Uri(@"C:\Users\hanak\source\repos\WpfApp22\WpfApp22\ImagesBonus\BonusDveře.png");
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure3_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        MessageBox.Show("    Tvůj loot je: \n   " +
                                        "    Při boji se budeš schovávat za dveře a utrpíš méně škod   \n   " +
                                        "    -50 Damage Enemy");
                        this.computer.Strenght = computer.Strenght - 50;
                        this.StrenghtComputer_lbl.Content = computer.StrenghtComplet();
                        this.Image3_img.Source = new BitmapImage(zdrojBonus3);
                    }
                    else
                    {
                        this.Treaseure1_img.Source = null;
                        this.Treaseure2_img.Source = null;
                        this.Treaseure3_img.Source = null;
                        this.Treaseure4_img.Source = null;
                        MessageBox.Show("Získáváš 5000 Coinů");
                        human.CoinsHuman = human.CoinsHuman + 5000;
                        this.Coins_lbl.Content = human.CoinsHuman.ToString();
                    }
                    break;

                default:
                    break;
            }

        }
        //Poklady standardní nález
        public void TreasureStandard()
        {
            Random ran = new Random();
            int a = ran.Next(20, 1200);

            if (a == 666)
            {

                
                MessageBox.Show( "Našel jsi válečný poklad\n\n" +
                                            "" +
                                 "   1,000,000 Coinů !!!");
                this.Treaseure1_img.Source = null;
                this.Treaseure2_img.Source = null;
                this.Treaseure3_img.Source = null;
                this.Treaseure4_img.Source = null;                
                human.CoinsHuman = human.CoinsHuman + 1000000;
                this.Coins_lbl.Content = human.CoinsHuman.ToString();
            }
            else
            {
                this.Treaseure1_img.Source = null;
                this.Treaseure2_img.Source = null;
                this.Treaseure3_img.Source = null;
                this.Treaseure4_img.Source = null;
                MessageBox.Show("Získáváš " + a.ToString()+ " Coinů");
                human.CoinsHuman = human.CoinsHuman + a;
                this.Coins_lbl.Content = human.CoinsHuman.ToString();
            }


        }
        //Poklady o stupeň vyyšší nález
        public void TreasureStandardBig()
        {
            Random ran = new Random();
            int a = ran.Next(1200, 3000);

            if (a == 666 || a ==1200)
            {
                MessageBox.Show("Našel jsi válečný poklad\n\n" +
                                            "" +
                                 "   1,000,000 Coinů !!!");
                this.Treaseure1_img.Source = null;
                this.Treaseure2_img.Source = null;
                this.Treaseure3_img.Source = null;
                this.Treaseure4_img.Source = null;
                human.CoinsHuman = human.CoinsHuman + 1000000;
                this.Coins_lbl.Content = human.CoinsHuman.ToString();
            }
            else
            {
                this.Treaseure1_img.Source = null;
                this.Treaseure2_img.Source = null;
                this.Treaseure3_img.Source = null;
                this.Treaseure4_img.Source = null;
                MessageBox.Show("Získáváš " + a.ToString() + " Coinů");
                human.CoinsHuman = human.CoinsHuman + a;
                this.Coins_lbl.Content = human.CoinsHuman.ToString();
            }


        }
        //Coiny bonus, jen jeden bonus metoda
        public bool CoinyBonus()
        {           
            if(this.Image4_img.Source !=null )
            {
                return true;
            }
            return false;
        }
        //Coiny Kytka , jen jeden bonus metoda
        public bool FlowerBonus()
        {
            if (this.Image4_img.Source != null)
            {
                return true;
            }
            return false;
        }
        //Prodej bonusové věci 1
        private void Image1_img_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Opravdu chceš prodat tento předmět za 25,000 Coinů?", "Pozor", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)            
            {
                this.Image1_img.Source = null;
                this.human.CoinsHuman = human.CoinsHuman + 25000;
                this.Coins_lbl.Content = human.CoinsHuman.ToString();
                this.human.BonusStrenght = human.BonusStrenght - 129;
                this.StrenghtHuman_lbl.Content = human.StrenghtComplet().ToString();
            }
            else
            {
                return;
            }
        }
        //Prodej bonusové věci 2
        private void Image2_img_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Opravdu chceš prodat tento předmět za 19,000 Coinů?", "Pozor", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                this.Image2_img.Source = null;
                this.human.CoinsHuman = human.CoinsHuman + 19000;
                this.human.ExperienceNext = human.ExperienceNext + 100;
                this.Coins_lbl.Content = human.CoinsHuman.ToString();
            }
            else
            {
                return;
            }
        }
        //Prodej bonusové věci 3
        private void Image3_img_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Opravdu chceš prodat tento předmět za 2,000 Coinů?", "Pozor", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                this.Image3_img.Source = null;
                this.human.CoinsHuman = human.CoinsHuman + 2000;
                this.computer.Strenght = computer.Strenght - 50;
                this.StrenghtComputer_lbl.Content = computer.StrenghtComplet();
                this.Coins_lbl.Content = human.CoinsHuman.ToString();

            }
            else
            {
                return;
            }
        }
        //Prodej bonusové věci 4
        private void Image4_img_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Opravdu chceš prodat tento předmět za 50,000 Coinů?", "Pozor", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                this.Image4_img.Source = null;
                this.human.CoinsHuman = human.CoinsHuman + 50000;                
                this.Coins_lbl.Content = human.CoinsHuman.ToString();
            }
            else
            {
                return;
            }
        }
        //Koupení Síly po 10ti bodech pravým tlačítkem
        private void BuyStrenght_btn_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.human.CoinsHuman >= 300)
            {
                this.human.Strenght = human.Strenght + 300;
                this.StrenghtHuman_lbl.Content = human.StrenghtComplet().ToString();
                this.human.CoinsHuman = human.CoinsHuman - 300;
                this.Coins_lbl.Content = human.CoinsHuman.ToString();

            }
            else
            {
                return;
                //MessageBox.Show("Nemáš dostatek Conů");
            }
        }

    }

}
