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
        private int _healthPoints = 9;
        private int _attackPower = 1;
        private int _crystals = 0;
        private int xp = 0;

        public Player() {}

        public int GetAmountCrystals()
        {
            return _crystals;
        }

        public void SpendCrystals(int value)
        {
            _crystals = _crystals - value;
        }
        public int GetHealPoints()
        {
            return _healthPoints;
        }

        public void SetHealPoints(int value)
        {
            _healthPoints = _healthPoints - value;
        }

        public int AttackPower { get => _attackPower; set => _attackPower = value; }

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
