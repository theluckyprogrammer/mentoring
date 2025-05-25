using Abstract.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract.Interfaces;


namespace CSharp10.Records
{
    // 1. Supporting record for nested property demonstration
    // Using concise C# 9+ primary constructor syntax for records.
    // All fields (City, Country) are defined by the constructor parameters.
    public record GeoLocation(string City, string Country);

    // 2. Records and Record Structs
    // All types now implement the IEventPayload interface.
    public record LoginEvent(string Username, DateTime Timestamp, string IpAddress, GeoLocation LocationDetails) : IEventPayload;

    public record LogoutEvent(string Username, DateTime Timestamp) : IEventPayload;

    public record PurchaseEvent(string Username, string ProductId, decimal Amount, List<string> Tags) : IEventPayload;

    public record SystemMessage(string Message, int Severity, bool IsCritical) : IEventPayload;

    // C# 10 INTRODUCED 'record struct'.
    // This continues to use the concise primary constructor syntax, which is idiomatic.
    public readonly record struct SimpleTelemetryEvent(string DeviceId, double Value, string Unit) : IEventPayload;


}
