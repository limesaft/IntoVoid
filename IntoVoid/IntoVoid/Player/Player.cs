using IntoVoid.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoVoid
{
    class Player 
    {
        private int PlayerLevel = 1;
        private int xp = 0;
        private int _healthPoints;
        private int _attackPower;
        private int _crystals;

        public int AttackPower { get => _attackPower; set => _attackPower = value; }
        public int HealthPoints { get => _healthPoints; set => _healthPoints = value; }
        public int Crystals { get => _crystals; set => _crystals = value; }

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
        public int GetHealPoints()
        {
            return _healthPoints;
        }

        public void SetHealPoints(int value)
        {
            _healthPoints = _healthPoints - value;
        }
    }
}
