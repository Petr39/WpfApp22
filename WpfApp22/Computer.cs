using System;

namespace WpfApp22
{
    public class Computer
    {
        //public int Coiny = 0;
        public int LevelComputer = 1;
        //public int Experience = 0;
        //public int ExperienceNext = 0;      
        public int Strenght = 50;
        public int Life = 1000;
        public int BonusStrenght = 10;
        public int BonusLife = 0;
        public int LifeProgres = 1000;
        public int LifeMaxProgres = 1000;
        public int Attack = 0;
        

        //Život kompletní Computer
        public int LifeComplet()
        {
            int LiveMaximum;
            LiveMaximum = Life + BonusLife;
            return LiveMaximum;
        }
        //Život kompletní Computer
        public int StrenghtComplet()
        {
            int StrenghtMax;
            StrenghtMax = Strenght + BonusStrenght;
            return StrenghtMax;
        }
        //Život komplet progressbar Computer
        public int LifeCompletProgress()
        {
            LifeProgres = LifeMaxProgres;
            return LifeProgres;
        }
        //Aktuální život zobrazení v životech a progressu Computer
        public int LifeActual()
        {
            LifeProgres = LifeComplet();
            return LifeProgres;
        }
        //Útok computeru komplet
        public int AttackComplet()
        {
            Attack = StrenghtComplet() + LevelComputer * 7;
            return Attack;
        }


        
    }
}
