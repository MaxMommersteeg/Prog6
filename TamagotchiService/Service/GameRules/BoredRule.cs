﻿using System;
using TamagotchiService.Model;

namespace TamagotchiService.GameRules {
    public class BoredRule : IRule {
        public Tamagotchi Execute(Tamagotchi tamagotchi) {
            if (tamagotchi == null) throw new Exception("Tamagotchi is null");
            int hours = Convert.ToInt32(Math.Floor((DateTime.UtcNow - tamagotchi.LastAccess).TotalHours));
            if (hours < 0)
                return tamagotchi;
            tamagotchi.BoredomValue += (hours * 15);
            return tamagotchi;
        }
    }
}