using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TamagotchiService.Model {
    public interface IRule {
        Tamagotchi Execute(Tamagotchi tamagotchi);
    }
}