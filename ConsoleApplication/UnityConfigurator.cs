using CQRS.Read.Application.Cars;
using Microsoft.Practices.Unity;
using CQRS.Read.Infrastructure.Persistence.Cars;
using CQRS.Write.Domain.Commands;
using CQRS.Write.Infrastructure.Commands;
using CQRS.Write.Domain.Events;

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

            unityContainer.RegisterType<ICommandBus, CommandBus>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IEventPublisher, CommandBus>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ICommandEventRepository, MemoryCommandEventRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
