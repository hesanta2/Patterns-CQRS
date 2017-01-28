using Read.Application.Cars;
using Microsoft.Practices.Unity;
using Read.Infrastructure.Persistence.Cars;
using Write.Domain.Commands;
using Write.Infrastrucure.Commands;
using Write.Domain.Cars;
using Write.Infrastructure.Commands;
using Write.Domain.Events;

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

            unityContainer.RegisterType<ICarService, CarService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ICarRepository, CarMemoryRepository>(new ContainerControlledLifetimeManager());

            unityContainer.RegisterType<ICommandBus, MemoryCommandBus>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IEventPublisher, MemoryCommandBus>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ICommandEventRepository, MemoryCommandEventRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
