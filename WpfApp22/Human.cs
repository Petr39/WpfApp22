using System;

namespace WpfApp22
{
    public partial class Human
    {
        public int CoinsHuman = 0;
        public int LevelHuman = 1;
        public int Experience = 0;
        public int ExperienceNext = 1000;
        public int Strenght = 50;
        public int Life = 1000;
        public int BonusStrenght = 10;
        public int BonusLife = 0;
        public int LifeProgres = 1000;
        public int LifeMaxProgres = 1000;
        public int Attack = 0;

      


        //Život kompletní Human
        public int LifeComplet()
        {
            int LiveMaximum;
            LiveMaximum = Life + BonusLife;
            return LiveMaximum;
        }
        //Síla kompletní Human
        public int StrenghtComplet()
        {
            int StrenghtMax;
            StrenghtMax = Strenght + BonusStrenght ;
            return StrenghtMax;
        }
        //Život komplet progressbar Human
        public int LifeCompletProgress()
        {
            LifeProgres = LifeMaxProgres;
            return LifeProgres;
        }
        //Aktuální život zobrazení v životech a progressu Human
        public int LifeActual()
        {
            LifeProgres = LifeComplet();
            return LifeProgres;
        }
        //Útok human komplet
        public int AttackComplet()
        {
             Attack = StrenghtComplet() + LevelHuman * 2;
            return Attack;
        }
    }
}
