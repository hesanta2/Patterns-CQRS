using Read.Application.Cars;
using Microsoft.Practices.Unity;
using Read.Infrasctructure.Persistence.Cars;

namespace ConsoleApplication
{
    public static class UnityConfigurator
    {
        private static UnityContainer unityContainer = null;

        public static UnityContainer UnityContainer
        {
            get
            {
                if (unityContainer == null) init();
                return unityContainer;
            }
        }

        private static void init()
        {
            unityContainer = new UnityContainer();

            unityContainer.RegisterType<ICarService, CarService>();
            unityContainer.RegisterType<ICarRepository, CarMemoryRepository>();
        }
    }
}
