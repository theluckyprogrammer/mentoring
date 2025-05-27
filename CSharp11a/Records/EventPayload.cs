using Abstract.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract.Interfaces;


namespace CSharp11.Records
{
    // 2. Records and Record Structs
    // Using concise C# 9+ primary constructor syntax for records.
    // C# 11: Added 'required' modifier to some properties.
    public record LoginEvent(
        required string Username, // C# 11: required member
        DateTime Timestamp,
        required string IpAddress, // C# 11: required member
        GeoLocation LocationDetails) : IEventPayload;

    public record LogoutEvent(
        required string Username, // C# 11: required member
        DateTime Timestamp) : IEventPayload;

    public record PurchaseEvent(
        required string Username, // C# 11: required member
        required string ProductId, // C# 11: required member
        decimal Amount,
        List<string> Tags) : IEventPayload;

    public record SystemMessage(
        required string Message, // C# 11: required member
        int Severity,
        bool IsCritical) : IEventPayload;

    // Record struct (C# 10 feature)
    public readonly record struct SimpleTelemetryEvent(string DeviceId, double Value, string Unit) : IEventPayload;



}
