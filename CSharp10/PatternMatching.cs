
using Abstract.Interfaces;
using CSharp10.Classes;
using CSharp10.Records;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CSharp10
{
    internal class PatternMatching : Abstract.Demo
    {
        public override void Run()
        {
            var processor = new EventProcessor();
            var now = DateTime.UtcNow;
            // Instantiation now uses the concise primary constructors for record classes
            var defaultLocation = new GeoLocation("DefaultCity", "DefaultCountry");
            var serverRoomLocation = new GeoLocation("ServerRoom", "Datacenter");
            var japanLocation = new GeoLocation("Tokyo", "Japan");
            var lobbyLocation = new GeoLocation("Lobby", "BuildingA");


            WriteLine("--- Processing Events (C# 10.0 Rules, Concise Records) ---");

            List<IEventPayload?> eventsToProcess = new List<IEventPayload?>
            {
                null,
                new LoginEvent("user123", now.AddMinutes(-30), "192.168.1.10", defaultLocation),
                new LoginEvent("admin", now.AddMinutes(-25), "10.0.0.5", serverRoomLocation),
                new LoginEvent("devUser", now.AddMinutes(-20), "10.0.0.6", japanLocation),
                new LoginEvent("guest", now.AddMinutes(-15), "10.0.0.7", lobbyLocation),
                new LogoutEvent("user123", now.AddMinutes(-5)),
                new SystemMessage("System rebooting soon.", 4, false),
                new SystemMessage("Critical disk failure!", 5, true),
                new SystemMessage("Low memory warning.", 2, false),
                new PurchaseEvent("user456", "PROD001", 79.99m, new List<string> { "electronics", "sale", "gift" }),
                new PurchaseEvent("user789", "PROD002", 1200.50m, new List<string> { "luxury", "vip" }),
                new PurchaseEvent("user111", "PROD003", 19.99m, new List<string>()),
                // C# 10: Instantiation of SimpleTelemetryEvent (record struct)
                new SimpleTelemetryEvent("SensorAlpha", 105.5, "Celsius"),
                new SimpleTelemetryEvent("SensorBeta", 75.0, "Fahrenheit"),
                new SimpleTelemetryEvent("PressureGauge1", 5.2, "PSI")
            };

            foreach (var evt in eventsToProcess)
            {
                WriteLine($"Input: {evt?.GetType().Name ?? "null"} ({evt?.ToString() ?? "N/A"})");
                string result = processor.ProcessEvent(evt);
                WriteLine($"Output: {result}\n");
            }

            WriteLine("--- Explicit Deconstruction Example (LoginEvent) ---");
            var sampleLoginEvent = new LoginEvent("testUser", DateTime.Now, "127.0.0.1", new GeoLocation("TestCity", "TestCountry"));
            // Deconstruction works seamlessly with primary constructor defined records
            var (username, timestamp, ipAddress, location) = sampleLoginEvent;

            WriteLine($"Deconstructed LoginEvent:");
            WriteLine($"  Username: {username}");
            WriteLine($"  Timestamp: {timestamp:G}");
            WriteLine($"  IP Address: {ipAddress}");
            WriteLine($"  Location: {location.City}, {location.Country}");
            WriteLine();

            Console.WriteLine("--- Explicit Deconstruction Example (SimpleTelemetryEvent) ---");
            var sampleTelemetry = new SimpleTelemetryEvent("DeviceXYZ", 42.7, "Units");
            var (deviceId, val, unit) = sampleTelemetry;
            WriteLine($"Deconstructed SimpleTelemetryEvent:");
            WriteLine($"  Device ID: {deviceId}");
            WriteLine($"  Value: {val}");
            WriteLine($"  Unit: {unit}");
            WriteLine();
        }
    }
}
