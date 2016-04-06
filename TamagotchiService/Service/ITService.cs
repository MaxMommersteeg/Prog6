using System.Collections.Generic;
using System.ServiceModel;
using TamagotchiService.Contract;

namespace Service {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITService" in both code and config file together.
    [ServiceContract]
    public interface ITService {

        [OperationContract]
        PlayerContract GetAndOrCreatePlayer(PlayerContract player);

        [OperationContract]
        int CreateTamagotchi(TamagotchiContract tamagotchi);

        [OperationContract]
        TamagotchiContract GetTamagotchiById(int tamagotchiId);

        [OperationContract]
        List<TamagotchiContract> GetTamagotchiesForPlayer(int playerId);
    
        [OperationContract]
        void Eat(int tamagotchiId);
        [OperationContract]
        void Sleep(int tamagotchiId);
        [OperationContract]
        void Play(int tamagotchiId);
        [OperationContract]
        void Workout(int tamagotchiId);
        [OperationContract]
        void Hug(int tamagotchiId);
    }
}
