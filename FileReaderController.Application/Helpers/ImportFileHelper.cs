using FileReaderController.Shared.Enums;

namespace FileReaderController.Application.Helpers
{
    public static class ImportFileHelper
    {
        public static ELineType IdentifyLineType(string line)
        {
            string identLine = line.Split(new char['ç'])[0];
            return (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>(identLine);
        }
    }
}