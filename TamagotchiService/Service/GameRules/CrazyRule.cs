using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Model;

namespace TamagotchiService.GameRules {
    public class CrazyRule : IRule {

        private static readonly Random rand = new Random();

        public Tamagotchi Execute(Tamagotchi tamagotchi) {
            if (tamagotchi == null) throw new Exception("Tamagotchi is null");
            tamagotchi.IsCrazy = tamagotchi.HealthValue >= 100 ? true : false;
            int rv = rand.Next(0, 101);
            if (tamagotchi.IsCrazy && rv > 50)
                tamagotchi.IsDead = true;
            return tamagotchi;
        }
    }
}