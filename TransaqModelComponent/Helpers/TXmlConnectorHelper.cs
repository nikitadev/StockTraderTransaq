using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TransaqModelComponent.Helpers
{
    internal delegate bool TXmlConnectorCallback(IntPtr pData);
    internal delegate bool TXmlConnectorCallbackEx(IntPtr pData, IntPtr userData);

    internal static class TXmlConnectorHelper
    {
        [DllImport("txmlconnector.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetCallback(TXmlConnectorCallback pCallback);

        [DllImport("txmlconnector.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetCallbackEx(TXmlConnectorCallbackEx pCallback, IntPtr userData);

        [DllImport("txmlconnector.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SendCommand(IntPtr pData);

        [DllImport("txmlconnector.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool FreeMemory(IntPtr pData);

        [DllImport("TXmlConnector.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Initialize(IntPtr pPath, Int32 logLevel);

        [DllImport("TXmlConnector.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr UnInitialize();

        [DllImport("TXmlConnector.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr SetLogLevel(Int32 logLevel);
    }
}
