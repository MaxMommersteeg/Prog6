using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi.Web.Models {
    public class Home {

        public Home() {
            NewTamagotchi = new Tamagotchi();
        }
        public Tamagotchi NewTamagotchi { get; set; }
        public bool ShowFoundTamagotchies { get; set; }
    }
}