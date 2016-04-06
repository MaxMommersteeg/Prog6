using System;
using System.Runtime.Serialization;
using TamagotchiService.Model;

namespace TamagotchiService.Contract {

    [DataContract]
    public class TamagotchiContract {

        [DataMember]
        public int TamagotchiId { get; set; }

        [DataMember]
        public string TamagotchiName { get; set; }

        [DataMember]
        public int Hunger { get; set; }

        [DataMember]
        public int Sleep { get; set; }

        [DataMember]
        public int Boredom { get; set; }

        [DataMember]
        public int Health { get; set; }

        [DataMember]
        public int PlayerId { get; set; }
        [DataMember]
        public virtual PlayerContract Player { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public DateTime LastAccess { get; set; }

        [DataMember]
        public DateTime ActionLocked { get; set; }

        [DataMember]
        public bool IsDead { get; set; }

        [DataMember]
        public bool IsMunchies { get; set; }

        [DataMember]
        public bool IsAthlete { get; set; }

        [DataMember]
        public bool IsCrazy { get; set; }
    }
}