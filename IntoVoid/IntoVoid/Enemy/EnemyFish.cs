using IntoVoid.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoVoid.Enemy
{
    class EnemyFish : Enemies
    {
        EnemyFish()
        {
            this.Crystals = 5;
            this.AttackPower = 1;
            this.HealthPoints = 1;
        }
    }
}
