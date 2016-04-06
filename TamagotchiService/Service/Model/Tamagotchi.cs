using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using TamagotchiService.GameRules;

namespace TamagotchiService.Model {
    public class Tamagotchi {

        private StandardKernel ninjectKernal;
        private IRule rule { get; set; }

        public Tamagotchi() {
            ninjectKernal = new StandardKernel();
            ninjectKernal.Load(Assembly.GetExecutingAssembly());

            IsMunchies = false;
            IsAthlete = true;
            IsCrazy = false;

            //Set default state
            State = "Normaal";
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TamagotchiId { get; set; }
        public string TamagotchiName { get; set; }

        private int _hungervalue;
        public int HungerValue {
            get { return _hungervalue; }
            set {
                _hungervalue = value < 0 ? 0 : value;
                _hungervalue = value > 100 ? 100 : value;
                UpdateTamagotchiState();
            }
        }

        private int _sleepvalue;
        public int SleepValue {
            get { return _sleepvalue; }
            set {
                _sleepvalue = value < 0 ? 0 : value;
                _sleepvalue = value > 100 ? 100 : value;
                UpdateTamagotchiState();
            }
        }

        private int _boredomvalue;
        public int BoredomValue {
            get { return _boredomvalue; }
            set {
                _boredomvalue = value < 0 ? 0 : value;
                _boredomvalue = value > 100 ? 100 : value;
                UpdateTamagotchiState();
            }
        }

        private int _healthvalue;
        public int HealthValue {
            get { return _healthvalue; }
            set {
                _healthvalue = value < 0 ? 0 : value;
                _healthvalue = value > 100 ? 100 : value;
                UpdateTamagotchiState();
            }
        }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public string State { get; set; }

        private bool _isdead;
        public bool IsDead {
            get { return _isdead; }
            set {
                _isdead = value;
                UpdateTamagotchiState();
            }
        }

        public DateTime LastAccess { get; set; }

        public DateTime ActionLocked { get; set; }

        public bool IsMunchies { get; set; }

        public bool IsAthlete { get; set; }

        public bool IsCrazy { get; set; }

        public void Eat() {
            HungerValue = 0;
        }

        public void Sleep() {
            SleepValue = 0;
        }

        public void Play() {
            BoredomValue -= 10;
        }

        public void Workout() {
            HealthValue -= 5;
        }

        public void Hug() {
            HealthValue -= 10;
        }

        private void UpdateTamagotchiState() {
            if(IsDead) {
                State = "Dood";
                return;
            }
            //Dictionary with all tamagotchi properties, by name and current value 
            var tProperties = new Dictionary<string, int> {
                { "Hongerig",  HungerValue },
                { "Slaperig", SleepValue },
                { "Verveeld", BoredomValue },
                { "Ongezond", HealthValue }
            };
            //Get highest entry
            State = tProperties.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }

        public Tamagotchi ExecuteRules() {
            rule = new BoredRule();
            BoredomValue = rule.Execute(this).BoredomValue;
            rule = new ExhaustedRule();
            SleepValue = rule.Execute(this).SleepValue;
            rule = new HungryRule();
            HungerValue = rule.Execute(this).HungerValue;
            rule = new IsolatedRule();
            HealthValue = rule.Execute(this).HealthValue;
            rule = new CrazyRule();
            IsCrazy = rule.Execute(this).IsCrazy;
            rule = new AthleteRule();
            IsAthlete = rule.Execute(this).IsAthlete;
            rule = new MunchiesRule();
            IsMunchies = rule.Execute(this).IsMunchies;
            rule = new FoodDeprivationRule();
            IsDead = rule.Execute(this).IsDead;
            if (IsDead) return this;
            rule = new SleepDeprivationRule();
            IsDead = rule.Execute(this).IsDead;
            if (IsDead) return this;
            LastAccess = DateTime.UtcNow;
            return this;
        }
    }
}