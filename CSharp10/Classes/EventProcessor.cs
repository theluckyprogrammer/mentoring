using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abstract.Interfaces;
using CSharp10.Records;

namespace CSharp10.Classes
{
    public class EventProcessor : Abstract.Classes.EventProcessor
    {
        public override string ProcessEvent(IEventPayload? payload) // Nullable to show null check pattern
        {
            return payload switch
            {
                null => "Received a null event payload.",

                // C# 10: EXTENDED PROPERTY PATTERN for LoginEvent.LocationDetails.City
                LoginEvent { Username: "admin", LocationDetails.City: "ServerRoom", IpAddress: var adminIp } =>
                    $"Admin '{adminIp}' logged in from the ServerRoom.",
                LoginEvent { LocationDetails.Country: "Japan", Username: var userFromJapan } =>
                    // payload is guaranteed to be LoginEvent here due to pattern matching
                    $"User '{userFromJapan}' from Japan logged in from {((LoginEvent)payload).LocationDetails.City}.",

                // Positional pattern for LoginEvent (Deconstruct is synthesized from primary constructor parameters)
                LoginEvent("guest", _, _, { City: "Lobby" }) => "Guest login from the Lobby.",
                LoginEvent le => $"User '{le.Username}' logged in at {le.Timestamp:G} from {le.IpAddress} in {le.LocationDetails.City}, {le.LocationDetails.Country}.",

                LogoutEvent lo => $"User '{lo.Username}' logged out at {lo.Timestamp:G}.",

                SystemMessage { IsCritical: true, Severity: >= 5 } criticalMsg =>
                    $"CRITICAL PRIORITY! Message: '{criticalMsg.Message}', Severity: {criticalMsg.Severity}.",
                SystemMessage { Severity: > 3 and < 5 } highSevMsg =>
                    $"High severity message: '{highSevMsg.Message}', Severity: {highSevMsg.Severity}.",
                SystemMessage { Severity: 1 or 2 } lowSevMsg =>
                    $"Low severity message: '{lowSevMsg.Message}'.",
                SystemMessage sm => $"Generic system message: '{sm.Message}', Severity: {sm.Severity}, Critical: {sm.IsCritical}.",

                PurchaseEvent pe when pe.Tags.Count == 0 =>
                    $"Purchase by '{pe.Username}' for product '{pe.ProductId}' (Amount: {pe.Amount:C}) with NO tags.",
                PurchaseEvent pe when pe.Tags.Count == 1 && pe.Tags[0] == "sale" =>
                    $"Purchase by '{pe.Username}' for product '{pe.ProductId}' (Amount: {pe.Amount:C}) tagged ONLY as 'sale'.",

                PurchaseEvent { Amount: > 1000m } peHighValue =>
                    $"High value purchase ({peHighValue.Amount:C}) by '{peHighValue.Username}' for product '{peHighValue.ProductId}'.",
                PurchaseEvent pe =>
                    $"Purchase by '{pe.Username}' for product '{pe.ProductId}' (Amount: {pe.Amount:C}). Tags: {(pe.Tags.Any() ? string.Join(", ", pe.Tags) : "none")}.",

                // C# 10: Handling the 'record struct' SimpleTelemetryEvent
                SimpleTelemetryEvent { DeviceId: "SensorAlpha", Value: > 99.9, Unit: "Celsius" } steHigh =>
                    $"ALERT! High temperature from {steHigh.DeviceId}: {steHigh.Value}°C.",
                SimpleTelemetryEvent { Unit: "PSI", Value: < 10 } steLowPressure =>
                    $"Warning: Low pressure from {steLowPressure.DeviceId}: {steLowPressure.Value} PSI.",
                SimpleTelemetryEvent ste =>
                    $"Telemetry from {ste.DeviceId}: {ste.Value} {ste.Unit}.",

                _ => $"Received an unhandled event type: {payload.GetType().Name}."
            };
        }
    }
}
