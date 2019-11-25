using FileReaderController.Shared.Enums;

namespace FileReaderController.Domain.Entities
{
    public abstract class EntitieBase
    {
        protected EntitieBase(ELineType lineType, string message, bool hasError)
        {
            LineType = lineType;
            Message = message;
            HasError = hasError;
        }

        public int Id { get; private set; }
        public ELineType LineType { get; private set; }
        public string Message { get; private set; }
        public bool HasError { get; private set; }
    }
}