using Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Test;
using static System.Console;

namespace CSharp8
{
    internal class PatternMatching : Demo
    {
        public override void Run()
        {
            var processor = new CSharp8.Classes.EventProcessor();
            var now = DateTime.UtcNow;

            WriteLine("--- Processing Events (C# 8.0 Rules) ---");

            List<EventPayload?> eventsToProcess = new List<EventPayload?>
            {
                null,
                new LoginEvent("user123", now.AddMinutes(-30), "192.168.1.10"),
                new LoginEvent("admin", now.AddMinutes(-25), "10.0.0.5"),
                new LogoutEvent("user123", now.AddMinutes(-5)),
                new SystemMessage("System rebooting soon.", 4, false),
                new SystemMessage("Critical disk failure!", 5, true),
                new SystemMessage("Low memory warning.", 2, false),
                new PurchaseEvent("user456", "PROD001", 79.99m, new List<string> { "electronics", "sale", "gift" }),
                new PurchaseEvent("user789", "PROD002", 1200.50m, new List<string> { "luxury", "vip" }),
                new PurchaseEvent("user111", "PROD003", 19.99m, new List<string>()), // No tags
                new PurchaseEvent("user222", "PROD004", 29.99m, new List<string> { "sale" }), // Only "sale"
                new PurchaseEvent("user333", "PROD005", 39.99m, new List<string> { "new", "featured", "popular" }), // Starts with "new"
                new PurchaseEvent("user444", "PROD006", 49.99m, new List<string> { "books", "priority", "education" }), // "priority" as second
                new UnknownEvent() // To demonstrate the default case
            };

            foreach (var evt in eventsToProcess)
            {
                WriteLine($"Input: {evt?.GetType().Name ?? "null"}");
                string result = processor.ProcessEvent(evt);
                WriteLine($"Output: {result}\n");
            }
        }
    }
}
