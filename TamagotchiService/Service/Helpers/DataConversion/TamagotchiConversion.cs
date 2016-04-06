using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Contract;
using TamagotchiService.Model;

namespace TamagotchiService.Helpers.DataConversion {
    public static class TamagotchiConversion {
        public static TamagotchiContract ConvertTamagotchiToTamagotchiConract(Tamagotchi tamagotchi) {
            if (tamagotchi == null) return null;
            return new TamagotchiContract() {
                TamagotchiId = tamagotchi.TamagotchiId,
                TamagotchiName = tamagotchi.TamagotchiName,
                Hunger = tamagotchi.HungerValue,
                Sleep = tamagotchi.SleepValue,
                Boredom = tamagotchi.BoredomValue,
                Health = tamagotchi.HealthValue,
                State = tamagotchi.State,
                IsDead = tamagotchi.IsDead,
                LastAccess = tamagotchi.LastAccess,
                ActionLocked = tamagotchi.ActionLocked,
                IsMunchies = tamagotchi.IsMunchies,
                IsAthlete = tamagotchi.IsAthlete,
                IsCrazy = tamagotchi.IsCrazy
            };
        }
    }
}