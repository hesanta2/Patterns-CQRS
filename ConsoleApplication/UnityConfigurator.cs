using Read.Application.Cars;
using Microsoft.Practices.Unity;
using Read.Infrastructure.Persistence.Cars;
using Write.Infrastrucure.Messaging;
using Write.Domain.Messaging;

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

            unityContainer.RegisterType<ICommandBus, MemoryCommandBus>();
            unityContainer.RegisterType<ICarService, CarService>();
            unityContainer.RegisterType<ICarRepository, CarMemoryRepository>();
        }
    }
}
