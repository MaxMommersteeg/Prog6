using System;
using TamagotchiService.Model;

namespace TamagotchiService.GameRules {
    public class MunchiesRule : IRule {
        public Tamagotchi Execute(Tamagotchi tamagotchi) {
            if (tamagotchi == null) throw new Exception("Tamagotchi is null");
            tamagotchi.IsMunchies = tamagotchi.BoredomValue >= 80 ? true : false;
            return tamagotchi;
        }
    }
}