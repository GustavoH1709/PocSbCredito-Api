using PocSbCredito.Shared.Enums;

namespace PocSbCredito.Shared.Models
{
    public class Notification
    {
        public Guid Id { get; private set; }
        public string Message { get; set; }
        public NotificationKind Kind { get; set; }
        public object Parameters { get; set; } = new { };

        public Notification()
        {
            Id = Guid.NewGuid();
            Message = string.Empty;
            Kind = NotificationKind.Error;
            Parameters = new { };
        }

        public Notification(string message, NotificationKind kind)
        {
            Id = Guid.NewGuid();
            Message = message;
            Kind = kind;
            Parameters = new { };
        }

        public Notification(string message, NotificationKind kind, object parameters)
        {
            Id = Guid.NewGuid();
            Message = message;
            Kind = kind;
            Parameters = parameters;
        }

        public static Notification CreateSuccessNotification(string message, object? parameters = null)
        {
            if (parameters is null)
            {
                return new(message, NotificationKind.Success);
            }
            else
            {
                return new(message, NotificationKind.Success, parameters);
            }
        }

        public static Notification CreateInfoNotification(string message, object? parameters = null)
        {
            if (parameters is null)
            {
                return new(message, NotificationKind.Information);
            }
            else
            {
                return new(message, NotificationKind.Information, parameters);
            }
        }

        public static Notification CreateWarningNotification(string message, object? parameters = null)
        {
            if (parameters is null)
            {
                return new(message, NotificationKind.Warning);
            }
            else
            {
                return new(message, NotificationKind.Warning, parameters);
            }
        }

        public static Notification CreateErrorNotification(string message, object? parameters = null)
        {
            if (parameters is null)
            {
                return new(message, NotificationKind.Error);
            }
            else
            {
                return new(message, NotificationKind.Error, parameters);
            }
        }
    }
}
