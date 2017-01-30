using Domain.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain.Commands;
using CQRS.Write.Domain.Events;

namespace CQRS.Write.Infrastructure.Commands
{
    public class CommandBus : ICommandBus
    {
        private Dictionary<Type, List<Action<ICommand>>> commandHandlerDictionary = new Dictionary<Type, List<Action<ICommand>>>();
        private Dictionary<Type, List<Action<IEvent>>> eventHandlerDictionary = new Dictionary<Type, List<Action<IEvent>>>();

        public void RegisterCommandHandlers(ICommandHandler commandHandlers)
        {
            var commandHandlerMethods = commandHandlers.GetType().GetMethods()
                .Where(m => m.GetParameters()
                .Any(p => p.ParameterType.GetInterfaces().Contains(typeof(ICommand))));

            foreach (var method in commandHandlerMethods)
            {
                ParameterInfo commandParameterInfo = method.GetParameters()
                    .Where(p => p.ParameterType.GetInterfaces().Contains(typeof(ICommand))).FirstOrDefault();

                if (commandParameterInfo == null) continue;

                Type commandParameterType = commandParameterInfo.ParameterType;
                List<Action<ICommand>> commandActions;
                if (!this.commandHandlerDictionary.TryGetValue(commandParameterType, out commandActions))
                {
                    commandActions = new List<Action<ICommand>>();
                    this.commandHandlerDictionary.Add(commandParameterType, commandActions);
                }

                commandActions.Add(x => method.Invoke(commandHandlers, new object[] { x }));
            }
        }

        public void Send<T>(T command) where T : ICommand
        {
            List<Action<ICommand>> commandActions;
            if (this.commandHandlerDictionary.TryGetValue(command.GetType(), out commandActions))
                foreach (var commandHandlerMethod in commandActions)
                {
                    commandHandlerMethod(command);
                }
            else
                throw new InvalidOperationException($"No command 'Handler' for {command} 'command' registered");
        }

        public void RegisterEventHandlers(IEventHandler eventHandlers)
        {
            var commandHandlerMethods = eventHandlers.GetType().GetMethods()
                .Where(m => m.GetParameters()
                .Any(p => p.ParameterType.GetInterfaces().Contains(typeof(IEvent))));

            foreach (var method in commandHandlerMethods)
            {
                ParameterInfo commandParameterInfo = method.GetParameters()
                    .Where(p => p.ParameterType.GetInterfaces().Contains(typeof(IEvent))).FirstOrDefault();

                if (commandParameterInfo == null) continue;

                Type commandParameterType = commandParameterInfo.ParameterType;
                List<Action<IEvent>> eventActions;
                if (!this.eventHandlerDictionary.TryGetValue(commandParameterType, out eventActions))
                {
                    eventActions = new List<Action<IEvent>>();
                    this.eventHandlerDictionary.Add(commandParameterType, eventActions);
                }

                eventActions.Add(x => method.Invoke(eventHandlers, new object[] { x }));
            }
        }

        public void Publish<T>(T @event) where T : IEvent
        {
            List<Action<IEvent>> eventActions;
            if (this.eventHandlerDictionary.TryGetValue(@event.GetType(), out eventActions))
                foreach (var eventHandlerMethod in eventActions)
                {
                    eventHandlerMethod(@event);
                }
            else
                throw new InvalidOperationException($"No event 'Handler' for {@event} 'event' registered");
        }
    }
}
