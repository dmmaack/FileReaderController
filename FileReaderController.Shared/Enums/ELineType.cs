using System.ComponentModel;

namespace FileReaderController.Shared.Enums
{
    public enum ELineType
    {
        [Description("001")]
        SalesmanData,

        [Description("002")]
        ClienteData, 

        [Description("003")]
        SalesData, 
    }
}