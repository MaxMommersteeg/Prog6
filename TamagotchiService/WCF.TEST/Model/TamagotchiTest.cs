using Microsoft.VisualStudio.TestTools.UnitTesting;
using TamagotchiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiService.GameRules;
using System.Diagnostics;
using System.Threading;

namespace TamagotchiService.Model.Tests {
    [TestClass()]
    public class TamagotchiTest {

        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void TamagotchiConstructorTest() {
            var t = new Tamagotchi();
            Assert.AreEqual("Normaal", t.State);
        }

        [TestMethod()]
        public void EatTest() {
            var t = new Tamagotchi();
            t.Eat();
            Assert.AreEqual(0, t.HungerValue);
        }

        [TestMethod()]
        public void SleepTest() {
            var t = new Tamagotchi();
            t.Sleep();
            Assert.AreEqual(0, t.SleepValue);
        }

        [TestMethod()]
        public void PlayTest() {
            var t = new Tamagotchi();
            t.Play();
            Assert.AreEqual(0, t.BoredomValue = 0);

            t.BoredomValue = 120;
            Assert.AreEqual(100, t.BoredomValue);

            t.BoredomValue = 120;
            t.Play();
            Assert.AreEqual(90, t.BoredomValue);

            t.BoredomValue = 20;
            t.Play();
            Assert.AreEqual(10, t.BoredomValue);
        }

        [TestMethod()]
        public void WorkoutTest() {
            var t = new Tamagotchi();
            t.Workout();
            Assert.AreEqual(0, t.HealthValue = 0);

            t.HealthValue = 120;
            Assert.AreEqual(100, t.HealthValue);

            t.HealthValue = 120;
            t.Workout();
            Assert.AreEqual(95, t.HealthValue);

            t.HealthValue = 20;
            t.Workout();
            Assert.AreEqual(15, t.HealthValue);
        }

        [TestMethod()]
        public void HugTest() {
            var t = new Tamagotchi();
            t.Hug();
            Assert.AreEqual(0, t.HealthValue = 0);

            t.HealthValue = 120;
            Assert.AreEqual(100, t.HealthValue);

            t.HealthValue = 120;
            t.Hug();
            Assert.AreEqual(90, t.HealthValue);

            t.HealthValue = 20;
            t.Hug();
            Assert.AreEqual(10, t.HealthValue);
        }

        [TestMethod]
        public void CheckStates() {
            var t = new Tamagotchi();
            t.IsDead = false;
            t.BoredomValue = 20;
            t.HealthValue = 50;
            t.HungerValue = 45;
            t.SleepValue = 20;
            Assert.AreEqual("Ongezond", t.State);

            t.IsDead = false;
            t.BoredomValue = 10;
            t.HealthValue = 20;
            t.HungerValue = 88;
            t.SleepValue = 99;
            Assert.AreEqual("Slaperig", t.State);

            t.IsDead = false;
            t.BoredomValue = 100;
            t.HealthValue = 20;
            t.HungerValue = 88;
            t.SleepValue = 99;
            Assert.AreEqual("Verveeld", t.State);

            t.IsDead = false;
            t.BoredomValue = 10;
            t.HealthValue = 1;
            t.HungerValue = 99;
            t.SleepValue = 1;
            Assert.AreEqual("Hongerig", t.State);

            t.IsDead = true;
            t.BoredomValue = 0;
            t.HealthValue = 100;
            t.HungerValue = 100;
            t.SleepValue = 0;
            Assert.AreEqual("Dood", t.State);
        }
    }
}