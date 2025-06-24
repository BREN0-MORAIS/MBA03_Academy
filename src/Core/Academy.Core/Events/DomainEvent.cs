using Academy.Core.Events.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Events;

public class DomainEvent : Event
{

    public DomainEvent(Guid aggregateId)
    {
        AggregateId = aggregateId;
    }
}
