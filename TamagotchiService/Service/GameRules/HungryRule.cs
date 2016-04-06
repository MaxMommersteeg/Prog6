using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Model;

namespace TamagotchiService.GameRules {
    public class HungryRule : IRule {
        public Tamagotchi Execute(Tamagotchi tamagotchi) {
            if (tamagotchi == null) throw new Exception("Tamagotchi is null");
            int hours = Convert.ToInt32(Math.Floor((DateTime.UtcNow - tamagotchi.LastAccess).TotalHours));
            if (hours < 0)
                return tamagotchi;
            if (tamagotchi.IsMunchies)
                tamagotchi.HungerValue += (hours * 10);
            else
                tamagotchi.HungerValue += (hours * 5);
            return tamagotchi;
        }
    }
}