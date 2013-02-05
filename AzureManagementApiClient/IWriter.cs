namespace AzureManagementApiClient
{
    public interface IWriter
    {
        void WriteLine(string content);
        void WriteLine(string format, params object[] arg);
        void Write(string content);
    }
}