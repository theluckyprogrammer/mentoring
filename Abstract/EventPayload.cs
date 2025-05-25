using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract
{
    public abstract class EventPayload
    {
        protected Guid Id => Guid.NewGuid();

    };

  

    public class LoginEvent : EventPayload
    {
        public string Username { get; }
        public DateTime Timestamp { get; }
        public string IpAddress { get; }

        public LoginEvent(string username, DateTime timestamp, string ipAddress)
        {
            Username = username;
            Timestamp = timestamp;
            IpAddress = ipAddress;
        }

        public void Deconstruct(out string username, out DateTime timestamp, out string ipAddress)
        {
            username = Username;
            timestamp = Timestamp;
            ipAddress = IpAddress;
        }
    }

    public class LogoutEvent : EventPayload
    {
        public string Username { get; }
        public DateTime Timestamp { get; }

        public LogoutEvent(string username, DateTime timestamp)
        {
            Username = username;
            Timestamp = timestamp;
        }
    }

    public class PurchaseEvent : EventPayload
    {
        public string Username { get; }
        public string ProductId { get; }
        public decimal Amount { get; }
        public List<string> Tags { get; }

        public PurchaseEvent(string username, string productId, decimal amount, List<string> tags)
        {
            Username = username;
            ProductId = productId;
            Amount = amount;
            Tags = tags;
        }
    }

    public class SystemMessage : EventPayload
    {
        public string Message { get; }
        public int Severity { get; }
        public bool IsCritical { get; }

        public SystemMessage(string message, int severity, bool isCritical)
        {
            Message = message;
            Severity = severity;
            IsCritical = isCritical;
        }
    }

    public class UnknownEvent : EventPayload
    {
    

    }
}
