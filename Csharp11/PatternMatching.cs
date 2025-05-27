
using Abstract.Interfaces;
using CSharp11.Classes;
using CSharp11.Records;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CSharp11
{
    internal class PatternMatching : Abstract.Demo
    {
        public override void Run()
        {
            var processor = new EventProcessor();
            var now = DateTime.UtcNow;
            // GeoLocation is now file-local, but can be used here as it's in the same file.
            var defaultLocation = new GeoLocation("DefaultCity", "DefaultCountry");
            var serverRoomLocation = new GeoLocation("ServerRoom", "Datacenter");
            var japanLocation = new GeoLocation("Tokyo", "Japan");
            var lobbyLocation = new GeoLocation("Lobby", "BuildingA");


            Console.WriteLine("--- Processing Events (C# 11.0 Rules, Tags as string[]) ---");

            List<IEventPayload?> eventsToProcess = new List<IEventPayload?>
            {
                null,
                new LoginEvent(Username: "user123", Timestamp: now.AddMinutes(-30), IpAddress: "192.168.1.10", LocationDetails: defaultLocation),
                new LoginEvent(Username: "admin", Timestamp: now.AddMinutes(-25), IpAddress: "10.0.0.5", LocationDetails: serverRoomLocation),
                new LoginEvent(Username: "devUser", Timestamp: now.AddMinutes(-20), IpAddress: "10.0.0.6", LocationDetails: japanLocation),
                new LoginEvent(Username: "guest", Timestamp: now.AddMinutes(-15), IpAddress: "10.0.0.7", LocationDetails: lobbyLocation),
                new LogoutEvent(Username: "user123", Timestamp: now.AddMinutes(-5)),
                new SystemMessage(Message: "System rebooting soon.", Severity: 4, IsCritical: false),
                new SystemMessage(Message: "Critical disk failure!", Severity: 5, IsCritical: true),
                new SystemMessage(Message: "Low memory warning.", Severity: 2, IsCritical: false),
                // MODIFIED: Examples for List Patterns now use string[] for Tags
                new PurchaseEvent(Username: "userA", ProductId: "PROD001", Amount: 19.99m, Tags: Array.Empty<string>()), // No tags -> Tags: []
                new PurchaseEvent(Username: "userB", ProductId: "PROD002", Amount: 29.99m, Tags: new[] { "sale" }), // Only "sale" -> Tags: ["sale"]
                new PurchaseEvent(Username: "userC", ProductId: "PROD003", Amount: 39.99m, Tags: new[] { "new", "featured", "popular" }), // Starts "new" -> Tags: ["new", ..]
                new PurchaseEvent(Username: "userD", ProductId: "PROD004", Amount: 49.99m, Tags: new[] { "books", "priority", "education" }), // "priority" as second -> Tags: [_, "priority", ..]
                new PurchaseEvent(Username: "userE", ProductId: "PROD005", Amount: 59.99m, Tags: new[] { "clothing", "clearance", "urgent" }), // Ends "urgent" -> Tags: [.., "urgent"]
                new PurchaseEvent(Username: "userF", ProductId: "PROD006", Amount: 1200.50m, Tags: new[] { "luxury", "vip" }), // High value
                new SimpleTelemetryEvent("SensorAlpha", 105.5, "Celsius"),
                new SimpleTelemetryEvent("SensorBeta", 75.0, "Fahrenheit"),
                new SimpleTelemetryEvent("PressureGauge1", 5.2, "PSI")
            };

            foreach (var evt in eventsToProcess)
            {
                Console.WriteLine($"Input: {evt?.GetType().Name ?? "null"} ({evt?.ToString() ?? "N/A"})");
                string result = processor.ProcessEvent(evt);
                Console.WriteLine($"Output: {result}\n");
            }

            Console.WriteLine("--- Explicit Deconstruction Example (LoginEvent) ---");
            var sampleLoginEvent = new LoginEvent(Username: "testUser", Timestamp: DateTime.Now, IpAddress: "127.0.0.1", LocationDetails: new GeoLocation("TestCity", "TestCountry"));
            var (username, timestamp, ipAddress, location) = sampleLoginEvent;

            Console.WriteLine($"Deconstructed LoginEvent:");
            Console.WriteLine($"  Username: {username}");
            Console.WriteLine($"  Timestamp: {timestamp:G}");
            Console.WriteLine($"  IP Address: {ipAddress}");
            Console.WriteLine($"  Location: {location.City}, {location.Country}");
            Console.WriteLine();

            Console.WriteLine("--- Explicit Deconstruction Example (SimpleTelemetryEvent) ---");
            var sampleTelemetry = new SimpleTelemetryEvent("DeviceXYZ", 42.7, "Units");
            var (deviceId, val, unit) = sampleTelemetry;
            Console.WriteLine($"Deconstructed SimpleTelemetryEvent:");
            Console.WriteLine($"  Device ID: {deviceId}");
            Console.WriteLine($"  Value: {val}");
            Console.WriteLine($"  Unit: {unit}");
            Console.WriteLine();
        }
    }
}
