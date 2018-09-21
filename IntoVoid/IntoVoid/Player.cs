using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoVoid
{
    class Player
    {
        private int _playerLevel = 1;
        private int _attackPower = 1;
        private int xp = 0;

        public Player() {}
        public int PlayerLevel { get => _playerLevel; set => _playerLevel = value; }
        public int AttackPower { get => _attackPower; set => _attackPower = value; }
        public int Xp { get => xp; set => xp = value; }

        public void CheckLevelUp()
        {
            if (xp > PlayerLevel*5)
            {
                xp = xp - PlayerLevel * 5;
                AttackPower++;
                PlayerLevel++;
            }
        }
    }
}
