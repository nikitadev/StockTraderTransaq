using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransaqModelComponent.Helpers;

namespace TransaqModelComponent.Infrastructure
{
    internal sealed class TXmlConnectorWrapper : IDisposable
    {
        private IntPtr pResult;

        public string Initialize(string path, short logLevel)
        {
            using (var encoder = new UTF8Encoder())
            {
                encoder.SetData(path);

                pResult = TXmlConnectorHelper.Initialize(encoder.Data, logLevel);

                return pResult.ToStringUTF8();
            }
        }

        public string Finalize()
        {
            pResult = TXmlConnectorHelper.UnInitialize();

            return pResult.ToStringUTF8();
        }

        public string SendCommand(string command)
        {
            using (var encoder = new UTF8Encoder())
            {
                encoder.SetData(command);

                pResult = TXmlConnectorHelper.SendCommand(encoder.Data);

                return pResult.ToStringUTF8();
            }
        }

        public void Dispose()
        {
            TXmlConnectorHelper.FreeMemory(pResult);

            pResult = IntPtr.Zero;
        }
    }
}
