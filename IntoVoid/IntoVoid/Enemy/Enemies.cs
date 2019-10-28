using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoVoid.AbstractClasses
{
    abstract class Enemies 
    {
        private int _healthPoints;
        private int _attackPower;
        private int _crystals;

        public int AttackPower { get => _attackPower; set => _attackPower = value; }
        public int HealthPoints { get => _healthPoints; set => _healthPoints = value; }
        public int Crystals { get => _crystals; set => _crystals = value; }

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
