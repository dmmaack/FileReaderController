using FileReaderController.Shared.Enums;

namespace FileReaderController.Application.Helpers
{
    public static class ImportFileHelper
    {
        public static ELineType IdentifyLineType(string line)
        {
            string identLine = line.Split("\u00E7")[0];
            return (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>(identLine);
        }
    }
}