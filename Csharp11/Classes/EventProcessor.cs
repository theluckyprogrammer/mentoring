using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abstract.Interfaces;
using CSharp11.Records;

namespace CSharp11.Classes
{
    public class EventProcessor : Abstract.Classes.EventProcessor
    {
        public override string ProcessEvent(IEventPayload? payload) // Nullable to show null check pattern
        {
            return payload switch
            {
                null => "Received a null event payload.",

                // LoginEvent patterns (C# 10 extended property patterns are still useful)
                LoginEvent { Username: "admin", LocationDetails.City: "ServerRoom", IpAddress: var adminIp } =>
                    $"Admin '{adminIp}' logged in from the ServerRoom.",
                LoginEvent { LocationDetails.Country: "Japan", Username: var userFromJapan } =>
                    $"User '{userFromJapan}' from Japan logged in from {((LoginEvent)payload).LocationDetails.City}.",
                LoginEvent("guest", _, _, { City: "Lobby" }) => "Guest login from the Lobby.",
                LoginEvent le => $"User '{le.Username}' logged in at {le.Timestamp:G} from {le.IpAddress} in {le.LocationDetails.City}, {le.LocationDetails.Country}.",

                LogoutEvent lo => $"User '{lo.Username}' logged out at {lo.Timestamp:G}.",

                // SystemMessage patterns (C# 9 relational/logical patterns are still good)
                SystemMessage { IsCritical: true, Severity: >= 5 } criticalMsg =>
                    $"CRITICAL PRIORITY! Message: '{criticalMsg.Message}', Severity: {criticalMsg.Severity}.",
                SystemMessage { Severity: > 3 and < 5 } highSevMsg =>
                    $"High severity message: '{highSevMsg.Message}', Severity: {highSevMsg.Severity}.",
                SystemMessage { Severity: 1 or 2 } lowSevMsg =>
                    $"Low severity message: '{lowSevMsg.Message}'.",
                SystemMessage sm => $"Generic system message: '{sm.Message}', Severity: {sm.Severity}, Critical: {sm.IsCritical}.",

                // C# 11: LIST PATTERNS for PurchaseEvent.Tags
                // This is much more concise and readable than C# 8/9/10 'when' clauses with Count/indexers.
                PurchaseEvent { Tags: [] } peNoTags => // Empty list
                    $"Purchase by '{peNoTags.Username}' for product '{peNoTags.ProductId}' (Amount: {peNoTags.Amount:C}) with NO tags.",
                PurchaseEvent { Tags: ["sale"] } peSaleOnly => // Single specific element
                    $"Purchase by '{peSaleOnly.Username}' for product '{peSaleOnly.ProductId}' (Amount: {peSaleOnly.Amount:C}) tagged ONLY as 'sale'.",
                // MODIFIED: Explicitly typed slice as string[] and use .Length
                PurchaseEvent { Tags: ["new", .. var restOfNewTags] } peNewAndMore => // Starts with "new", captures the rest (slice pattern)
                    $"Purchase by '{peNewAndMore.Username}' ('{peNewAndMore.ProductId}', {peNewAndMore.Amount:C}) tagged 'new' and {restOfNewTags.Length} other(s): {string.Join(", ", restOfNewTags)}.",
                PurchaseEvent { Tags: [_, "priority", ..] } peSecondPriority => // Second element is "priority", discards first
                    $"Purchase by '{peSecondPriority.Username}' ('{peSecondPriority.ProductId}', {peSecondPriority.Amount:C}) with 'priority' as a significant tag.",
                PurchaseEvent { Tags: [.., "urgent"] } peEndsWithUrgent => // Ends with "urgent" (slice pattern at the beginning)
                    $"Purchase by '{peEndsWithUrgent.Username}' ('{peEndsWithUrgent.ProductId}', {peEndsWithUrgent.Amount:C}) with last tag 'urgent'.",

                PurchaseEvent { Amount: > 1000m } peHighValue => // Property pattern (C# 9) still useful
                    $"High value purchase ({peHighValue.Amount:C}) by '{peHighValue.Username}' for product '{peHighValue.ProductId}'.",
                PurchaseEvent pe => // Default for PurchaseEvent if no specific list pattern matched
                    $"Purchase by '{pe.Username}' for product '{pe.ProductId}' (Amount: {pe.Amount:C}). Tags: {(pe.Tags.Any() ? string.Join(", ", pe.Tags) : "none")}.",

                // SimpleTelemetryEvent patterns (C# 10 record struct handling)
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
