using FileReaderController.Shared.Enums;

namespace FileReaderController.Shared.Entities
{
    public abstract class EntitieBase
    {
        protected EntitieBase(int id, ELineType lineType)
        {
            Id = id;
            LineType = lineType;
        }

        public int Id { get; private set; }
        public ELineType LineType { get; private set; }
    }
}