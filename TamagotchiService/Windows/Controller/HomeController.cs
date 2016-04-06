using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.TamagotchiReference;
using Windows.View;

namespace Windows.Controller {
    public class HomeController {

        private ITService service;

        private HomeView homeView;

        private PlayerContract currentPlayer;
        private TamagotchiContract currentTamagotchi;
        private List<TamagotchiContract> currentPlayerTamagotchies;

        public HomeController() {
            service = new TServiceClient();
            homeView = new HomeView();

            currentPlayerTamagotchies = new List<TamagotchiContract>();

            Start();
        }

        public void Start() {
            homeView.Clear();

            Login();

            GetPlayerTamagotchies();

            if(currentPlayerTamagotchies != null && currentPlayerTamagotchies.Count > 0) {
                AskForNewTamagotchi();
                currentTamagotchi = GetTamagotchiesForPlayer(currentPlayer.PlayerId).Last();
            } else {
                CreateTamagotchi();
                GetPlayerTamagotchies();
            }

            homeView.Clear();

            PresentTamagotchies();

            SelectTamagotchi();

            while(true) {
                homeView.Clear();

                SelectAction();
            }
        }


        public void Login() {
            homeView.Push("Vul uw gebruikersnaam in:");
            string loginname = homeView.Pull();
            currentPlayer = GetAndOrCreatePlayer(new PlayerContract { PlayerName = loginname });
        }

        public void GetPlayerTamagotchies() {
            //Retrieve tamagotchies for player
            currentPlayerTamagotchies = GetTamagotchiesForPlayer(currentPlayer.PlayerId);
        }

        public void AskForNewTamagotchi() {
            homeView.Push("U heeft al tamagotchies, wilt u toch een nieuwe tamagotchi aanmaken? (y/n)");
            string result = homeView.Pull();
            if(result.ToLower() == "y") {
                CreateTamagotchi();
            }
        }

        public void CreateTamagotchi() {
            homeView.Push("Bedenk een naam voor uw tamagotchi:");
            string tamagotchiname = homeView.Pull();
            CreateTamagotchi(new TamagotchiContract { Player = currentPlayer, TamagotchiName = tamagotchiname });
        }

        public void PresentTamagotchies() {
            currentPlayerTamagotchies = GetTamagotchiesForPlayer(currentPlayer.PlayerId);
            homeView.Push("Uw tamagotchies:");
            foreach (var t in currentPlayerTamagotchies) {
                homeView.Push(String.Format("{0} [{1}]", t.TamagotchiName, t.IsDead ? "Dood" : "Levend"));
            }
        }

        public void SelectTamagotchi() {
            homeView.Push("Typ de naam van de Tamagotchi, waarmee u wilt spelen:");
            string tamagotchiname = homeView.Pull();
            currentTamagotchi = currentPlayerTamagotchies.Where(x => x.TamagotchiName.ToLower() == tamagotchiname.ToLower()).FirstOrDefault();
            if (currentTamagotchi == null)
                Environment.Exit(0);
        }

        public void SelectAction() {
            currentTamagotchi = GetTamagotchiById(currentTamagotchi.TamagotchiId);
            if (currentTamagotchi == null)
                return;

            if (currentTamagotchi.IsDead) {
                homeView.Push("Uw tamagotchi is dood.");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            if(currentTamagotchi.ActionLocked > DateTime.UtcNow) {
                homeView.Push(String.Format("Uw tamagotchi is nog bezig met een actie. Probeer het nogeens over: {0} seconden.", Convert.ToInt32((currentTamagotchi.ActionLocked.Subtract(DateTime.UtcNow)).TotalSeconds)));
                Thread.Sleep(5000);
                return;
            }
            var actionDict = new Dictionary<int, string> {
            { 1, "Eten" }, { 2, "Slapen" }, { 3, "Spelen" },
            { 4, "Sporten" }, { 5, "Knuffelen" }
            };
            string msg = String.Empty;
            foreach (KeyValuePair<int, string> i in actionDict) {
                msg += String.Format("| {0} = {1} ", i.Key, i.Value);
            }
            homeView.Push(msg);
            homeView.Push("Geef het nummer van de uit te voeren actie:");
            string actionnumber = homeView.Pull();
            int validatedactionnumber;
            if (!Int32.TryParse(actionnumber, out validatedactionnumber))
                validatedactionnumber = -1;
            switch(validatedactionnumber) {
                case 1:
                Eat();
                break;
                case 2:
                Sleep();
                break;
                case 3:
                Play();
                break;
                case 4:
                Workout();
                break;
                case 5:
                Hug();
                break;
                default:
                    //Do nothing
                break;
            }
        }

        public PlayerContract GetAndOrCreatePlayer(PlayerContract pc) {
            try {
                return service.GetAndOrCreatePlayer(pc);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public int CreateTamagotchi(TamagotchiContract tc) {
            try {
                return service.CreateTamagotchi(tc);
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                return -1;
            }
        }

        public TamagotchiContract GetTamagotchiById(int tamagotchiId) {
            try {
                return service.GetTamagotchiById(tamagotchiId);
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<TamagotchiContract> GetTamagotchiesForPlayer(int playerId) {
            try {
                return service.GetTamagotchiesForPlayer(playerId);
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public void Eat() {
            if (currentTamagotchi.Hunger == 0) return;
            try {
                service.Eat(currentTamagotchi.TamagotchiId);
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Sleep() {
            if (currentTamagotchi.Sleep == 0) return;
            try {
                service.Sleep(currentTamagotchi.TamagotchiId);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Play() {
            if (currentTamagotchi.Boredom == 0) return;
            try {
                service.Play(currentTamagotchi.TamagotchiId);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Workout() {
            if (currentTamagotchi.Health == 0) return;
            try {
                service.Workout(currentTamagotchi.TamagotchiId);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
        
        public void Hug() {
            if (currentTamagotchi.Health == 0) return;
            try {
                service.Hug(currentTamagotchi.TamagotchiId);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
