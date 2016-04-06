using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TamagotchiService.GameRules;
using TamagotchiService.Model;

namespace WCF.TEST.Model {
    [TestClass()]
    public class GameRuleTest {

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
        public void BoredRuleTest() {
            var t = new Tamagotchi();
            t.BoredomValue = 100;
            t.LastAccess = DateTime.UtcNow.AddHours(-1).AddMinutes(-30);
            var rule = new BoredRule();
            t.BoredomValue = rule.Execute(t).BoredomValue;
            Assert.AreEqual(100, t.BoredomValue);

            t.BoredomValue = 50;
            t.LastAccess = DateTime.UtcNow.AddHours(-1).AddMinutes(-30);
            rule = new BoredRule();
            t.BoredomValue = rule.Execute(t).BoredomValue;
            Assert.AreEqual(65, t.BoredomValue);

            t.BoredomValue = 5;
            t.LastAccess = DateTime.UtcNow.AddHours(1).AddMinutes(30);
            rule = new BoredRule();
            t.BoredomValue = rule.Execute(t).BoredomValue;
            Assert.AreEqual(5, t.BoredomValue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Tamagotchi is null")]
        public void BoredRuleNullCheck() {
            var r = new BoredRule().Execute(null);
        }

        [TestMethod()]
        public void CrazyRuleTest() {
            var t = new Tamagotchi();
            t.HealthValue = 100;
            var rule = new CrazyRule();
            t.IsCrazy = rule.Execute(t).IsCrazy;
            Assert.AreEqual(true, t.IsCrazy);

            t.HealthValue = 99;
            rule = new CrazyRule();
            t.IsCrazy = rule.Execute(t).IsCrazy;
            Assert.AreNotEqual(true, t.IsCrazy);

            t.HealthValue = 110;
            rule = new CrazyRule();
            t.IsCrazy = rule.Execute(t).IsCrazy;
            Assert.AreEqual(true, t.IsCrazy);

            t.IsDead = false;
            t.HealthValue = 100;
            t.IsCrazy = true;
            rule = new CrazyRule();
            var result = new List<bool>();
            for (int i = 0; i < 8; i++) {
                result.Add(rule.Execute(t).IsDead);
                Thread.Sleep(1000);
            }
            //foreach(var i in result) {
            //    TestContext.WriteLine(i.ToString());
            //}
            Assert.AreEqual(true, result.Contains(true) && result.Contains(false));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Tamagotchi is null")]
        public void CrazyRuleNullCheck() {
            var r = new CrazyRule().Execute(null);
        }

        [TestMethod()]
        public void ExhaustedRuleTest() {
            var t = new Tamagotchi();
            t.SleepValue = 50;
            t.LastAccess = DateTime.UtcNow.AddHours(-1).AddMinutes(-30);
            var rule = new ExhaustedRule();
            t.SleepValue = rule.Execute(t).SleepValue;
            Assert.AreEqual(55, t.SleepValue);

            t.SleepValue = 50;
            t.LastAccess = DateTime.UtcNow.AddHours(1).AddMinutes(30);
            rule = new ExhaustedRule();
            t.SleepValue = rule.Execute(t).SleepValue;
            Assert.AreEqual(50, t.SleepValue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Tamagotchi is null")]
        public void ExhaustedRuleNullCheck() {
            var r = new ExhaustedRule().Execute(null);
        }

        [TestMethod()]
        public void FoodDeprivationTest() {
            var t = new Tamagotchi();
            t.IsDead = false;
            t.HungerValue = 100;
            t.IsAthlete = false;
            var rule = new FoodDeprivationRule();
            t.IsDead = rule.Execute(t).IsDead;
            Assert.AreEqual(true, t.IsDead);

            t.IsDead = false;
            t.HungerValue = 99;
            t.IsAthlete = true;
            rule = new FoodDeprivationRule();
            t.IsDead = rule.Execute(t).IsDead;
            Assert.AreNotEqual(true, t.IsDead);

            t.IsDead = false;
            t.HungerValue = 100;
            t.IsAthlete = true;
            rule = new FoodDeprivationRule();
            t.IsDead = rule.Execute(t).IsDead;
            Assert.AreNotEqual(true, t.IsDead);

            t.IsDead = false;
            t.HungerValue = 99;
            t.IsAthlete = false;
            rule = new FoodDeprivationRule();
            t.IsDead = rule.Execute(t).IsDead;
            Assert.AreNotEqual(true, t.IsDead);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Tamagotchi is null")]
        public void FoodDeprivationNullCheck() {
            var r = new FoodDeprivationRule().Execute(null);
        }

        [TestMethod()]
        public void SleepDeprivationTest() {
            var t = new Tamagotchi();
            t.IsDead = false;
            t.SleepValue = 100;
            t.IsAthlete = false;
            var rule = new SleepDeprivationRule();
            t.IsDead = rule.Execute(t).IsDead;
            Assert.AreEqual(true, t.IsDead);

            t.IsDead = false;
            t.SleepValue = 99;
            t.IsAthlete = true;
            rule = new SleepDeprivationRule();
            t.IsDead = rule.Execute(t).IsDead;
            Assert.AreNotEqual(true, t.IsDead);

            t.IsDead = false;
            t.SleepValue = 100;
            t.IsAthlete = true;
            rule = new SleepDeprivationRule();
            t.IsDead = rule.Execute(t).IsDead;
            Assert.AreNotEqual(true, t.IsDead);

            t.IsDead = false;
            t.SleepValue = 99;
            t.IsAthlete = false;
            rule = new SleepDeprivationRule();
            t.IsDead = rule.Execute(t).IsDead;
            Assert.AreNotEqual(true, t.IsDead);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Tamagotchi is null")]
        public void SleepDeprivationNullCheck() {
            var r = new SleepDeprivationRule().Execute(null);
        }

        [TestMethod]
        public void MunchiesRuleTest() {
            var t = new Tamagotchi();
            t.BoredomValue = 80;
            var rule = new MunchiesRule();
            t.IsMunchies = rule.Execute(t).IsMunchies;
            Assert.AreEqual(true, t.IsMunchies);

            t.BoredomValue = 79;
            rule = new MunchiesRule();
            t.IsMunchies = rule.Execute(t).IsMunchies;
            Assert.AreNotEqual(true, t.IsMunchies);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Tamagotchi is null")]
        public void MunchiesRuleNullCheck() {
            var r = new MunchiesRule().Execute(null);
        }

        [TestMethod]
        public void AthleteRuleTest() {
            var t = new Tamagotchi();
            t.HealthValue = 20;
            var rule = new AthleteRule();
            t.IsAthlete = rule.Execute(t).IsAthlete;
            Assert.AreNotEqual(true, t.IsAthlete);

            t.HealthValue = 19;
            rule = new AthleteRule();
            t.IsAthlete = rule.Execute(t).IsAthlete;
            Assert.AreEqual(true, t.IsAthlete);

            t.HealthValue = 1;
            rule = new AthleteRule();
            t.IsAthlete = rule.Execute(t).IsAthlete;
            Assert.AreEqual(true, t.IsAthlete);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Tamagotchi is null")]
        public void AthleteRuleNullCheck() {
            var r = new AthleteRule().Execute(null);
        }

        [TestMethod()]
        public void IsolatedRuleTest() {
            var t = new Tamagotchi();
            t.HealthValue = 10;
            t.LastAccess = DateTime.UtcNow.AddHours(-1).AddMinutes(-30);
            var rule = new IsolatedRule();
            t.HealthValue = rule.Execute(t).HealthValue;
            Assert.AreEqual(15, t.HealthValue);

            t.HealthValue = 50;
            t.LastAccess = DateTime.UtcNow.AddHours(1).AddMinutes(30);
            rule = new IsolatedRule();
            t.HealthValue = rule.Execute(t).HealthValue;
            Assert.AreEqual(50, t.HealthValue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Tamagotchi is null")]
        public void IsolatedRuleNullCheck() {
            var r = new IsolatedRule().Execute(null);
        }

        [TestMethod()]
        public void HungryRuleTest() {
            var t = new Tamagotchi();
            t.HungerValue = 10;
            t.IsMunchies = false;
            t.LastAccess = DateTime.UtcNow.AddHours(-1).AddMinutes(-30);
            var rule = new HungryRule();
            t.HungerValue = rule.Execute(t).HungerValue;
            Assert.AreEqual(15, t.HungerValue);

            t.SleepValue = 50;
            t.IsMunchies = false;
            t.LastAccess = DateTime.UtcNow.AddHours(1).AddMinutes(30);
            rule = new HungryRule();
            t.SleepValue = rule.Execute(t).SleepValue;
            Assert.AreEqual(50, t.SleepValue);

            t.SleepValue = 50;
            t.IsMunchies = true;
            t.LastAccess = DateTime.UtcNow.AddHours(1).AddMinutes(30);
            rule = new HungryRule();
            t.SleepValue = rule.Execute(t).SleepValue;
            Assert.AreEqual(50, t.SleepValue);

            t.SleepValue = 50;
            t.IsMunchies = true;
            t.LastAccess = DateTime.UtcNow.AddHours(-1).AddMinutes(-30);
            rule = new HungryRule();
            t.SleepValue = rule.Execute(t).SleepValue;
            Assert.AreEqual(50, t.SleepValue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Tamagotchi is null")]
        public void HungryRuleNullCheck() {
            var r = new HungryRule().Execute(null);
        }

        [TestMethod]
        public void Testing() {
            var t = new Tamagotchi();
            t.PlayerId = 7;
            t.HungerValue = 30;
            t.SleepValue = 30;
            t.BoredomValue = 85;
            t.HealthValue = 30;
            t.TamagotchiName = "Maxie";
            t.State = "Verveeld";
            t.LastAccess = DateTime.UtcNow;
            t.IsDead = false;
            t.IsMunchies = false;
            t.ActionLocked = DateTime.UtcNow;
            t.IsAthlete = false;
            t.IsCrazy = false;

            t = t.ExecuteRules();

            t.PlayerId = 7;
            t.HungerValue = 30;
            t.SleepValue = 30;
            t.BoredomValue = 70;
            t.HealthValue = 30;
            t.TamagotchiName = "Maxie";
            t.State = "Verveeld";
            t.LastAccess = DateTime.UtcNow;
            t.IsDead = false;
            t.ActionLocked = DateTime.UtcNow;
            t.IsAthlete = false;
            t.IsCrazy = false;

            t = t.ExecuteRules();

            Assert.AreEqual(false, t.ExecuteRules().IsMunchies);
        }
    }
}
