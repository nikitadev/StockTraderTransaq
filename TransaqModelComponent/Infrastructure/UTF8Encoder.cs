using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TransaqModelComponent.Infrastructure
{
    public class UTF8Encoder : IDisposable
    {
        private IntPtr pData;
        private UTF8Encoding encoding = new UTF8Encoding();

        public IntPtr Data 
        { 
            get 
            { 
                return pData; 
            } 
        }

        public void SetData(String data)
        {
            var dataEncoded = encoding.GetBytes(String.Concat(data, Environment.NewLine));

            int size = Marshal.SizeOf(dataEncoded[0]) * dataEncoded.Length;

            pData = Marshal.AllocHGlobal(size);

            Marshal.Copy(dataEncoded, 0, pData, dataEncoded.Length);
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(pData);

            pData = IntPtr.Zero;
        }
    }
}
