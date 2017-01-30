﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain;

namespace CQRS.Write.Domain.Test.ForTesting
{
    public class TestAggregateRoot : AggregateRoot<int>
    {

        private void Apply(TestAgrregateRootCreateEvent @event)
        {
            this.Id = @event.Id;
        }

    }
}
