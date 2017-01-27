using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Write.Domain.Events
{
    public static class Events
    {
        [ThreadStatic]
        private static List<Delegate> actions;
        [ThreadStatic]
        private static List<IEventHandler> handlers;

        public static void Register(IEventHandler domainHandler)
        {
            if (handlers == null) handlers = new List<IEventHandler>();

            handlers.Add(domainHandler);
        }

        public static void Register<T>(Action<T> callBack)
        {
            if (actions == null) actions = new List<Delegate>();

            actions.Add(callBack);
        }

        public static void Raise<T>(T domainEvent) where T : Event
        {
            if (handlers != null)
                foreach (var handler in handlers)
                {
                    MethodInfo methodInfo = handler.GetType().GetMethod("Handle", new Type[] { typeof(T) });
                    if (methodInfo != null)
                        methodInfo.Invoke(handler, new object[] { domainEvent });
                }

            if (actions != null)
                foreach (var action in actions)
                    if (action is Action<T>)
                        ((Action<T>)action)(domainEvent);
        }

        public static void ClearCallbacks()
        {
            actions = null;
        }

    }
}
