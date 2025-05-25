using Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8.Classes
{
    public class EventProcessor : Abstract.EventProcessor
    {
        public override string ProcessEvent(EventPayload? payload) // Nullable to show null check pattern
        {
            // The C# 8 switch expression is used here.
            return payload switch
            {
                // Null check pattern
                null => "Received a null event payload.",

                // Positional pattern using the Deconstruct method.
                // Property patterns could also be used here.
                LoginEvent("admin", _, var ip) => $"Admin login detected from IP: {ip}.",
                LoginEvent le => $"User '{le.Username}' logged in at {le.Timestamp:G} from {le.IpAddress}.",

                LogoutEvent lo => $"User '{lo.Username}' logged out at {lo.Timestamp:G}.",

                // Property patterns with 'when' clause for relational/logical checks
                // C# 9's relational (>=) and logical (and) patterns are not available.
                SystemMessage sm when sm.IsCritical && sm.Severity >= 5 => $"CRITICAL PRIORITY! Message: '{sm.Message}', Severity: {sm.Severity}.",
                SystemMessage sm when sm.Severity > 3 && sm.Severity < 5 => $"High severity message: '{sm.Message}', Severity: {sm.Severity}.",
                SystemMessage sm when sm.Severity == 1 || sm.Severity == 2 => $"Low severity message: '{sm.Message}'.",
                SystemMessage sm => $"Generic system message: '{sm.Message}', Severity: {sm.Severity}, Critical: {sm.IsCritical}.",

                // C# 8 handling of list properties requires 'when' clauses.
                // List Patterns from .NET 7 are not available.
                PurchaseEvent pe when pe.Tags.Count == 0 => // Empty list
                    $"Purchase by '{pe.Username}' for product '{pe.ProductId}' (Amount: {pe.Amount:C}) with NO tags.",

                PurchaseEvent pe when pe.Tags.Count == 1 && pe.Tags[0] == "sale" => // Single specific element
                    $"Purchase by '{pe.Username}' for product '{pe.ProductId}' (Amount: {pe.Amount:C}) tagged ONLY as 'sale'.",

                PurchaseEvent pe when pe.Tags.Count > 0 && pe.Tags[0] == "new" => // Starts with "new"
                    $"Purchase by '{pe.Username}' for product '{pe.ProductId}' (Amount: {pe.Amount:C}) that is 'new'. Other tags: {string.Join(", ", pe.Tags.Skip(1))}.",

                PurchaseEvent pe when pe.Tags.Count > 1 && pe.Tags[1] == "priority" => // Second element is "priority"
                    $"Purchase by '{pe.Username}' for product '{pe.ProductId}' (Amount: {pe.Amount:C}) with 'priority' as a significant tag.",

                PurchaseEvent pe when pe.Amount > 1000m => // Property check with 'when' clause
                    $"High value purchase ({pe.Amount:C}) by '{pe.Username}' for product '{pe.ProductId}'. Tags: {(pe.Tags.Any() ? string.Join(", ", pe.Tags) : "none")}.",

                PurchaseEvent pe => // Default for PurchaseEvent if no specific condition matched
                    $"Purchase by '{pe.Username}' for product '{pe.ProductId}' (Amount: {pe.Amount:C}). Tags: {(pe.Tags.Any() ? string.Join(", ", pe.Tags) : "none")}.",

                // Default case for any other EventPayload type not handled above
                _ => $"Received an unhandled event type: {payload.GetType().Name}."
            };
        }
    }
}
