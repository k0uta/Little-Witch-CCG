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

        public delegate void CreatureCardHandler();

        public CreatureCardHandler OnEnergize;

        public int Energy()
        {
            return currentEnergy;
        }

        public void Energize(int energyIncrement = 1)
        {
            Debug.Log("Energizing from " + currentEnergy + " to " + (currentEnergy + energyIncrement));
            currentEnergy += energyIncrement;

            TryOnEnergize();
        }

        void TryOnEnergize()
        {
            if (OnEnergize != null)
                OnEnergize();
        }
    }
}