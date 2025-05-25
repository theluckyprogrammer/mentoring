using Abstract.Classes;
using Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp9.Classes
{
    public class EventProcessor : Abstract.Classes.EventProcessor
    {
        public override string ProcessEvent(IEventPayload? payload) // Nullable to show null check pattern
        {
            return payload switch
            {
                
                null => "Received a null event payload.",

                
                LoginEvent("admin", _, var ip) => $"Admin login detected from IP: {ip}.", 
                LoginEvent le => $"User '{le.Username}' logged in at {le.Timestamp:G} from {le.IpAddress}.",

                LogoutEvent lo => $"User '{lo.Username}' logged out at {lo.Timestamp:G}.",

                // C# 9 INTRODUCED Relational (>=, >, <, <=) and Logical (and, or, not) patterns.
                // This makes the conditions more declarative and part of the pattern itself.
                SystemMessage { IsCritical: true, Severity: >= 5 } criticalMsg => // C# 9: 'IsCritical: true' and 'Severity: >= 5'
                                                                                  // C# 8 equivalent: SystemMessage sm when sm.IsCritical && sm.Severity >= 5 => ...
                    $"CRITICAL PRIORITY! Message: '{criticalMsg.Message}', Severity: {criticalMsg.Severity}.",

                SystemMessage { Severity: > 3 and < 5 } highSevMsg => // C# 9: 'Severity: > 3 and < 5'
                                                                      // C# 8 equivalent: SystemMessage sm when sm.Severity > 3 && sm.Severity < 5 => ...
                    $"High severity message: '{highSevMsg.Message}', Severity: {highSevMsg.Severity}.",

                SystemMessage { Severity: 1 or 2 } lowSevMsg => // C# 9: 'Severity: 1 or 2'
                                                                // C# 8 equivalent: SystemMessage sm when sm.Severity == 1 || sm.Severity == 2 => ...
                    $"Low severity message: '{lowSevMsg.Message}'.",

                SystemMessage sm => $"Generic system message: '{sm.Message}', Severity: {sm.Severity}, Critical: {sm.IsCritical}.",

                // List checks still require 'when' clauses as full List Patterns were introduced in C# 11 (.NET 7).
                // This logic is similar to how it would be done in C# 8.
                PurchaseEvent pe when pe.Tags.Count == 0 =>
                    $"Purchase by '{pe.Username}' for product '{pe.ProductId}' (Amount: {pe.Amount:C}) with NO tags.",
                PurchaseEvent pe when pe.Tags.Count == 1 && pe.Tags[0] == "sale" =>
                    $"Purchase by '{pe.Username}' for product '{pe.ProductId}' (Amount: {pe.Amount:C}) tagged ONLY as 'sale'.",

                // C# 9: Can use relational pattern directly on a property.
                PurchaseEvent { Amount: > 1000m } peHighValue =>
                    // C# 8 equivalent: PurchaseEvent pe when pe.Amount > 1000m => ...
                    $"High value purchase ({peHighValue.Amount:C}) by '{peHighValue.Username}' for product '{peHighValue.ProductId}'.",

                PurchaseEvent pe => // Default for PurchaseEvent
                    $"Purchase by '{pe.Username}' for product '{pe.ProductId}' (Amount: {pe.Amount:C}). Tags: {(pe.Tags.Any() ? string.Join(", ", pe.Tags) : "none")}.",

                // C# 9 INTRODUCED the 'not' pattern.
                // This provides a more readable way to negate a type pattern or other patterns.
                // Example (not used here to keep flow simple, but for illustration):
                // case not SystemMessage nonSystemMsg => $"Not a system message: {nonSystemMsg.GetType().Name}",

                _ => $"Received an unhandled event type: {payload.GetType().Name}." // Default case (available in C# 8)
            };
        }
    }
}
