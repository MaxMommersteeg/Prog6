using System;
using System.Collections.Generic;
using Tamagotchi.Web.TamagotchiReference;

namespace Tamagotchi.Web.Helpers.DataConversion.Tamagotchi {
    public static class ConvertTamagotchi {
        public static Models.Tamagotchi ConvertTamagotchiContractToTamagotchi(TamagotchiContract tc) {
            return new Models.Tamagotchi() {
                TamagotchiId = tc.TamagotchiId,
                TamagotchiName = tc.TamagotchiName, Hunger = tc.Hunger, Boredom = tc.Boredom,
                Sleep = tc.Sleep, Health = tc.Health, State = tc.State,
                LastAccess = tc.LastAccess, ActionLocked = tc.ActionLocked, IsDead = tc.IsDead,
                IsAthlete = tc.IsAthlete, IsCrazy = tc.IsCrazy, IsMunchies = tc.IsMunchies, IsLocked = tc.ActionLocked > DateTime.UtcNow
            };
        }

        public static List<Models.Tamagotchi> ConvertTamagotchiConractListToTamagotchiList(List<TamagotchiContract> tcl) {
            var temp = new List<Models.Tamagotchi>();
            foreach (var tc in tcl) {
                temp.Add(ConvertTamagotchiContractToTamagotchi(tc));
            }
            return temp;
        }
    }
}