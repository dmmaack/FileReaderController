namespace FileReaderController.Application.Helpers.ToObject
{
    public interface IConvertToObject<T> where T : class
    {
        T ExecuteConversion(string obj);
         
    }
}