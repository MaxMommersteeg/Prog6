using System.Collections.Generic;
using System.Runtime.Serialization;
using TamagotchiService.Model;

namespace TamagotchiService.Contract {

    [DataContract]
    public class PlayerContract {
        [DataMember]
        public int PlayerId { get; set; }
        [DataMember]
        public string PlayerName { get; set; }
        [DataMember]
        public virtual ICollection<TamagotchiContract> Tamagotchies { get; set; }
    }
}