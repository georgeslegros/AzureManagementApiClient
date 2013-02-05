using System;
using AzureManagementApiClient;

namespace ApiConsole
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string format)
        {
            WriteLine(format, new object[] {});
        }

        public void WriteLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }

        public void Write(string content)
        {
            Console.Write(content);
        }
    }
}