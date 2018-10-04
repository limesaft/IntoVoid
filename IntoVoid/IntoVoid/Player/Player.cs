using IntoVoid.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoVoid
{
    class Player : LivingObject
    {
        private int PlayerLevel = 1;
        private int xp = 0;

        public Player() {
            this.HealthPoints = 9;
            this.AttackPower = 1;
            this.Crystals = 0;
        }

        public int GetAmountCrystals()
        {
            return Crystals;
        }

        public void SpendCrystals(int value)
        {
            Crystals = Crystals - value;
        }

        public void CheckLevelUp(int givenXP)
        {
            xp = xp + givenXP;

            if (xp > PlayerLevel*5)
            {
                xp = xp - PlayerLevel * 5;
                AttackPower++;
            }
        }

        public int HowMuchXPToLevel()
        {
            return PlayerLevel * 5 - xp;
        }
    }
}
