﻿using System;
using System.Collections.Generic;
using CommonDomain.Persistence;

namespace Inceptum.Cqrs.Configuration
{
    public class BoundedContext
    {
        internal Dictionary<Type, string> EventRoutes { get; set; }
        internal Dictionary<string, IEnumerable<Type>> EventsSubscriptions { get; set; }
        internal List<CommandSubscription> CommandsSubscriptions { get; set; }
        internal Dictionary<Type, string> CommandRoutes { get; set; }
        internal EventsPublisher EventsPublisher { get; private set; }
        internal CommandDispatcher CommandDispatcher { get; private set; }
        internal EventDispatcher EventDispatcher { get; private set; }
        internal List<IProcess> Processes { get; private set; }
        internal IRepository Repository { get; set; }
        public string Name { get; set; }

        internal BoundedContext(CqrsEngine cqrsEngine,string name)
        {
            Name = name;
            EventsPublisher = new EventsPublisher(cqrsEngine, this);
            CommandDispatcher = new CommandDispatcher(Name);
            EventDispatcher = new EventDispatcher(Name);
            Processes = new List<IProcess>();
        }
         
    }
}