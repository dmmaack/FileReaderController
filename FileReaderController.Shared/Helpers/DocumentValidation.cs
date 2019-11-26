using FileReaderController.Shared.Enums;

namespace FileReaderController.Shared.Helpers
{
    public static class DocumentValidation
    {
        public static bool Validate(string number, EDocumentType documentType)
        {
            if (documentType == EDocumentType.CNPJ && number.Length.Equals(14))
                return true;

            if (documentType == EDocumentType.CPF && number.Length.Equals(11))
                return true;

            return false;

        }
    }
}