using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
