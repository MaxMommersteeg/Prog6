using Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web.Configuration;
using TamagotchiService.Contract;
using TamagotchiService.Model;
using TamagotchiService.Repository;

namespace TamagotchiService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TService.svc or TService.svc.cs at the Solution Explorer and start debugging.
    public class TService : ITService {

        public TService() {
            Thread t = new Thread(ApplyTamagotchiRules);
            t.Start();
        }

        public void ApplyTamagotchiRules() {
            using (var db = new Context()) {
                //Create instance of tamagotchi Repository
                var tamagotchiRepo = new TamagotchiRepository(db);
                while (true) {
                    //Get all alive tamagotchies
                    var tamagotchies = tamagotchiRepo.Find(x => !x.IsDead);
                    if (tamagotchies != null && tamagotchies.Count() > 0) {
                        //Iterate over tamagotchies
                        foreach (var t in tamagotchies) {
                            if(Convert.ToInt32(Math.Floor((DateTime.UtcNow - t.LastAccess).TotalHours)) >= 1) {
                                var temp = t.ExecuteRules();
                                db.Entry(temp).State = EntityState.Modified;
                                try {
                                    db.SaveChanges();
                                } catch(Exception ex) {
                                    Debug.WriteLine(ex.Message);
                                }
                            }
                        }
                    }
                    Thread.Sleep(600000);
                }
            }
        }

        public PlayerContract GetAndOrCreatePlayer(PlayerContract player) {
            if (String.IsNullOrWhiteSpace(player.PlayerName)) {
                return null;
            }
            using (var db = new Context()) {
                var playerRepo = new PlayerRepository(db);
                //Check if player already exists.
                var existingPlayer = playerRepo.Find(x => x.PlayerName.ToLower() == player.PlayerName.ToLower());
                if (existingPlayer.Count() > 0)
                    return new PlayerContract() { PlayerId = existingPlayer.FirstOrDefault().PlayerId, PlayerName = existingPlayer.FirstOrDefault().PlayerName };
                var newPlayer = new Player();
                newPlayer.PlayerName = player.PlayerName;
                playerRepo.Add(newPlayer);
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
                return new PlayerContract() { PlayerId = newPlayer.PlayerId, PlayerName = newPlayer.PlayerName };
            }
        }

        public int CreatePlayer(PlayerContract player) {
            if(String.IsNullOrWhiteSpace(player.PlayerName)) {
                return -1;
            }
            using(var db = new Context()) {
                var playerRepo = new PlayerRepository(db);
                //Check if player already exists.
                var existingPlayer = playerRepo.Find(x => x.PlayerName.ToLower() == player.PlayerName.ToLower());
                if (existingPlayer.Count() > 0)
                    return existingPlayer.FirstOrDefault().PlayerId;
                var newPlayer = new Player();
                newPlayer.PlayerName = player.PlayerName;
                playerRepo.Add(newPlayer);
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                    return -1;
                }
                return newPlayer.PlayerId;
            }
        }

        public PlayerContract GetPlayer(int playerId) {
            using(var db = new Context()) {
                var playerRepo = new PlayerRepository(db);
                var existingplayer = playerRepo.Get(playerId);
                if (existingplayer == null)
                    return null;
                return new PlayerContract() {
                    PlayerId = existingplayer.PlayerId,
                    PlayerName = existingplayer.PlayerName
                };
            }
        }

        public int CreateTamagotchi(TamagotchiContract tamagotchi) {
            if(String.IsNullOrWhiteSpace(tamagotchi.TamagotchiName)) {
                return -1;
            }
            using(var db = new Context()) {
                var tamagotchiRepo = new TamagotchiRepository(db);
                var newTamagotchi = new Tamagotchi();
                newTamagotchi.TamagotchiName = tamagotchi.TamagotchiName;
                var newPlayer = new Player() {
                    PlayerId = tamagotchi.Player.PlayerId,
                    PlayerName = tamagotchi.Player.PlayerName,
                };
                newTamagotchi.PlayerId = newPlayer.PlayerId;
                newTamagotchi.ActionLocked = new DateTime(1900, 1, 1);
                newTamagotchi.LastAccess = DateTime.UtcNow;
                db.Entry(newTamagotchi).State = System.Data.Entity.EntityState.Added;
                tamagotchiRepo.Add(newTamagotchi);
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                    return -1;
                }
                return newTamagotchi.TamagotchiId;
            }
        }

        public TamagotchiContract GetTamagotchiById(int tamagotchiId) {
            using (var db = new Context()) {
                var tamagotchiRepo = new TamagotchiRepository(db);
                var tamagotchi = tamagotchiRepo.Get(tamagotchiId);
                //Client is able to handle dissapointments :)
                if (tamagotchi == null)
                    return null;
                //Load tamagotchi model intro contract and return the result
                return Helpers.DataConversion.TamagotchiConversion.ConvertTamagotchiToTamagotchiConract(tamagotchi);
            }
        }

        public List<TamagotchiContract> GetTamagotchiesForPlayer(int playerId) {
            using(var db = new Context()) {
                var tamagotchiRepo = new TamagotchiRepository(db);
                var tamagotchies = tamagotchiRepo.Find(x => x.Player != null && x.Player.PlayerId == playerId);
                if (tamagotchies.Count() == 0)
                    return null;

                var tamagotchiContracts = new List<TamagotchiContract>();
                foreach (var t in tamagotchies) {
                    tamagotchiContracts.Add(GetTamagotchiById(t.TamagotchiId));
                }
                return tamagotchiContracts;
            }
        }

        public void Eat(int tamagotchiId) {
            using (var db = new Context()) {
                var tamagotchiRepo = new TamagotchiRepository(db);
                var tamagotchi = tamagotchiRepo.Get(tamagotchiId);
                //Check if we are able to retrieve a tamagotchi by the given tamagotchiId
                if (tamagotchi == null)
                    return;
                if (tamagotchi.IsDead)
                    return;
                if (tamagotchi.ActionLocked > DateTime.UtcNow)
                    return;
                if (tamagotchi.HungerValue == 0)
                    return;
                tamagotchi.Eat();
                tamagotchi.ActionLocked = DateTime.UtcNow.AddSeconds(Convert.ToInt32(WebConfigurationManager.AppSettings["eatLockedSeconds"]));
                try {
                    db.SaveChanges();
                } catch(Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public void Sleep(int tamagotchiId) {
            using (var db = new Context()) {
                var tamagotchiRepo = new TamagotchiRepository(db);
                var tamagotchi = tamagotchiRepo.Get(tamagotchiId);
                //Check if we are able to retrieve a tamagotchi by the given tamagotchiId
                if (tamagotchi == null)
                    return;
                if (tamagotchi.IsDead)
                    return;
                if (tamagotchi.ActionLocked > DateTime.UtcNow)
                    return;
                if (tamagotchi.SleepValue == 0)
                    return;
                tamagotchi.Sleep();
                tamagotchi.ActionLocked = DateTime.UtcNow.AddSeconds(Convert.ToInt32(WebConfigurationManager.AppSettings["sleepLockedSeconds"]));
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public void Play(int tamagotchiId) {
            using (var db = new Context()) {
                var tamagotchiRepo = new TamagotchiRepository(db);
                var tamagotchi = tamagotchiRepo.Get(tamagotchiId);
                //Check if we are able to retrieve a tamagotchi by the given tamagotchiId
                if (tamagotchi == null)
                    return;
                if (tamagotchi.IsDead)
                    return;
                if (tamagotchi.ActionLocked > DateTime.UtcNow)
                    return;
                if (tamagotchi.BoredomValue == 0)
                    return;
                tamagotchi.Play();
                if(tamagotchi.BoredomValue < 0) { tamagotchi.BoredomValue = 0; }
                tamagotchi.ActionLocked = DateTime.UtcNow.AddSeconds(Convert.ToInt32(WebConfigurationManager.AppSettings["playLockedSeconds"]));
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public void Workout(int tamagotchiId) {
            using (var db = new Context()) {
                var tamagotchiRepo = new TamagotchiRepository(db);
                var tamagotchi = tamagotchiRepo.Get(tamagotchiId);
                //Check if we are able to retrieve a tamagotchi by the given tamagotchiId
                if (tamagotchi == null)
                    return;
                if (tamagotchi.IsDead)
                    return;
                if (tamagotchi.ActionLocked > DateTime.UtcNow)
                    return;
                if (tamagotchi.HealthValue == 0)
                    return;
                tamagotchi.Workout();
                if (tamagotchi.HealthValue < 0) { tamagotchi.HealthValue = 0; }
                tamagotchi.ActionLocked = DateTime.UtcNow.AddSeconds(Convert.ToInt32(WebConfigurationManager.AppSettings["workoutLockedSeconds"]));
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public void Hug(int tamagotchiId) {
            using (var db = new Context()) {
                var tamagotchiRepo = new TamagotchiRepository(db);
                var tamagotchi = tamagotchiRepo.Get(tamagotchiId);
                //Check if we are able to retrieve a tamagotchi by the given tamagotchiId
                if (tamagotchi == null)
                    return;
                if (tamagotchi.IsDead)
                    return;
                if (tamagotchi.ActionLocked > DateTime.UtcNow)
                    return;
                if (tamagotchi.HealthValue == 0)
                    return;
                tamagotchi.Hug();
                if (tamagotchi.HealthValue < 0) { tamagotchi.HealthValue = 0; }
                tamagotchi.ActionLocked = DateTime.UtcNow.AddSeconds(Convert.ToInt32(WebConfigurationManager.AppSettings["hugLockedSeconds"]));
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
