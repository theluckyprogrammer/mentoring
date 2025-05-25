using Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract.Classes
{
    public abstract class EventProcessor
    {
        public abstract string ProcessEvent(IEventPayload? payload);
    }
}
