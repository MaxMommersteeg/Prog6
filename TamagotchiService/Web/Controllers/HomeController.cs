using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Tamagotchi.Web.Models;
using Tamagotchi.Web.TamagotchiReference;

namespace Web.Controllers {
    public class HomeController : Controller {

        private ITService service;
        private PlayerContract currentPlayer;
        private Tamagotchi.Web.Models.Tamagotchi currentTamagotchi;
        private List<Tamagotchi.Web.Models.Tamagotchi> currentPlayerTamagotchies;

        public HomeController(){
            service = new TServiceClient();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index() {
            currentPlayer = GetAndOrCreatePlayer(new PlayerContract() { PlayerName = User.Identity.Name });
            if (currentPlayer == null) {
                TempData["UserFeedback"] = "Er ging iets mis bij het ophalen van de gebruiker.";
                return RedirectToAction("Login", "User");
            }
            //Get CurrentPlayerTamagotchies
            currentPlayerTamagotchies = GetTamagotchiesForPlayer();
            var model = new Home();
            if (currentPlayerTamagotchies != null && currentPlayerTamagotchies.Count() != 0) {
                model.ShowFoundTamagotchies = true;
            }
            return View(model);
        }

        [Authorize]
        public ActionResult TamagotchiDetails(int selectedtamagotchiid) {
            currentTamagotchi = GetTamagotchi(selectedtamagotchiid);
            if(currentTamagotchi == null) {
                TempData["UserFeedback"] = "Ophalen van de geselecteerde Tamagotchi is mislukt.";
                return RedirectToAction("Index");
            }
            return View(currentTamagotchi);
        }

        [HttpPost]
        [Authorize]
        public ActionResult SaveNewTamagotchi(string tamagotchiname) {
            if (string.IsNullOrWhiteSpace(tamagotchiname)) {
                TempData["UserFeedback"] = "Geef de nieuwe tamagotchi een naam.";
                return RedirectToAction("Index");
            }
            currentPlayer = GetAndOrCreatePlayer(new PlayerContract() { PlayerName = User.Identity.Name });
            CreateTamagotchi(new TamagotchiContract() { Player = currentPlayer, TamagotchiName = tamagotchiname } );
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult ExecuteAction(int selectedtamagotchiid, string actionname) {
            var curT = GetTamagotchi(selectedtamagotchiid);
            if (curT == null) return new ContentResult() { Content = string.Format("Tamagotchi niet gevonden.") };
            if(curT.IsDead) return new ContentResult() { Content = string.Format("Gast, je tamagotchi is morsdood.") };
            if (curT.ActionLocked > DateTime.UtcNow) return new ContentResult() { Content = string.Format("Je tamagotchi moet nog bijkomen. Vanaf {0} zijn acties weer mogelijk.", curT.ActionLocked.ToLocalTime().ToString("HH:mm:ss")) };
            //See if tamagotchi is able to process an action
            switch (actionname) {
                case "EAT":
                if (curT.Hunger == 0) return new ContentResult() { Content = string.Format("Je tamagotchi heeft nog geen honger.") };
                Eat(selectedtamagotchiid);
                break;
                case "SLEEP":
                if (curT.Sleep == 0) return new ContentResult() { Content = string.Format("Je tamagotchi heeft nog geen slaap.") };
                Sleep(selectedtamagotchiid);
                break;
                case "PLAY":
                if (curT.Boredom == 0) return new ContentResult() { Content = string.Format("Je tamagotchi heeft geen zin om te spelen.") };
                Play(selectedtamagotchiid);
                break;
                case "WORKOUT":
                if (curT.Health == 0) return new ContentResult() { Content = string.Format("Je tamagotchi is kerngezond en hoeft niet te sporten.") };
                Workout(selectedtamagotchiid);
                break;
                case "HUG":
                if (curT.Health == 0) return new ContentResult() { Content = string.Format("Je tamagotchi is chagrijnig en wil niet knuffelen.") };
                Hug(selectedtamagotchiid);
                break;
                default:
                return new ContentResult() { Content = string.Format("Onbekende actie.") };
            }
            return new ContentResult() { Content = string.Format("Actie uitgevoerd.") };
        }

        public ActionResult ReloadTamagotchies() {
            var temp = GetTamagotchiesForPlayer();
            if (temp == null)
                return Json(new { });
            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        #region Service calls

        [NonAction]
        public void Eat(int tamagotchiId) {
            try {
                service.Eat(tamagotchiId);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return;
            }
        }

        [NonAction]
        public void Sleep(int tamagotchiId) {
            try {
                service.Sleep(tamagotchiId);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return;
            }
        }

        [NonAction]
        public void Play(int tamagotchiId) {
            try {
                service.Play(tamagotchiId);
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                return;
            }
        }

        [NonAction]
        public void Workout(int tamagotchiId) {
            try {
                service.Workout(tamagotchiId);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return;
            }
        }


        [NonAction]
        public void Hug(int tamagotchiId) {
            try {
                service.Hug(tamagotchiId);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return;
            }
        }

        [NonAction]
        public void CreateTamagotchi(TamagotchiContract tc) {
            try {
                service.CreateTamagotchi(tc);
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                return;
            }
        }

        [NonAction]
        public Tamagotchi.Web.Models.Tamagotchi GetTamagotchi(int tamagotchiId) {
            try {
                var tc = service.GetTamagotchiById(tamagotchiId);
                if (tc == null)
                    return null;
                return Tamagotchi.Web.Helpers.DataConversion.Tamagotchi.ConvertTamagotchi.ConvertTamagotchiContractToTamagotchi(tc);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        [NonAction]
        public List<Tamagotchi.Web.Models.Tamagotchi> GetTamagotchies(List<int> tamagotchiIds) {
            var temp = new List<Tamagotchi.Web.Models.Tamagotchi>();
            foreach(var id in tamagotchiIds) {
                temp.Add(GetTamagotchi(id));
            }
            return temp;
        }

        [NonAction]
        public PlayerContract GetAndOrCreatePlayer(PlayerContract pc) {
            try {
                var player = service.GetAndOrCreatePlayer(pc);
                return player;
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        [NonAction]
        public List<Tamagotchi.Web.Models.Tamagotchi> GetTamagotchiesForPlayer() {
            try {
                currentPlayer = service.GetAndOrCreatePlayer(new PlayerContract() { PlayerName = User.Identity.Name });
                if (currentPlayer == null)
                    return null;
                var playerTamagotchies = service.GetTamagotchiesForPlayer(currentPlayer.PlayerId);
                if (playerTamagotchies == null || playerTamagotchies.Count() == 0)
                    return null;
                return Tamagotchi.Web.Helpers.DataConversion.Tamagotchi.ConvertTamagotchi.ConvertTamagotchiConractListToTamagotchiList(playerTamagotchies);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion
    }
}