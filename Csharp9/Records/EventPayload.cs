using Abstract.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp9.Classes
{
    // Using concise C# 9+ primary constructor syntax for records.
    public record EventPayload;


    // 2. Records defined with explicit properties and constructors.
    // C# 9 INTRODUCED 'record' types. In C# 8, these would be standard 'class' types.
    // Records provide synthesized methods like Equals, GetHashCode, ToString, and Deconstruct.
    // Records can only inherit from another record
    public record LoginEvent : EventPayload
    {
        // C# 9 INTRODUCED 'init'-only setters. Properties can only be set during object initialization.
        // In C# 8, these would typically be read-only properties set in the constructor, or mutable properties with 'set;'.
        public string Username { get; init; }
        public DateTime Timestamp { get; init; }
        public string IpAddress { get; init; }

        public LoginEvent(string username, DateTime timestamp, string ipAddress)
        {
            Username = username;
            Timestamp = timestamp;
            IpAddress = ipAddress;
        }

        // Deconstruct is still synthesized by the record type, even with an explicit constructor.
        // This allows positional patterns and explicit deconstruction.
        // For example: var (user, time, ip) = loginEventInstance;
        // In C# 8, for a class to support positional patterns or explicit deconstruction,
        // you'd have to manually write a Deconstruct method:
        // public void Deconstruct(out string username, out DateTime timestamp, out string ipAddress) { ... }
    }

    public record LogoutEvent : EventPayload // C# 9: 'record'
    {
        public string Username { get; init; } // C# 9: 'init'
        public DateTime Timestamp { get; init; } // C# 9: 'init'

        public LogoutEvent(string username, DateTime timestamp)
        {
            Username = username;
            Timestamp = timestamp;
        }
    }

    public record PurchaseEvent : EventPayload // C# 9: 'record'
    {
        public string Username { get; init; } // C# 9: 'init'
        public string ProductId { get; init; } // C# 9: 'init'
        public decimal Amount { get; init; } // C# 9: 'init'
        public List<string> Tags { get; init; } // C# 9: 'init'

        public PurchaseEvent(string username, string productId, decimal amount, List<string> tags)
        {
            Username = username;
            ProductId = productId;
            Amount = amount;
            Tags = tags;
        }
    }

    public record SystemMessage : EventPayload // C# 9: 'record'
    {
        public string Message { get; init; } // C# 9: 'init'
        public int Severity { get; init; } // C# 9: 'init'
        public bool IsCritical { get; init; } // C# 9: 'init'

        public SystemMessage(string message, int severity, bool isCritical)
        {
            Message = message;
            Severity = severity;
            IsCritical = isCritical;
        }
    }
}
