using System;
using System.Runtime.InteropServices;
using System.Text;

namespace TransaqModelComponent.Helpers
{
    internal static class IntPtrHelper
    {
        public static String ToStringUTF8(this IntPtr pData)
        {
            if (pData.Equals(IntPtr.Zero))
                return String.Empty;
                        
            // this is just to get buffer length in bytes
            string errors = Marshal.PtrToStringAnsi(pData);

            byte[] data = new byte[errors.Length];
            Marshal.Copy(pData, data, 0, errors.Length);

            var encoding = new UTF8Encoding();
            return encoding.GetString(data);
        }
    }
}
