using Abstract.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract.Interfaces;

// C# 11: File-local type. GeoLocation is only visible within this file.
internal record GeoLocation(string City, string Country);

namespace CSharp11.Records
{
    // 2. Records and Record Structs
    // Using concise C# 9+ primary constructor syntax for records.
    // C# 11: Added 'required' modifier to some properties.
    internal record LoginEvent(
        string Username, // C# 11: required member
        DateTime Timestamp,
        string IpAddress, // C# 11: required member
        GeoLocation LocationDetails) : IEventPayload;

    internal record LogoutEvent(
        string Username, // C# 11: required member
        DateTime Timestamp) : IEventPayload;

    internal record PurchaseEvent(
        string Username, // C# 11: required member
        string ProductId, // C# 11: required member
        decimal Amount,
        string[] Tags) : IEventPayload;

    internal record SystemMessage(
        string Message, // C# 11: required member
        int Severity,
        bool IsCritical) : IEventPayload;

    // Record struct (C# 10 feature)
    internal readonly record struct SimpleTelemetryEvent(string DeviceId, double Value, string Unit) : IEventPayload;



}
