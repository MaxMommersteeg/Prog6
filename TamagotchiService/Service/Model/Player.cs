using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TamagotchiService.Contract;

namespace TamagotchiService.Model {
    public class Player {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public virtual ICollection<Tamagotchi> Tamagotchies { get; set; }
    }
}