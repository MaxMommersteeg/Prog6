using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi.Web.Models {
    public class Tamagotchi {
        public int TamagotchiId { get; set; }
        public string TamagotchiName { get; set; }
        public int Hunger { get; set; }
        public int Sleep { get; set; }
        public int Boredom { get; set; }
        public int Health { get; set; }
        public string State { get; set; }
        public DateTime LastAccess { get; set; }
        public DateTime ActionLocked { get; set; }
        public bool IsDead { get; set; }
        public bool IsMunchies { get; set; }
        public bool IsAthlete { get; set; }
        public bool IsCrazy { get; set; }
        public bool IsLocked { get; set; }
    }
}