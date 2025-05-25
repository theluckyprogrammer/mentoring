using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract
{
    public abstract class EventProcessor
    {
        public abstract string ProcessEvent(EventPayload? payload);
    }
}
