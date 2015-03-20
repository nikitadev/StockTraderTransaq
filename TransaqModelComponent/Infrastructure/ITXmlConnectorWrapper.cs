using System;

namespace TransaqModelComponent.Infrastructure
{
    public interface ITXmlConnectorWrapper : IDisposable
    {
        string Initialize(string path, short logLevel);
        string SendCommand(string command);
        string Finalize();        
    }
}
