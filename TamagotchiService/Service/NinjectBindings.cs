using TamagotchiService.GameRules;
using TamagotchiService.Model;

namespace TamagotchiService {
    public class NinjectBindings : Ninject.Modules.NinjectModule {
        public override void Load() {
            Bind<IRule>().To<AthleteRule>(); Bind<IRule>().To<BoredRule>(); Bind<IRule>().To<CrazyRule>();
            Bind<IRule>().To<ExhaustedRule>(); Bind<IRule>().To<FoodDeprivationRule>(); Bind<IRule>().To<HungryRule>();
            Bind<IRule>().To<IsolatedRule>(); Bind<IRule>().To<MunchiesRule>(); Bind<IRule>().To<SleepDeprivationRule>();
        }
    }
}