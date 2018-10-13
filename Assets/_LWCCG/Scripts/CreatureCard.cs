using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWCCG
{
    [CreateAssetMenu(fileName = "New Creature Card", menuName = "Little Witch CCG/Creature Card")]
    public class CreatureCard : Card
    {
        public int energyCapacity;

        private int currentEnergy;

        public int Energy()
        {
            return currentEnergy;
        }

        public void Energize(int energyIncrement)
        {
            currentEnergy += energyIncrement;
        }
    }
}