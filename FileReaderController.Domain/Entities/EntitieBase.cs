using System.Linq;
using FileReaderController.Shared.Enums;
using Flunt.Notifications;

namespace FileReaderController.Domain.Entities
{
    public abstract class EntitieBase : Notifiable
    {
        protected EntitieBase(ELineType lineType)
        {
            LineType = lineType;
        }

        protected EntitieBase() { }

        public int Id { get; private set; }
        public ELineType LineType { get; private set; }
        public string Message { get; private set; }
        public bool HasError { get; private set; }

        public void AddErrorMessage(string message, bool hasError)
        {
            Message = message;
            HasError = hasError;
        }

        public string AddErrorFromNotifications()
        {
            var notifications = this.Notifications
                                .Select(s => $"{s.Property}-{s.Message}")
                                .ToArray()
                                .Aggregate((current, next) => $"{current} | {next}");


            AddErrorMessage(notifications, true);

            return notifications;
        }
    }
}