﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tamagotchi.Web.TamagotchiReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlayerContract", Namespace="http://schemas.datacontract.org/2004/07/TamagotchiService.Contract")]
    [System.SerializableAttribute()]
    public partial class PlayerContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PlayerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PlayerNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<Tamagotchi.Web.TamagotchiReference.TamagotchiContract> TamagotchiesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PlayerId {
            get {
                return this.PlayerIdField;
            }
            set {
                if ((this.PlayerIdField.Equals(value) != true)) {
                    this.PlayerIdField = value;
                    this.RaisePropertyChanged("PlayerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PlayerName {
            get {
                return this.PlayerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PlayerNameField, value) != true)) {
                    this.PlayerNameField = value;
                    this.RaisePropertyChanged("PlayerName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<Tamagotchi.Web.TamagotchiReference.TamagotchiContract> Tamagotchies {
            get {
                return this.TamagotchiesField;
            }
            set {
                if ((object.ReferenceEquals(this.TamagotchiesField, value) != true)) {
                    this.TamagotchiesField = value;
                    this.RaisePropertyChanged("Tamagotchies");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TamagotchiContract", Namespace="http://schemas.datacontract.org/2004/07/TamagotchiService.Contract")]
    [System.SerializableAttribute()]
    public partial class TamagotchiContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ActionLockedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BoredomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HealthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HungerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsAthleteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsCrazyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsDeadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsMunchiesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastAccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Tamagotchi.Web.TamagotchiReference.PlayerContract PlayerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PlayerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SleepField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TamagotchiIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TamagotchiNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ActionLocked {
            get {
                return this.ActionLockedField;
            }
            set {
                if ((this.ActionLockedField.Equals(value) != true)) {
                    this.ActionLockedField = value;
                    this.RaisePropertyChanged("ActionLocked");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Boredom {
            get {
                return this.BoredomField;
            }
            set {
                if ((this.BoredomField.Equals(value) != true)) {
                    this.BoredomField = value;
                    this.RaisePropertyChanged("Boredom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Health {
            get {
                return this.HealthField;
            }
            set {
                if ((this.HealthField.Equals(value) != true)) {
                    this.HealthField = value;
                    this.RaisePropertyChanged("Health");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Hunger {
            get {
                return this.HungerField;
            }
            set {
                if ((this.HungerField.Equals(value) != true)) {
                    this.HungerField = value;
                    this.RaisePropertyChanged("Hunger");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsAthlete {
            get {
                return this.IsAthleteField;
            }
            set {
                if ((this.IsAthleteField.Equals(value) != true)) {
                    this.IsAthleteField = value;
                    this.RaisePropertyChanged("IsAthlete");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsCrazy {
            get {
                return this.IsCrazyField;
            }
            set {
                if ((this.IsCrazyField.Equals(value) != true)) {
                    this.IsCrazyField = value;
                    this.RaisePropertyChanged("IsCrazy");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsDead {
            get {
                return this.IsDeadField;
            }
            set {
                if ((this.IsDeadField.Equals(value) != true)) {
                    this.IsDeadField = value;
                    this.RaisePropertyChanged("IsDead");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsMunchies {
            get {
                return this.IsMunchiesField;
            }
            set {
                if ((this.IsMunchiesField.Equals(value) != true)) {
                    this.IsMunchiesField = value;
                    this.RaisePropertyChanged("IsMunchies");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastAccess {
            get {
                return this.LastAccessField;
            }
            set {
                if ((this.LastAccessField.Equals(value) != true)) {
                    this.LastAccessField = value;
                    this.RaisePropertyChanged("LastAccess");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Tamagotchi.Web.TamagotchiReference.PlayerContract Player {
            get {
                return this.PlayerField;
            }
            set {
                if ((object.ReferenceEquals(this.PlayerField, value) != true)) {
                    this.PlayerField = value;
                    this.RaisePropertyChanged("Player");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PlayerId {
            get {
                return this.PlayerIdField;
            }
            set {
                if ((this.PlayerIdField.Equals(value) != true)) {
                    this.PlayerIdField = value;
                    this.RaisePropertyChanged("PlayerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Sleep {
            get {
                return this.SleepField;
            }
            set {
                if ((this.SleepField.Equals(value) != true)) {
                    this.SleepField = value;
                    this.RaisePropertyChanged("Sleep");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State {
            get {
                return this.StateField;
            }
            set {
                if ((object.ReferenceEquals(this.StateField, value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TamagotchiId {
            get {
                return this.TamagotchiIdField;
            }
            set {
                if ((this.TamagotchiIdField.Equals(value) != true)) {
                    this.TamagotchiIdField = value;
                    this.RaisePropertyChanged("TamagotchiId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TamagotchiName {
            get {
                return this.TamagotchiNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TamagotchiNameField, value) != true)) {
                    this.TamagotchiNameField = value;
                    this.RaisePropertyChanged("TamagotchiName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TamagotchiReference.ITService")]
    public interface ITService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/GetAndOrCreatePlayer", ReplyAction="http://tempuri.org/ITService/GetAndOrCreatePlayerResponse")]
        Tamagotchi.Web.TamagotchiReference.PlayerContract GetAndOrCreatePlayer(Tamagotchi.Web.TamagotchiReference.PlayerContract player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/GetAndOrCreatePlayer", ReplyAction="http://tempuri.org/ITService/GetAndOrCreatePlayerResponse")]
        System.Threading.Tasks.Task<Tamagotchi.Web.TamagotchiReference.PlayerContract> GetAndOrCreatePlayerAsync(Tamagotchi.Web.TamagotchiReference.PlayerContract player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/CreateTamagotchi", ReplyAction="http://tempuri.org/ITService/CreateTamagotchiResponse")]
        int CreateTamagotchi(Tamagotchi.Web.TamagotchiReference.TamagotchiContract tamagotchi);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/CreateTamagotchi", ReplyAction="http://tempuri.org/ITService/CreateTamagotchiResponse")]
        System.Threading.Tasks.Task<int> CreateTamagotchiAsync(Tamagotchi.Web.TamagotchiReference.TamagotchiContract tamagotchi);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/GetTamagotchiById", ReplyAction="http://tempuri.org/ITService/GetTamagotchiByIdResponse")]
        Tamagotchi.Web.TamagotchiReference.TamagotchiContract GetTamagotchiById(int tamagotchiId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/GetTamagotchiById", ReplyAction="http://tempuri.org/ITService/GetTamagotchiByIdResponse")]
        System.Threading.Tasks.Task<Tamagotchi.Web.TamagotchiReference.TamagotchiContract> GetTamagotchiByIdAsync(int tamagotchiId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/GetTamagotchiesForPlayer", ReplyAction="http://tempuri.org/ITService/GetTamagotchiesForPlayerResponse")]
        System.Collections.Generic.List<Tamagotchi.Web.TamagotchiReference.TamagotchiContract> GetTamagotchiesForPlayer(int playerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/GetTamagotchiesForPlayer", ReplyAction="http://tempuri.org/ITService/GetTamagotchiesForPlayerResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Tamagotchi.Web.TamagotchiReference.TamagotchiContract>> GetTamagotchiesForPlayerAsync(int playerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/Eat", ReplyAction="http://tempuri.org/ITService/EatResponse")]
        void Eat(int tamagotchiId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/Eat", ReplyAction="http://tempuri.org/ITService/EatResponse")]
        System.Threading.Tasks.Task EatAsync(int tamagotchiId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/Sleep", ReplyAction="http://tempuri.org/ITService/SleepResponse")]
        void Sleep(int tamagotchiId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/Sleep", ReplyAction="http://tempuri.org/ITService/SleepResponse")]
        System.Threading.Tasks.Task SleepAsync(int tamagotchiId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/Play", ReplyAction="http://tempuri.org/ITService/PlayResponse")]
        void Play(int tamagotchiId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/Play", ReplyAction="http://tempuri.org/ITService/PlayResponse")]
        System.Threading.Tasks.Task PlayAsync(int tamagotchiId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/Workout", ReplyAction="http://tempuri.org/ITService/WorkoutResponse")]
        void Workout(int tamagotchiId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/Workout", ReplyAction="http://tempuri.org/ITService/WorkoutResponse")]
        System.Threading.Tasks.Task WorkoutAsync(int tamagotchiId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/Hug", ReplyAction="http://tempuri.org/ITService/HugResponse")]
        void Hug(int tamagotchiId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITService/Hug", ReplyAction="http://tempuri.org/ITService/HugResponse")]
        System.Threading.Tasks.Task HugAsync(int tamagotchiId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITServiceChannel : Tamagotchi.Web.TamagotchiReference.ITService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TServiceClient : System.ServiceModel.ClientBase<Tamagotchi.Web.TamagotchiReference.ITService>, Tamagotchi.Web.TamagotchiReference.ITService {
        
        public TServiceClient() {
        }
        
        public TServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Tamagotchi.Web.TamagotchiReference.PlayerContract GetAndOrCreatePlayer(Tamagotchi.Web.TamagotchiReference.PlayerContract player) {
            return base.Channel.GetAndOrCreatePlayer(player);
        }
        
        public System.Threading.Tasks.Task<Tamagotchi.Web.TamagotchiReference.PlayerContract> GetAndOrCreatePlayerAsync(Tamagotchi.Web.TamagotchiReference.PlayerContract player) {
            return base.Channel.GetAndOrCreatePlayerAsync(player);
        }
        
        public int CreateTamagotchi(Tamagotchi.Web.TamagotchiReference.TamagotchiContract tamagotchi) {
            return base.Channel.CreateTamagotchi(tamagotchi);
        }
        
        public System.Threading.Tasks.Task<int> CreateTamagotchiAsync(Tamagotchi.Web.TamagotchiReference.TamagotchiContract tamagotchi) {
            return base.Channel.CreateTamagotchiAsync(tamagotchi);
        }
        
        public Tamagotchi.Web.TamagotchiReference.TamagotchiContract GetTamagotchiById(int tamagotchiId) {
            return base.Channel.GetTamagotchiById(tamagotchiId);
        }
        
        public System.Threading.Tasks.Task<Tamagotchi.Web.TamagotchiReference.TamagotchiContract> GetTamagotchiByIdAsync(int tamagotchiId) {
            return base.Channel.GetTamagotchiByIdAsync(tamagotchiId);
        }
        
        public System.Collections.Generic.List<Tamagotchi.Web.TamagotchiReference.TamagotchiContract> GetTamagotchiesForPlayer(int playerId) {
            return base.Channel.GetTamagotchiesForPlayer(playerId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Tamagotchi.Web.TamagotchiReference.TamagotchiContract>> GetTamagotchiesForPlayerAsync(int playerId) {
            return base.Channel.GetTamagotchiesForPlayerAsync(playerId);
        }
        
        public void Eat(int tamagotchiId) {
            base.Channel.Eat(tamagotchiId);
        }
        
        public System.Threading.Tasks.Task EatAsync(int tamagotchiId) {
            return base.Channel.EatAsync(tamagotchiId);
        }
        
        public void Sleep(int tamagotchiId) {
            base.Channel.Sleep(tamagotchiId);
        }
        
        public System.Threading.Tasks.Task SleepAsync(int tamagotchiId) {
            return base.Channel.SleepAsync(tamagotchiId);
        }
        
        public void Play(int tamagotchiId) {
            base.Channel.Play(tamagotchiId);
        }
        
        public System.Threading.Tasks.Task PlayAsync(int tamagotchiId) {
            return base.Channel.PlayAsync(tamagotchiId);
        }
        
        public void Workout(int tamagotchiId) {
            base.Channel.Workout(tamagotchiId);
        }
        
        public System.Threading.Tasks.Task WorkoutAsync(int tamagotchiId) {
            return base.Channel.WorkoutAsync(tamagotchiId);
        }
        
        public void Hug(int tamagotchiId) {
            base.Channel.Hug(tamagotchiId);
        }
        
        public System.Threading.Tasks.Task HugAsync(int tamagotchiId) {
            return base.Channel.HugAsync(tamagotchiId);
        }
    }
}
