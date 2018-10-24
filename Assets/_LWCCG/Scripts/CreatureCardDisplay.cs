using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace LWCCG
{
    public class CreatureCardDisplay : CardDisplay
    {

        public Text energyCap;

        public Text currentEnergy;

        protected CreatureCard creatureCard;

        public override void Start()
        {
            base.Start();
            creatureCard = ((CreatureCard)this.card);
            energyCap.text = creatureCard.energyCapacity.ToString();
            UpdateEnergyAmount();

            creatureCard.OnEnergize += UpdateEnergyAmount;
        }

        public void UpdateEnergyAmount()
        {
            currentEnergy.text = creatureCard.Energy().ToString();
        }
    }
}