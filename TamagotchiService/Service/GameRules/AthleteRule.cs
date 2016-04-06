using System;
using TamagotchiService.Model;

namespace TamagotchiService.GameRules {
    public class AthleteRule : IRule {
        public Tamagotchi Execute(Tamagotchi tamagotchi) {
            if (tamagotchi == null) throw new Exception("Tamagotchi is null");
            tamagotchi.IsAthlete = tamagotchi.HealthValue < 20 ? true : false;
            return tamagotchi;
        }
    }
}