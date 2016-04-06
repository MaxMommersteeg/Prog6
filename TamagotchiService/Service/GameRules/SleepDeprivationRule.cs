using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Model;

namespace TamagotchiService.GameRules {
    public class SleepDeprivationRule : IRule {
        public Tamagotchi Execute(Tamagotchi tamagotchi) {
            if (tamagotchi == null) throw new Exception("Tamagotchi is null");
            if (tamagotchi.SleepValue >= 100 && !tamagotchi.IsAthlete)
                tamagotchi.IsDead = true;
            return tamagotchi;
        }
    }
}